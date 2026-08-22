using AutomataUnionApp.Dominio;
using AutomataUnionApp.Estructuras;

namespace AutomataUnionApp.Validacion
{
    // Valida que un Automata cumpla las propiedades de un DFA:
    // unicidad de nombres, símbolos permitidos, estado inicial y
    // finales válidos, y que delta sea total y determinista.

    public class ValidadorDFA
    {
        public void Validar(Automata a)
        {
            a.Errores = new Lista<string>();

            ValidarUnicidadEstados(a);
            ValidarUnicidadAlfabeto(a);
            ValidarSimbolosValidos(a);
            ValidarEstadoInicial(a);
            ValidarEstadosFinales(a);
            ValidarOrigenYSimboloDeTransiciones(a);
            ValidarIntegridadDestinos(a);
            ValidarCompletitudYDeterminismo(a);

            a.EsValido = (a.Errores.Cantidad == 0);
        }

        // 1a. Unicidad de nombres de estados.
        private void ValidarUnicidadEstados(Automata a)
        {
            Lista<string> vistos = new Lista<string>();
            NodoLista<string>? actual = a.Estados.Cabeza;
            while (actual != null)
            {
                if (vistos.Existe(actual.Valor))
                {
                    a.Errores.Agregar($"El estado '{actual.Valor}' está duplicado en el conjunto de estados.");
                }
                else
                {
                    vistos.Agregar(actual.Valor);
                }
                actual = actual.Siguiente;
            }
        }

        // 1b. Unicidad de símbolos del alfabeto.
        private void ValidarUnicidadAlfabeto(Automata a)
        {
            Lista<string> vistos = new Lista<string>();
            NodoLista<string>? actual = a.Alfabeto.Cabeza;
            while (actual != null)
            {
                if (vistos.Existe(actual.Valor))
                {
                    a.Errores.Agregar($"El símbolo '{actual.Valor}' está duplicado en el alfabeto.");
                }
                else
                {
                    vistos.Agregar(actual.Valor);
                }
                actual = actual.Siguiente;
            }
        }

        // 1c. Símbolos reservados/nulos: epsilon, lambda, espacios en blanco, guiones.
        private void ValidarSimbolosValidos(Automata a)
        {
            NodoLista<string>? actual = a.Alfabeto.Cabeza;
            while (actual != null)
            {
                if (EsSimboloProhibido(actual.Valor))
                {
                    a.Errores.Agregar($"El símbolo '{actual.Valor}' no es válido (reservado, vacío o en blanco).");
                }
                actual = actual.Siguiente;
            }
        }

        private bool EsSimboloProhibido(string? simbolo)
        {
            if (simbolo == null) return true;
            if (simbolo.Length == 0) return true;
            if (simbolo == "-") return true;
            if (simbolo == "_") return true;
            if (simbolo == "ε") return true;
            if (simbolo == "epsilon") return true;
            if (simbolo == "λ") return true;
            if (simbolo == "lambda") return true;

            // Recorrido manual carácter por carácter para detectar
            // espacios en blanco, sin usar .Contains() ni regex.
            for (int i = 0; i < simbolo.Length; i++)
            {
                char c = simbolo[i];
                if (c == ' ' || c == '\t')
                {
                    return true;
                }
            }
            return false;
        }

        // 2a. Debe existir un estado inicial y pertenecer al conjunto de estados.
        // (La unicidad del inicial está garantizada por diseño: es un solo campo string, no una lista.)
        private void ValidarEstadoInicial(Automata a)
        {
            string? inicial = a.EstadoInicial;

            if (string.IsNullOrEmpty(inicial))
            {
                a.Errores.Agregar("No se definió un estado inicial.");
                return;
            }
            if (!a.Estados.Existe(inicial))
            {
                a.Errores.Agregar($"El estado inicial '{inicial}' no pertenece al conjunto de estados.");
            }
        }

        // 2b. Cada estado final debe pertenecer al conjunto de estados (la lista vacía es válida).
        private void ValidarEstadosFinales(Automata a)
        {
            NodoLista<string>? actual = a.EstadosFinales.Cabeza;
            while (actual != null)
            {
                if (!a.Estados.Existe(actual.Valor))
                {
                    a.Errores.Agregar($"El estado final '{actual.Valor}' no pertenece al conjunto de estados.");
                }
                actual = actual.Siguiente;
            }
        }

        // 3a. Cada transición debe partir de un estado real y usar un símbolo real del alfabeto.
        private void ValidarOrigenYSimboloDeTransiciones(Automata a)
        {
            NodoLista<Transicion>? actual = a.Transiciones.Cabeza;
            while (actual != null)
            {
                if (!a.Estados.Existe(actual.Valor.Origen))
                {
                    a.Errores.Agregar($"La transición usa el estado origen '{actual.Valor.Origen}', que no está registrado en el conjunto de estados.");
                }
                if (!a.Alfabeto.Existe(actual.Valor.Simbolo))
                {
                    a.Errores.Agregar($"La transición desde '{actual.Valor.Origen}' usa el símbolo '{actual.Valor.Simbolo}', que no pertenece al alfabeto.");
                }
                actual = actual.Siguiente;
            }
        }

        // 3b. Integridad de destino: todo estado alcanzado debe existir.
        private void ValidarIntegridadDestinos(Automata a)
        {
            NodoLista<Transicion>? actual = a.Transiciones.Cabeza;
            while (actual != null)
            {
                if (!a.Estados.Existe(actual.Valor.Destino))
                {
                    a.Errores.Agregar($"El estado de destino '{actual.Valor.Destino}' (transición desde '{actual.Valor.Origen}' con '{actual.Valor.Simbolo}') no está registrado en el conjunto de estados.");
                }
                actual = actual.Siguiente;
            }
        }

        // 3c. Completitud (delta total) y determinismo: exactamente una
        // transición por cada combinación (estado, símbolo).
        private void ValidarCompletitudYDeterminismo(Automata a)
        {
            NodoLista<string>? nodoEstado = a.Estados.Cabeza;
            while (nodoEstado != null)
            {
                NodoLista<string>? nodoSimbolo = a.Alfabeto.Cabeza;
                while (nodoSimbolo != null)
                {
                    int cantidad = ContarTransiciones(a, nodoEstado.Valor, nodoSimbolo.Valor);

                    if (cantidad == 0)
                    {
                        a.Errores.Agregar($"El estado '{nodoEstado.Valor}' carece de transición para el símbolo '{nodoSimbolo.Valor}'.");
                    }
                    else if (cantidad > 1)
                    {
                        a.Errores.Agregar($"El estado '{nodoEstado.Valor}' tiene más de una transición definida para el símbolo '{nodoSimbolo.Valor}' (no determinismo).");
                    }

                    nodoSimbolo = nodoSimbolo.Siguiente;
                }
                nodoEstado = nodoEstado.Siguiente;
            }
        }

        // Cuenta cuántas transiciones existen para un par (estado, símbolo).
        // 0 = falta transición, 1 = correcto, 2+ = no determinismo.
        private int ContarTransiciones(Automata a, string estado, string simbolo)
        {
            int contador = 0;
            NodoLista<Transicion>? actual = a.Transiciones.Cabeza;
            while (actual != null)
            {
                if (actual.Valor.Origen == estado && actual.Valor.Simbolo == simbolo)
                {
                    contador++;
                }
                actual = actual.Siguiente;
            }
            return contador;
        }
    }
}