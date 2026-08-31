using System;
using System.Windows.Forms;

namespace AutomataUnionApp.Formularios
{
    // Menú de inicio: abre FormEditarAutomata, FormUnion, y FormVerGuardados.
    public partial class FormPrincipal : Form
    {
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

        // Abre la pantalla dedicada que lista los autómatas guardados
        // y muestra el detalle del que se seleccione.
        private void BtnVerGuardados_Click(object? sender, EventArgs e)
        {
            FormVerGuardados form = new FormVerGuardados();
            form.ShowDialog();
        }

        private void BtnSalir_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}