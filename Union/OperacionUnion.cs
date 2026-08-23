using AutomataUnionApp.Dominio;
using AutomataUnionApp.Estructuras;

namespace AutomataUnionApp.Union
{
    // Construye el autómata resultante de unir dos DFA ya validados,
    // usando el producto cartesiano de sus conjuntos de estados y
    // el criterio de aceptación por disyunción (OR).
    public class OperacionUnion
    {
        public Lista<string> Errores { get; private set; }

        public OperacionUnion()
        {
            Errores = new Lista<string>();
        }

        public Automata? Unir(Automata a1, Automata a2)
        {
            Errores = new Lista<string>();

            if (!a1.EsValido || !a2.EsValido)
            {
                Errores.Agregar("Ambos autómatas deben estar validados (sin errores) antes de realizar la unión.");
                return null;
            }

            if (!AlfabetosCoinciden(a1, a2))
            {
                return null;
            }

            Automata resultado = new Automata($"Unión({a1.Nombre}, {a2.Nombre})");

            // El alfabeto del resultado es una copia del de a1 (ya confirmamos que es idéntico al de a2).
            NodoLista<string>? nodoSimboloCopia = a1.Alfabeto.Cabeza;
            while (nodoSimboloCopia != null)
            {
                resultado.Alfabeto.Agregar(nodoSimboloCopia.Valor);
                nodoSimboloCopia = nodoSimboloCopia.Siguiente;
            }

            // --- Producto cartesiano de estados + estados finales por OR ---
            NodoLista<string>? nodoA1 = a1.Estados.Cabeza;
            while (nodoA1 != null)
            {
                NodoLista<string>? nodoB1 = a2.Estados.Cabeza;
                while (nodoB1 != null)
                {
                    string combo = NombreEstadoCombo(nodoA1.Valor, nodoB1.Valor);
                    resultado.Estados.Agregar(combo);

                    if (a1.EstadosFinales.Existe(nodoA1.Valor) || a2.EstadosFinales.Existe(nodoB1.Valor))
                    {
                        resultado.EstadosFinales.Agregar(combo);
                    }

                    nodoB1 = nodoB1.Siguiente;
                }
                nodoA1 = nodoA1.Siguiente;
            }

            // --- Estado inicial: combo de los dos iniciales ---
            if (a1.EstadoInicial != null && a2.EstadoInicial != null)
            {
                resultado.EstadoInicial = NombreEstadoCombo(a1.EstadoInicial, a2.EstadoInicial);
            }

            // --- Transiciones combinadas ---
            NodoLista<string>? nodoA2 = a1.Estados.Cabeza;
            while (nodoA2 != null)
            {
                NodoLista<string>? nodoB2 = a2.Estados.Cabeza;
                while (nodoB2 != null)
                {
                    string origenCombo = NombreEstadoCombo(nodoA2.Valor, nodoB2.Valor);

                    NodoLista<string>? nodoSimbolo = resultado.Alfabeto.Cabeza;
                    while (nodoSimbolo != null)
                    {
                        Transicion? transA = a1.BuscarTransicion(nodoA2.Valor, nodoSimbolo.Valor);
                        Transicion? transB = a2.BuscarTransicion(nodoB2.Valor, nodoSimbolo.Valor);

                        // Como a1 y a2 ya están validados (delta total), transA y transB
                        // siempre deberían existir. El chequeo null es solo defensivo.
                        if (transA != null && transB != null)
                        {
                            string destinoCombo = NombreEstadoCombo(transA.Destino, transB.Destino);
                            resultado.Transiciones.Agregar(new Transicion(origenCombo, nodoSimbolo.Valor, destinoCombo));
                        }

                        nodoSimbolo = nodoSimbolo.Siguiente;
                    }

                    nodoB2 = nodoB2.Siguiente;
                }
                nodoA2 = nodoA2.Siguiente;
            }

            // Por construcción (a1 y a2 válidos + mismo alfabeto), el resultado
            // ya cumple con ser un DFA total y determinista.
            resultado.EsValido = true;
            return resultado;
        }

        // Verifica que ambos alfabetos contengan exactamente los mismos símbolos,
        // reportando en Errores cualquier símbolo que no coincida en ambos lados.
        private bool AlfabetosCoinciden(Automata a1, Automata a2)
        {
            bool coinciden = true;

            NodoLista<string>? actual = a1.Alfabeto.Cabeza;
            while (actual != null)
            {
                if (!a2.Alfabeto.Existe(actual.Valor))
                {
                    Errores.Agregar($"El símbolo '{actual.Valor}' está en el alfabeto de '{a1.Nombre}' pero no en el de '{a2.Nombre}'.");
                    coinciden = false;
                }
                actual = actual.Siguiente;
            }

            actual = a2.Alfabeto.Cabeza;
            while (actual != null)
            {
                if (!a1.Alfabeto.Existe(actual.Valor))
                {
                    Errores.Agregar($"El símbolo '{actual.Valor}' está en el alfabeto de '{a2.Nombre}' pero no en el de '{a1.Nombre}'.");
                    coinciden = false;
                }
                actual = actual.Siguiente;
            }

            return coinciden;
        }

        // Formato del nombre de un estado compuesto: (qA,qB)
        private string NombreEstadoCombo(string estadoA, string estadoB)
        {
            return $"({estadoA},{estadoB})";
        }
    }
}