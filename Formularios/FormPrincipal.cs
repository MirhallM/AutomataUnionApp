using System;
using System.Windows.Forms;
using AutomataUnionApp.Dominio;
using AutomataUnionApp.Estructuras;
using AutomataUnionApp.Persistencia;

namespace AutomataUnionApp.Formularios
{
    // Menú de inicio: abre FormEditarAutomata, FormUnion, o muestra un
    // resumen rápido de los autómatas guardados en el archivo.
    public partial class FormPrincipal : Form
    {
        private const string RutaArchivo = "automatas.dat";
        private readonly GestorArchivoAutomatas _gestorArchivos = new GestorArchivoAutomatas();

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void BtnNuevoAutomata_Click(object? sender, EventArgs e)
        {
            FormEditarAutomata form = new FormEditarAutomata();
            form.ShowDialog();
        }

        private void BtnRealizarUnion_Click(object? sender, EventArgs e)
        {
            FormUnion form = new FormUnion();
            form.ShowDialog();
        }

        // Resumen rápido en un MessageBox: nombre + si es válido o no.
        // No es una pantalla dedicada, pero cumple con "ver lo guardado"
        // sin agregar un cuarto Form solo para esto.
        private void BtnVerGuardados_Click(object? sender, EventArgs e)
        {
            Lista<Automata> automatas = _gestorArchivos.Cargar(RutaArchivo);

            if (automatas.Cantidad == 0)
            {
                MessageBox.Show("Todavía no hay autómatas guardados.", "Autómatas guardados");
                return;
            }

            string resumen = "";
            NodoLista<Automata>? actual = automatas.Cabeza;
            while (actual != null)
            {
                string estado = actual.Valor.EsValido ? "válido" : "inválido";
                resumen += "• " + actual.Valor.Nombre + " (" + estado + ")\n";
                actual = actual.Siguiente;
            }

            MessageBox.Show(resumen, "Autómatas guardados (" + automatas.Cantidad + ")");
        }

        private void BtnSalir_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}