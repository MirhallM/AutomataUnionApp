using System;
using System.Drawing;
using System.Windows.Forms;
using AutomataUnionApp.Dominio;
using AutomataUnionApp.Estructuras;
using AutomataUnionApp.Persistencia;
using AutomataUnionApp.Utilidades;
using AutomataUnionApp.Validacion;

namespace AutomataUnionApp.Formularios
{
    // Pantalla para crear/editar un autómata: captura estados, alfabeto,
    // inicial y finales; genera la tabla de transiciones (flujo de dos
    // pasos); valida con ValidadorDFA; y guarda con GestorArchivoAutomatas.
    // Los controles están declarados en FormEditarAutomata.Designer.cs.
    public partial class FormEditarAutomata : Form
    {
        private const string RutaArchivo = "automatas.dat";
        private readonly GestorArchivoAutomatas _gestorArchivos = new GestorArchivoAutomatas();
        private Automata? _automataEnEdicion;

        public FormEditarAutomata()
        {
            InitializeComponent();
        }

        // Paso 1: parsea estados/alfabeto/inicial/finales y genera
        // una fila por cada combinación (estado, símbolo), con un
        // combo de destino restringido a los estados ya escritos.
        private void BtnGenerarTabla_Click(object? sender, EventArgs e)
        {
            lblResultado.Text = "";
            lstErrores.Items.Clear();

            Lista<string> estados = TextoUtil.DividirPorComas(txtEstados.Text);
            Lista<string> alfabeto = TextoUtil.DividirPorComas(txtAlfabeto.Text);

            if (estados.Cantidad == 0 || alfabeto.Cantidad == 0)
            {
                MessageBox.Show("Debes ingresar al menos un estado y un símbolo del alfabeto antes de generar la tabla.", "Datos incompletos");
                return;
            }

            _automataEnEdicion = new Automata(txtNombre.Text)
            {
                Estados = estados,
                Alfabeto = alfabeto,
                EstadoInicial = txtInicial.Text.Trim().Length > 0 ? txtInicial.Text.Trim() : null,
                EstadosFinales = TextoUtil.DividirPorComas(txtFinales.Text)
            };

            ConstruirColumnasTabla(estados);
            LlenarFilasTabla(estados, alfabeto);

            btnGuardar.Enabled = false;
            btnAgregarFilaManual.Enabled = true;
        }

        // Agrega una fila extra con Origen y Símbolo editables (a diferencia
        // de las filas generadas automáticamente, que son de solo lectura).
        // Sirve para construir casos de prueba deliberados: por ejemplo,
        // duplicar un par (estado, símbolo) ya existente para demostrar
        // que el validador detecta el no determinismo.
        private void BtnAgregarFilaManual_Click(object? sender, EventArgs e)
        {
            if (_automataEnEdicion == null)
            {
                return;
            }

            int indice = dgvTransiciones.Rows.Add("", "", null);
            dgvTransiciones.Rows[indice].Cells["Origen"].ReadOnly = false;
            dgvTransiciones.Rows[indice].Cells["Simbolo"].ReadOnly = false;
        }

        private void ConstruirColumnasTabla(Lista<string> estados)
        {
            dgvTransiciones.Columns.Clear();

            DataGridViewTextBoxColumn colOrigen = new DataGridViewTextBoxColumn { Name = "Origen", HeaderText = "Origen", ReadOnly = true };
            DataGridViewTextBoxColumn colSimbolo = new DataGridViewTextBoxColumn { Name = "Simbolo", HeaderText = "Símbolo", ReadOnly = true };
            DataGridViewComboBoxColumn colDestino = new DataGridViewComboBoxColumn { Name = "Destino", HeaderText = "Destino" };

            NodoLista<string>? nodo = estados.Cabeza;
            while (nodo != null)
            {
                colDestino.Items.Add(nodo.Valor);
                nodo = nodo.Siguiente;
            }

            dgvTransiciones.Columns.Add(colOrigen);
            dgvTransiciones.Columns.Add(colSimbolo);
            dgvTransiciones.Columns.Add(colDestino);
        }

        private void LlenarFilasTabla(Lista<string> estados, Lista<string> alfabeto)
        {
            dgvTransiciones.Rows.Clear();

            NodoLista<string>? nodoEstado = estados.Cabeza;
            while (nodoEstado != null)
            {
                NodoLista<string>? nodoSimbolo = alfabeto.Cabeza;
                while (nodoSimbolo != null)
                {
                    dgvTransiciones.Rows.Add(nodoEstado.Valor, nodoSimbolo.Valor, null);
                    nodoSimbolo = nodoSimbolo.Siguiente;
                }
                nodoEstado = nodoEstado.Siguiente;
            }
        }

        // Paso 2: toma lo que el usuario llenó en la tabla, arma las
        // transiciones y corre el ValidadorDFA.
        private void BtnValidar_Click(object? sender, EventArgs e)
        {
            if (_automataEnEdicion == null)
            {
                MessageBox.Show("Primero genera la tabla de transiciones.", "Falta información");
                return;
            }

            _automataEnEdicion.Transiciones = new Lista<Transicion>();

            foreach (DataGridViewRow fila in dgvTransiciones.Rows)
            {
                if (fila.IsNewRow) continue;

                string origen = fila.Cells["Origen"].Value?.ToString() ?? "";
                string simbolo = fila.Cells["Simbolo"].Value?.ToString() ?? "";
                object? destinoObj = fila.Cells["Destino"].Value;

                if (destinoObj != null)
                {
                    string destino = destinoObj.ToString() ?? "";
                    _automataEnEdicion.Transiciones.Agregar(new Transicion(origen, simbolo, destino));
                }
            }

            ValidadorDFA validador = new ValidadorDFA();
            validador.Validar(_automataEnEdicion);

            MostrarResultadoValidacion();
        }

        private void MostrarResultadoValidacion()
        {
            lstErrores.Items.Clear();
            if (_automataEnEdicion == null) return;

            if (_automataEnEdicion.EsValido)
            {
                lblResultado.Text = "Autómata válido";
                lblResultado.ForeColor = Color.Green;
                btnGuardar.Enabled = true;
            }
            else
            {
                lblResultado.Text = "Autómata inválido";
                lblResultado.ForeColor = Color.Red;
                btnGuardar.Enabled = false;

                NodoLista<string>? error = _automataEnEdicion.Errores.Cabeza;
                while (error != null)
                {
                    lstErrores.Items.Add(error.Valor);
                    error = error.Siguiente;
                }
            }
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (_automataEnEdicion == null || !_automataEnEdicion.EsValido)
            {
                return;
            }

            Lista<Automata> automatas = _gestorArchivos.Cargar(RutaArchivo);
            automatas.Agregar(_automataEnEdicion);
            _gestorArchivos.Guardar(automatas, RutaArchivo);

            MessageBox.Show($"Autómata '{_automataEnEdicion.Nombre}' guardado correctamente.", "Guardado");

            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtEstados.Clear();
            txtAlfabeto.Clear();
            txtInicial.Clear();
            txtFinales.Clear();
            dgvTransiciones.Columns.Clear();
            dgvTransiciones.Rows.Clear();
            lblResultado.Text = "";
            lstErrores.Items.Clear();
            btnGuardar.Enabled = false;
            btnAgregarFilaManual.Enabled = false;
            _automataEnEdicion = null;
        }
    }
}