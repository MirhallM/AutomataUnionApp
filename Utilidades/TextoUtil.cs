using AutomataUnionApp.Estructuras;

namespace AutomataUnionApp.Utilidades
{
    // Funciones de parseo de texto manual, compartidas por cualquier
    // parte del proyecto que necesite leer listas separadas por coma
    // o buscar un carácter dentro de una cadena. Sin Split(), sin
    // IndexOf() y sin regex — todo recorrido carácter por carácter.
    public static class TextoUtil
    {
        public static Lista<string> DividirPorComas(string texto)
        {
            Lista<string> partes = new Lista<string>();
            string actual = "";

            for (int i = 0; i < texto.Length; i++)
            {
                char c = texto[i];
                if (c == ',')
                {
                    partes.Agregar(actual.Trim());
                    actual = "";
                }
                else
                {
                    actual += c;
                }
            }

            if (actual.Trim().Length > 0 || partes.Cantidad > 0)
            {
                partes.Agregar(actual.Trim());
            }

            return partes;
        }

        public static string UnirConComas(Lista<string> lista)
        {
            return Unir(lista, ",");
        }

        public static string Unir(Lista<string> lista, string separador)
        {
            string resultado = "";
            NodoLista<string>? actual = lista.Cabeza;
            bool primero = true;

            while (actual != null)
            {
                if (!primero)
                {
                    resultado += separador;
                }
                resultado += actual.Valor;
                primero = false;
                actual = actual.Siguiente;
            }

            return resultado;
        }

        public static int BuscarPosicion(string texto, char caracter)
        {
            for (int i = 0; i < texto.Length; i++)
            {
                if (texto[i] == caracter)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}