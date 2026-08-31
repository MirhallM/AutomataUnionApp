namespace AutomataUnionApp.Formularios
{
    partial class FormVerGuardados
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
            this.lstAutomatas = new System.Windows.Forms.ListBox();
            this.lblNombreDetalle = new System.Windows.Forms.Label();
            this.lblEstadosDetalle = new System.Windows.Forms.Label();
            this.lblAlfabetoDetalle = new System.Windows.Forms.Label();
            this.lblInicialDetalle = new System.Windows.Forms.Label();
            this.lblFinalesDetalle = new System.Windows.Forms.Label();
            this.dgvTransicionesDetalle = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransicionesDetalle)).BeginInit();
            this.SuspendLayout();
            //
            // lstAutomatas
            //
            this.lstAutomatas.FormattingEnabled = true;
            this.lstAutomatas.Location = new System.Drawing.Point(20, 20);
            this.lstAutomatas.Name = "lstAutomatas";
            this.lstAutomatas.Size = new System.Drawing.Size(200, 460);
            this.lstAutomatas.TabIndex = 0;
            this.lstAutomatas.SelectedIndexChanged += new System.EventHandler(this.LstAutomatas_SelectedIndexChanged);
            //
            // lblNombreDetalle
            //
            this.lblNombreDetalle.AutoSize = true;
            this.lblNombreDetalle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNombreDetalle.Location = new System.Drawing.Point(240, 20);
            this.lblNombreDetalle.Name = "lblNombreDetalle";
            this.lblNombreDetalle.Size = new System.Drawing.Size(100, 21);
            this.lblNombreDetalle.TabIndex = 1;
            //
            // lblEstadosDetalle
            //
            this.lblEstadosDetalle.AutoSize = true;
            this.lblEstadosDetalle.Location = new System.Drawing.Point(240, 55);
            this.lblEstadosDetalle.Name = "lblEstadosDetalle";
            this.lblEstadosDetalle.Size = new System.Drawing.Size(60, 15);
            this.lblEstadosDetalle.TabIndex = 2;
            //
            // lblAlfabetoDetalle
            //
            this.lblAlfabetoDetalle.AutoSize = true;
            this.lblAlfabetoDetalle.Location = new System.Drawing.Point(240, 80);
            this.lblAlfabetoDetalle.Name = "lblAlfabetoDetalle";
            this.lblAlfabetoDetalle.Size = new System.Drawing.Size(60, 15);
            this.lblAlfabetoDetalle.TabIndex = 3;
            //
            // lblInicialDetalle
            //
            this.lblInicialDetalle.AutoSize = true;
            this.lblInicialDetalle.Location = new System.Drawing.Point(240, 105);
            this.lblInicialDetalle.Name = "lblInicialDetalle";
            this.lblInicialDetalle.Size = new System.Drawing.Size(60, 15);
            this.lblInicialDetalle.TabIndex = 4;
            //
            // lblFinalesDetalle
            //
            this.lblFinalesDetalle.AutoSize = true;
            this.lblFinalesDetalle.Location = new System.Drawing.Point(240, 130);
            this.lblFinalesDetalle.Name = "lblFinalesDetalle";
            this.lblFinalesDetalle.Size = new System.Drawing.Size(60, 15);
            this.lblFinalesDetalle.TabIndex = 5;
            //
            // dgvTransicionesDetalle
            //
            this.dgvTransicionesDetalle.AllowUserToAddRows = false;
            this.dgvTransicionesDetalle.AllowUserToDeleteRows = false;
            this.dgvTransicionesDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransicionesDetalle.Location = new System.Drawing.Point(240, 160);
            this.dgvTransicionesDetalle.Name = "dgvTransicionesDetalle";
            this.dgvTransicionesDetalle.ReadOnly = true;
            this.dgvTransicionesDetalle.RowHeadersVisible = false;
            this.dgvTransicionesDetalle.Size = new System.Drawing.Size(340, 300);
            this.dgvTransicionesDetalle.TabIndex = 6;
            //
            // btnCerrar
            //
            this.btnCerrar.Location = new System.Drawing.Point(480, 480);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 30);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            //
            // FormVerGuardados
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 530);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvTransicionesDetalle);
            this.Controls.Add(this.lblFinalesDetalle);
            this.Controls.Add(this.lblInicialDetalle);
            this.Controls.Add(this.lblAlfabetoDetalle);
            this.Controls.Add(this.lblEstadosDetalle);
            this.Controls.Add(this.lblNombreDetalle);
            this.Controls.Add(this.lstAutomatas);
            this.Name = "FormVerGuardados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autómatas guardados";
            this.Load += new System.EventHandler(this.FormVerGuardados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransicionesDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox lstAutomatas;
        private System.Windows.Forms.Label lblNombreDetalle;
        private System.Windows.Forms.Label lblEstadosDetalle;
        private System.Windows.Forms.Label lblAlfabetoDetalle;
        private System.Windows.Forms.Label lblInicialDetalle;
        private System.Windows.Forms.Label lblFinalesDetalle;
        private System.Windows.Forms.DataGridView dgvTransicionesDetalle;
        private System.Windows.Forms.Button btnCerrar;
    }
}