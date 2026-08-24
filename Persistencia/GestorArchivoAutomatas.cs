using System.IO;
using AutomataUnionApp.Dominio;
using AutomataUnionApp.Estructuras;

namespace AutomataUnionApp.Persistencia
{
    // Guarda y carga la lista de autómatas en un archivo de texto con
    // un formato propio (ver ejemplo en el comentario de Guardar).
    // El parseo es manual: sin Split(), sin IndexOf() y sin regex,
    // para mantener la misma filosofía del resto del proyecto.
    public class GestorArchivoAutomatas
    {
        // AUTOMATA
        // NOMBRE:Automata1
        // ESTADOS:q0,q1,q2
        // ALFABETO:a,b
        // INICIAL:q0
        // FINALES:q2
        // TRANSICION:q0,a,q1
        // FIN_AUTOMATA
        public void Guardar(Lista<Automata> automatas, string ruta)
        {
            using (StreamWriter escritor = new StreamWriter(ruta, false))
            {
                NodoLista<Automata>? actual = automatas.Cabeza;
                while (actual != null)
                {
                    EscribirAutomata(escritor, actual.Valor);
                    actual = actual.Siguiente;
                }
            }
        }

        public Lista<Automata> Cargar(string ruta)
        {
            Lista<Automata> resultado = new Lista<Automata>();

            if (!File.Exists(ruta))
            {
                return resultado;
            }

            using (StreamReader lector = new StreamReader(ruta))
            {
                Automata? actual = null;
                string? linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    if (linea == "AUTOMATA")
                    {
                        actual = new Automata("");
                    }
                    else if (linea == "FIN_AUTOMATA")
                    {
                        if (actual != null)
                        {
                            resultado.Agregar(actual);
                            actual = null;
                        }
                    }
                    else if (actual != null)
                    {
                        ProcesarLinea(actual, linea);
                    }
                }
            }

            return resultado;
        }

        private void EscribirAutomata(StreamWriter escritor, Automata a)
        {
            escritor.WriteLine("AUTOMATA");
            escritor.WriteLine("NOMBRE:" + a.Nombre);
            escritor.WriteLine("ESTADOS:" + UnirConComas(a.Estados));
            escritor.WriteLine("ALFABETO:" + UnirConComas(a.Alfabeto));
            escritor.WriteLine("INICIAL:" + (a.EstadoInicial ?? ""));
            escritor.WriteLine("FINALES:" + UnirConComas(a.EstadosFinales));

            NodoLista<Transicion>? t = a.Transiciones.Cabeza;
            while (t != null)
            {
                escritor.WriteLine("TRANSICION:" + t.Valor.Origen + "," + t.Valor.Simbolo + "," + t.Valor.Destino);
                t = t.Siguiente;
            }

            escritor.WriteLine("FIN_AUTOMATA");
        }

        private void ProcesarLinea(Automata a, string linea)
        {
            int posicion = BuscarPosicion(linea, ':');
            if (posicion < 0)
            {
                return;
            }

            string clave = linea.Substring(0, posicion);
            string valor = linea.Substring(posicion + 1);

            if (clave == "NOMBRE")
            {
                a.Nombre = valor;
            }
            else if (clave == "ESTADOS")
            {
                a.Estados = DividirPorComas(valor);
            }
            else if (clave == "ALFABETO")
            {
                a.Alfabeto = DividirPorComas(valor);
            }
            else if (clave == "INICIAL")
            {
                a.EstadoInicial = valor.Length > 0 ? valor : null;
            }
            else if (clave == "FINALES")
            {
                a.EstadosFinales = DividirPorComas(valor);
            }
            else if (clave == "TRANSICION")
            {
                Lista<string> partes = DividirPorComas(valor);
                if (partes.Cantidad == 3)
                {
                    a.Transiciones.Agregar(new Transicion(partes.ObtenerEn(0), partes.ObtenerEn(1), partes.ObtenerEn(2)));
                }
            }
        }

        // Búsqueda manual de un carácter dentro de una cadena (reemplaza a IndexOf).
        private int BuscarPosicion(string texto, char caracter)
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

        // Separa una cadena por comas y devuelve una Lista propia (reemplaza a Split).
        private Lista<string> DividirPorComas(string texto)
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

        // Une los valores de una Lista propia con comas (reemplaza a String.Join).
        private string UnirConComas(Lista<string> lista)
        {
            string resultado = "";
            NodoLista<string>? actual = lista.Cabeza;
            bool primero = true;

            while (actual != null)
            {
                if (!primero)
                {
                    resultado += ",";
                }
                resultado += actual.Valor;
                primero = false;
                actual = actual.Siguiente;
            }

            return resultado;
        }
    }
}