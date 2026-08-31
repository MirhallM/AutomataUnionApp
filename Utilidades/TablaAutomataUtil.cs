using System.Windows.Forms;
using AutomataUnionApp.Dominio;
using AutomataUnionApp.Estructuras;

namespace AutomataUnionApp.Utilidades
{
    // Llena un DataGridView con la tabla de transiciones de un Automata:
    // una columna por símbolo del alfabeto, una fila por estado, con
    // → marcando el estado inicial y * marcando los estados finales.
    public static class TablaAutomataUtil
    {
        public static void LlenarTabla(DataGridView grid, Automata a)
        {
            grid.Columns.Clear();
            grid.Rows.Clear();

            DataGridViewTextBoxColumn colEstado = new DataGridViewTextBoxColumn { Name = "Estado", HeaderText = "Estado", ReadOnly = true };
            grid.Columns.Add(colEstado);

            NodoLista<string>? nodoSimboloColumna = a.Alfabeto.Cabeza;
            while (nodoSimboloColumna != null)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn
                {
                    Name = nodoSimboloColumna.Valor,
                    HeaderText = nodoSimboloColumna.Valor,
                    ReadOnly = true
                };
                grid.Columns.Add(col);
                nodoSimboloColumna = nodoSimboloColumna.Siguiente;
            }

            NodoLista<string>? nodoEstado = a.Estados.Cabeza;
            while (nodoEstado != null)
            {
                string etiqueta = nodoEstado.Valor;
                if (etiqueta == a.EstadoInicial)
                {
                    etiqueta = "→" + etiqueta;
                }
                if (a.EstadosFinales.Existe(nodoEstado.Valor))
                {
                    etiqueta = "*" + etiqueta;
                }

                int indiceFila = grid.Rows.Add();
                grid.Rows[indiceFila].Cells["Estado"].Value = etiqueta;

                NodoLista<string>? nodoSimbolo = a.Alfabeto.Cabeza;
                while (nodoSimbolo != null)
                {
                    Transicion? transicion = a.BuscarTransicion(nodoEstado.Valor, nodoSimbolo.Valor);
                    grid.Rows[indiceFila].Cells[nodoSimbolo.Valor].Value = transicion != null ? transicion.Destino : "";
                    nodoSimbolo = nodoSimbolo.Siguiente;
                }

                nodoEstado = nodoEstado.Siguiente;
            }
        }
    }
}