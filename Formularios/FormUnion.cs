using System;
using System.Windows.Forms;
using AutomataUnionApp.Dominio;
using AutomataUnionApp.Estructuras;
using AutomataUnionApp.Persistencia;
using AutomataUnionApp.Union;
using AutomataUnionApp.Utilidades;

namespace AutomataUnionApp.Formularios
{
    // Pantalla de unión: carga los autómatas válidos guardados, permite
    // elegir dos, genera el autómata unión con OperacionUnion, y muestra
    // la tabla de transiciones (con marcadores → inicial / * final) y el
    // resumen de componentes.
    public partial class FormUnion : Form
    {
        private const string RutaArchivo = "automatas.dat";
        private readonly GestorArchivoAutomatas _gestorArchivos = new GestorArchivoAutomatas();

        private Lista<Automata> _automatasDisponibles = new Lista<Automata>();
        private Automata? _resultadoUnion;

        public FormUnion()
        {
            InitializeComponent();
        }

        private void FormUnion_Load(object? sender, EventArgs e)
        {
            CargarAutomatasDisponibles();
        }

        // Solo lista autómatas que ya pasaron la validación (EsValido == true).
        private void CargarAutomatasDisponibles()
        {
            cmbAutomata1.Items.Clear();
            cmbAutomata2.Items.Clear();

            Lista<Automata> todos = _gestorArchivos.Cargar(RutaArchivo);
            _automatasDisponibles = new Lista<Automata>();

            NodoLista<Automata>? actual = todos.Cabeza;
            while (actual != null)
            {
                if (actual.Valor.EsValido)
                {
                    _automatasDisponibles.Agregar(actual.Valor);
                    cmbAutomata1.Items.Add(actual.Valor.Nombre);
                    cmbAutomata2.Items.Add(actual.Valor.Nombre);
                }
                actual = actual.Siguiente;
            }

            if (_automatasDisponibles.Cantidad == 0)
            {
                MessageBox.Show("No hay autómatas válidos guardados todavía. Ve a \"Editar autómata\" y guarda al menos dos.", "Sin autómatas");
            }
        }

        private void BtnGenerarUnion_Click(object? sender, EventArgs e)
        {
            lstErrores.Items.Clear();
            dgvResultado.Columns.Clear();
            dgvResultado.Rows.Clear();
            lstComponentes.Items.Clear();
            btnProbarCadenas.Enabled = false;
            _resultadoUnion = null;

            if (cmbAutomata1.SelectedIndex < 0 || cmbAutomata2.SelectedIndex < 0)
            {
                MessageBox.Show("Selecciona ambos autómatas.", "Falta información");
                return;
            }

            Automata a1 = _automatasDisponibles.ObtenerEn(cmbAutomata1.SelectedIndex);
            Automata a2 = _automatasDisponibles.ObtenerEn(cmbAutomata2.SelectedIndex);

            OperacionUnion operacion = new OperacionUnion();
            Automata? resultado = operacion.Unir(a1, a2);

            if (resultado == null)
            {
                NodoLista<string>? error = operacion.Errores.Cabeza;
                while (error != null)
                {
                    lstErrores.Items.Add(error.Valor);
                    error = error.Siguiente;
                }
                return;
            }

            _resultadoUnion = resultado;
            MostrarTablaResultado(resultado);
            MostrarComponentes(resultado);
            btnProbarCadenas.Enabled = true;
        }

        // Una columna por símbolo del alfabeto, una fila por estado par,
        // con → para el inicial y * para los finales en la primera columna.
        private void MostrarTablaResultado(Automata a)
        {
            TablaAutomataUtil.LlenarTabla(dgvResultado, a);
        }

        private void MostrarComponentes(Automata a)
        {
            lstComponentes.Items.Clear();
            lstComponentes.Items.Add("Estados: " + TextoUtil.UnirConComas(a.Estados));
            lstComponentes.Items.Add("Alfabeto: " + TextoUtil.UnirConComas(a.Alfabeto));
            lstComponentes.Items.Add("Estado inicial: " + (a.EstadoInicial ?? "(ninguno)"));
            lstComponentes.Items.Add("Estados finales: " + TextoUtil.UnirConComas(a.EstadosFinales));
        }

        private void BtnProbarCadenas_Click(object? sender, EventArgs e)
        {
            if (_resultadoUnion == null || cmbAutomata1.SelectedIndex < 0 || cmbAutomata2.SelectedIndex < 0)
            {
                return;
            }

            Automata a1 = _automatasDisponibles.ObtenerEn(cmbAutomata1.SelectedIndex);
            Automata a2 = _automatasDisponibles.ObtenerEn(cmbAutomata2.SelectedIndex);

            FormPruebaCadenas formPrueba = new FormPruebaCadenas(a1, a2, _resultadoUnion);
            formPrueba.ShowDialog();
        }
    }
}