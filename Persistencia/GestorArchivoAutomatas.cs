using System.IO;
using AutomataUnionApp.Dominio;
using AutomataUnionApp.Estructuras;
using AutomataUnionApp.Utilidades;

namespace AutomataUnionApp.Persistencia
{
    // Guarda y carga la lista de autómatas en un archivo de texto con
    // un formato propio (ver ejemplo en el comentario de Guardar).
    // El parseo usa TextoUtil, compartido con el resto del proyecto.
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
            escritor.WriteLine("VALIDO:" + (a.EsValido ? "true" : "false"));
            escritor.WriteLine("ESTADOS:" + TextoUtil.UnirConComas(a.Estados));
            escritor.WriteLine("ALFABETO:" + TextoUtil.UnirConComas(a.Alfabeto));
            escritor.WriteLine("INICIAL:" + (a.EstadoInicial ?? ""));
            escritor.WriteLine("FINALES:" + TextoUtil.UnirConComas(a.EstadosFinales));

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
            int posicion = TextoUtil.BuscarPosicion(linea, ':');
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
            else if (clave == "VALIDO")
            {
                a.EsValido = (valor == "true");
            }
            else if (clave == "ESTADOS")
            {
                a.Estados = TextoUtil.DividirPorComas(valor);
            }
            else if (clave == "ALFABETO")
            {
                a.Alfabeto = TextoUtil.DividirPorComas(valor);
            }
            else if (clave == "INICIAL")
            {
                a.EstadoInicial = valor.Length > 0 ? valor : null;
            }
            else if (clave == "FINALES")
            {
                a.EstadosFinales = TextoUtil.DividirPorComas(valor);
            }
            else if (clave == "TRANSICION")
            {
                Lista<string> partes = TextoUtil.DividirPorComas(valor);
                if (partes.Cantidad == 3)
                {
                    a.Transiciones.Agregar(new Transicion(partes.ObtenerEn(0), partes.ObtenerEn(1), partes.ObtenerEn(2)));
                }
            }
        }
    }
}