namespace AutomataUnionApp.Formularios
{
    partial class FormPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnNuevoAutomata = new System.Windows.Forms.Button();
            this.btnVerGuardados = new System.Windows.Forms.Button();
            this.btnRealizarUnion = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // btnNuevoAutomata
            //
            this.btnNuevoAutomata.Location = new System.Drawing.Point(40, 30);
            this.btnNuevoAutomata.Name = "btnNuevoAutomata";
            this.btnNuevoAutomata.Size = new System.Drawing.Size(300, 40);
            this.btnNuevoAutomata.TabIndex = 0;
            this.btnNuevoAutomata.Text = "Nuevo autómata";
            this.btnNuevoAutomata.UseVisualStyleBackColor = true;
            this.btnNuevoAutomata.Click += new System.EventHandler(this.BtnNuevoAutomata_Click);
            //
            // btnVerGuardados
            //
            this.btnVerGuardados.Location = new System.Drawing.Point(40, 80);
            this.btnVerGuardados.Name = "btnVerGuardados";
            this.btnVerGuardados.Size = new System.Drawing.Size(300, 40);
            this.btnVerGuardados.TabIndex = 1;
            this.btnVerGuardados.Text = "Ver autómatas guardados";
            this.btnVerGuardados.UseVisualStyleBackColor = true;
            this.btnVerGuardados.Click += new System.EventHandler(this.BtnVerGuardados_Click);
            //
            // btnRealizarUnion
            //
            this.btnRealizarUnion.Location = new System.Drawing.Point(40, 130);
            this.btnRealizarUnion.Name = "btnRealizarUnion";
            this.btnRealizarUnion.Size = new System.Drawing.Size(300, 40);
            this.btnRealizarUnion.TabIndex = 2;
            this.btnRealizarUnion.Text = "Realizar unión";
            this.btnRealizarUnion.UseVisualStyleBackColor = true;
            this.btnRealizarUnion.Click += new System.EventHandler(this.BtnRealizarUnion_Click);
            //
            // btnSalir
            //
            this.btnSalir.Location = new System.Drawing.Point(40, 180);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(300, 40);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            //
            // FormPrincipal
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 250);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnRealizarUnion);
            this.Controls.Add(this.btnVerGuardados);
            this.Controls.Add(this.btnNuevoAutomata);
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Autómatas Finitos — Menú principal";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnNuevoAutomata;
        private System.Windows.Forms.Button btnVerGuardados;
        private System.Windows.Forms.Button btnRealizarUnion;
        private System.Windows.Forms.Button btnSalir;
    }
}