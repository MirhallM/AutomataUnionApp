using System;

namespace AutomataUnionApp.Estructuras
{
    // Lista enlazada simple, implementada desde cero.
    // No usa List<T>, ArrayList, ni ningún método nativo de
    // búsqueda/recorrido: todo se hace con punteros y bucles propios.
    public class Lista<T>
    {
        public NodoLista<T>? Cabeza { get; private set; }
        public int Cantidad { get; private set; }

        public Lista()
        {
            Cabeza = null;
            Cantidad = 0;
        }

        // Agrega un valor al final de la lista.
        public void Agregar(T valor)
        {
            NodoLista<T> nuevoNodo = new NodoLista<T>(valor);

            if (Cabeza == null)
            {
                Cabeza = nuevoNodo;
            }
            else
            {
                NodoLista<T> actual = Cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }

            Cantidad++;
        }

        // Búsqueda propia: recorre nodo por nodo comparando valores.
        public bool Existe(T valor)
        {
            NodoLista<T> actual = Cabeza;
            while (actual != null)
            {
                if (Comparar(actual.Valor, valor))
                {
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false;
        }

        // Elimina la primera ocurrencia del valor. Devuelve true si lo encontró.
        public bool Eliminar(T valor)
        {
            NodoLista<T> actual = Cabeza;
            NodoLista<T> anterior = null;

            while (actual != null)
            {
                if (Comparar(actual.Valor, valor))
                {
                    if (anterior == null)
                    {
                        Cabeza = actual.Siguiente;
                    }
                    else
                    {
                        anterior.Siguiente = actual.Siguiente;
                    }
                    Cantidad--;
                    return true;
                }
                anterior = actual;
                actual = actual.Siguiente;
            }
            return false;
        }

        // Acceso por índice, recorriendo desde la cabeza (equivalente manual a lista[i]).
        public T ObtenerEn(int indice)
        {
            if (indice < 0 || indice >= Cantidad)
            {
                throw new IndexOutOfRangeException("Índice fuera de rango en ListaPropia.");
            }

            NodoLista<T> actual = Cabeza;
            int contador = 0;
            while (contador < indice)
            {
                actual = actual.Siguiente;
                contador++;
            }
            return actual.Valor;
        }

        // Comparación centralizada en un solo lugar, por si luego
        // queremos ajustar cómo se comparan los valores (ej. ignorar
        // mayúsculas/minúsculas en nombres de estados).
        private bool Comparar(T a, T b)
        {
            if (a == null && b == null) return true;
            if (a == null || b == null) return false;
            return a.Equals(b);
        }
    }
}