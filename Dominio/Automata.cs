using AutomataUnionApp.Estructuras;

namespace AutomataUnionApp.Dominio
{
    // Representa un Autómata Finito Determinista completo.
    // Todas sus colecciones internas son Lista<T>, la
    // estructura propia construida en el paso anterior — nada
    // de List<T> ni colecciones nativas.
    public class Automata
    {
        public string Nombre;

        public Lista<string> Estados;
        public Lista<string> Alfabeto;
        public string? EstadoInicial;
        public Lista<string> EstadosFinales;
        public Lista<Transicion> Transiciones;

        public bool EsValido;
        public Lista<string> Errores;

        public Automata(string nombre)
        {
            Nombre = nombre;
            Estados = new Lista<string>();
            Alfabeto = new Lista<string>();
            EstadoInicial = null;
            EstadosFinales = new Lista<string>();
            Transiciones = new Lista<Transicion>();
            EsValido = false;
            Errores = new Lista<string>();
        }

        // Busca la transición definida para un estado y símbolo dados,
        // recorriendo la lista de transiciones nodo por nodo.
        // Devuelve null si no existe (esto es justo lo que usa el
        // validador para detectar que delta no es total).
        public Transicion? BuscarTransicion(string estado, string simbolo)
        {
            NodoLista<Transicion>? actual = Transiciones.Cabeza;
            while (actual != null)
            {
                if (actual.Valor.Origen == estado && actual.Valor.Simbolo == simbolo)
                {
                    return actual.Valor;
                }
                actual = actual.Siguiente;
            }
            return null;
        }
    }
}