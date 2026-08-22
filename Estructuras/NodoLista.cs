namespace AutomataUnionApp.Estructuras
{
    public class NodoLista<T>
    {
        public T Valor;
        public NodoLista<T> Siguiente;

        public NodoLista(T valor)
        {
            Valor = valor;
            Siguiente = null;
        }
    }
}