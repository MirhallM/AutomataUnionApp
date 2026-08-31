using System;
using System.Windows.Forms;
using AutomataUnionApp.Dominio;
using AutomataUnionApp.Estructuras;
using AutomataUnionApp.Persistencia;
using AutomataUnionApp.Utilidades;

namespace AutomataUnionApp.Formularios
{
    // Muestra todos los autómatas guardados en el archivo: una lista de
    // nombres a la izquierda, y al seleccionar uno, sus componentes y
    // tabla de transiciones completa a la derecha.
    public partial class FormVerGuardados : Form
    {
        private const string RutaArchivo = "automatas.dat";
        private readonly GestorArchivoAutomatas _gestorArchivos = new GestorArchivoAutomatas();
        private Lista<Automata> _automatas = new Lista<Automata>();

        public FormVerGuardados()
        {
            InitializeComponent();
        }

        private void FormVerGuardados_Load(object? sender, EventArgs e)
        {
            CargarLista();
        }

        private void CargarLista()
        {
            lstAutomatas.Items.Clear();
            _automatas = _gestorArchivos.Cargar(RutaArchivo);

            NodoLista<Automata>? actual = _automatas.Cabeza;
            while (actual != null)
            {
                string etiqueta = actual.Valor.EsValido ? actual.Valor.Nombre : actual.Valor.Nombre + " (inválido)";
                lstAutomatas.Items.Add(etiqueta);
                actual = actual.Siguiente;
            }

            LimpiarDetalle();

            if (_automatas.Cantidad == 0)
            {
                MessageBox.Show("Todavía no hay autómatas guardados.", "Autómatas guardados");
            }
        }

        private void LstAutomatas_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (lstAutomatas.SelectedIndex < 0)
            {
                LimpiarDetalle();
                return;
            }

            Automata seleccionado = _automatas.ObtenerEn(lstAutomatas.SelectedIndex);
            MostrarDetalle(seleccionado);
        }

        private void MostrarDetalle(Automata a)
        {
            lblNombreDetalle.Text = a.Nombre;
            lblEstadosDetalle.Text = "Estados: " + TextoUtil.UnirConComas(a.Estados);
            lblAlfabetoDetalle.Text = "Alfabeto: " + TextoUtil.UnirConComas(a.Alfabeto);
            lblInicialDetalle.Text = "Estado inicial: " + (a.EstadoInicial ?? "(ninguno)");
            lblFinalesDetalle.Text = "Estados finales: " + TextoUtil.UnirConComas(a.EstadosFinales);

            TablaAutomataUtil.LlenarTabla(dgvTransicionesDetalle, a);
        }

        private void LimpiarDetalle()
        {
            lblNombreDetalle.Text = "";
            lblEstadosDetalle.Text = "";
            lblAlfabetoDetalle.Text = "";
            lblInicialDetalle.Text = "";
            lblFinalesDetalle.Text = "";
            dgvTransicionesDetalle.Columns.Clear();
            dgvTransicionesDetalle.Rows.Clear();
        }

        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}