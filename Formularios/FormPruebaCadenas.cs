using System;
using System.Drawing;
using System.Windows.Forms;
using AutomataUnionApp.Dominio;
using AutomataUnionApp.Simulacion;
using AutomataUnionApp.Utilidades;

namespace AutomataUnionApp.Formularios
{
    // Prueba una cadena en Autómata 1, Autómata 2 y el Autómata Unión al
    // mismo tiempo, mostrando la traza de estados compuestos (solo tiene
    // sentido para el de Unión) y el veredicto triple.
    public partial class FormPruebaCadenas : Form
    {
        private readonly SimuladorCadenas _simulador = new SimuladorCadenas();

        private Automata? _a1;
        private Automata? _a2;
        private Automata? _union;

        // Constructor sin parámetros: requerido por el diseñador visual
        // de Visual Studio para poder abrir la vista de diseño.
        public FormPruebaCadenas()
        {
            InitializeComponent();
        }

        // Constructor real: se usa al abrir esta pantalla desde FormUnion.
        public FormPruebaCadenas(Automata a1, Automata a2, Automata union) : this()
        {
            _a1 = a1;
            _a2 = a2;
            _union = union;
        }

        private void BtnProbar_Click(object? sender, EventArgs e)
        {
            if (_a1 == null || _a2 == null || _union == null)
            {
                MessageBox.Show("Este formulario debe abrirse desde la pantalla de Unión.", "Error");
                return;
            }

            string cadena = txtCadena.Text;

            ResultadoSimulacion resultadoA1 = _simulador.Simular(_a1, cadena);
            ResultadoSimulacion resultadoA2 = _simulador.Simular(_a2, cadena);
            ResultadoSimulacion resultadoUnion = _simulador.Simular(_union, cadena);

            MostrarTraza(resultadoUnion);
            MostrarVeredicto(lblVeredictoA1, resultadoA1);
            MostrarVeredicto(lblVeredictoA2, resultadoA2);
            MostrarVeredicto(lblVeredictoUnion, resultadoUnion);
        }

        // La traza (secuencia de estados compuestos) solo tiene sentido
        // mostrarla para el autómata unión, tal como pide el enunciado.
        private void MostrarTraza(ResultadoSimulacion resultado)
        {
            if (resultado.Error != null)
            {
                txtTraza.Text = "Error: " + resultado.Error;
                return;
            }

            txtTraza.Text = TextoUtil.Unir(resultado.Traza, " → ");
        }

        private void MostrarVeredicto(Label etiqueta, ResultadoSimulacion resultado)
        {
            if (resultado.Error != null || !resultado.Aceptada)
            {
                etiqueta.Text = "Rechazada";
                etiqueta.ForeColor = Color.Red;
            }
            else
            {
                etiqueta.Text = "Aceptada";
                etiqueta.ForeColor = Color.Green;
            }
        }
    }
}