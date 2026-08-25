namespace AutomataUnionApp.Formularios
{
    partial class FormEditarAutomata
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblEstados = new System.Windows.Forms.Label();
            this.txtEstados = new System.Windows.Forms.TextBox();
            this.lblAlfabeto = new System.Windows.Forms.Label();
            this.txtAlfabeto = new System.Windows.Forms.TextBox();
            this.lblInicial = new System.Windows.Forms.Label();
            this.txtInicial = new System.Windows.Forms.TextBox();
            this.lblFinales = new System.Windows.Forms.Label();
            this.txtFinales = new System.Windows.Forms.TextBox();
            this.btnGenerarTabla = new System.Windows.Forms.Button();
            this.dgvTransiciones = new System.Windows.Forms.DataGridView();
            this.btnValidar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.lstErrores = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransiciones)).BeginInit();
            this.SuspendLayout();
            //
            // lblNombre
            //
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 20);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 15);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            //
            // txtNombre
            //
            this.txtNombre.Location = new System.Drawing.Point(130, 17);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(250, 23);
            this.txtNombre.TabIndex = 1;
            //
            // lblEstados
            //
            this.lblEstados.AutoSize = true;
            this.lblEstados.Location = new System.Drawing.Point(20, 58);
            this.lblEstados.Name = "lblEstados";
            this.lblEstados.Size = new System.Drawing.Size(190, 15);
            this.lblEstados.TabIndex = 2;
            this.lblEstados.Text = "Estados (separados por coma):";
            //
            // txtEstados
            //
            this.txtEstados.Location = new System.Drawing.Point(250, 55);
            this.txtEstados.Name = "txtEstados";
            this.txtEstados.Size = new System.Drawing.Size(330, 23);
            this.txtEstados.TabIndex = 3;
            //
            // lblAlfabeto
            //
            this.lblAlfabeto.AutoSize = true;
            this.lblAlfabeto.Location = new System.Drawing.Point(20, 93);
            this.lblAlfabeto.Name = "lblAlfabeto";
            this.lblAlfabeto.Size = new System.Drawing.Size(185, 15);
            this.lblAlfabeto.TabIndex = 4;
            this.lblAlfabeto.Text = "Alfabeto (separado por coma):";
            //
            // txtAlfabeto
            //
            this.txtAlfabeto.Location = new System.Drawing.Point(250, 90);
            this.txtAlfabeto.Name = "txtAlfabeto";
            this.txtAlfabeto.Size = new System.Drawing.Size(330, 23);
            this.txtAlfabeto.TabIndex = 5;
            //
            // lblInicial
            //
            this.lblInicial.AutoSize = true;
            this.lblInicial.Location = new System.Drawing.Point(20, 128);
            this.lblInicial.Name = "lblInicial";
            this.lblInicial.Size = new System.Drawing.Size(83, 15);
            this.lblInicial.TabIndex = 6;
            this.lblInicial.Text = "Estado inicial:";
            //
            // txtInicial
            //
            this.txtInicial.Location = new System.Drawing.Point(250, 125);
            this.txtInicial.Name = "txtInicial";
            this.txtInicial.Size = new System.Drawing.Size(150, 23);
            this.txtInicial.TabIndex = 7;
            //
            // lblFinales
            //
            this.lblFinales.AutoSize = true;
            this.lblFinales.Location = new System.Drawing.Point(20, 163);
            this.lblFinales.Name = "lblFinales";
            this.lblFinales.Size = new System.Drawing.Size(230, 15);
            this.lblFinales.TabIndex = 8;
            this.lblFinales.Text = "Estados finales (separados por coma):";
            //
            // txtFinales
            //
            this.txtFinales.Location = new System.Drawing.Point(250, 160);
            this.txtFinales.Name = "txtFinales";
            this.txtFinales.Size = new System.Drawing.Size(330, 23);
            this.txtFinales.TabIndex = 9;
            //
            // btnGenerarTabla
            //
            this.btnGenerarTabla.Location = new System.Drawing.Point(20, 200);
            this.btnGenerarTabla.Name = "btnGenerarTabla";
            this.btnGenerarTabla.Size = new System.Drawing.Size(250, 30);
            this.btnGenerarTabla.TabIndex = 10;
            this.btnGenerarTabla.Text = "Generar tabla de transiciones";
            this.btnGenerarTabla.UseVisualStyleBackColor = true;
            this.btnGenerarTabla.Click += new System.EventHandler(this.BtnGenerarTabla_Click);
            //
            // dgvTransiciones
            //
            this.dgvTransiciones.AllowUserToAddRows = false;
            this.dgvTransiciones.AllowUserToDeleteRows = false;
            this.dgvTransiciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransiciones.Location = new System.Drawing.Point(20, 240);
            this.dgvTransiciones.Name = "dgvTransiciones";
            this.dgvTransiciones.RowHeadersVisible = false;
            this.dgvTransiciones.Size = new System.Drawing.Size(560, 220);
            this.dgvTransiciones.TabIndex = 11;
            //
            // btnValidar
            //
            this.btnValidar.Location = new System.Drawing.Point(20, 470);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(100, 30);
            this.btnValidar.TabIndex = 12;
            this.btnValidar.Text = "Validar";
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.BtnValidar_Click);
            //
            // btnGuardar
            //
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Location = new System.Drawing.Point(130, 470);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            //
            // lblResultado
            //
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblResultado.Location = new System.Drawing.Point(20, 510);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(560, 25);
            this.lblResultado.TabIndex = 14;
            //
            // lstErrores
            //
            this.lstErrores.FormattingEnabled = true;
            this.lstErrores.Location = new System.Drawing.Point(20, 540);
            this.lstErrores.Name = "lstErrores";
            this.lstErrores.Size = new System.Drawing.Size(560, 94);
            this.lstErrores.TabIndex = 15;
            //
            // FormEditarAutomata
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(620, 680);
            this.Controls.Add(this.lstErrores);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.dgvTransiciones);
            this.Controls.Add(this.btnGenerarTabla);
            this.Controls.Add(this.txtFinales);
            this.Controls.Add(this.lblFinales);
            this.Controls.Add(this.txtInicial);
            this.Controls.Add(this.lblInicial);
            this.Controls.Add(this.txtAlfabeto);
            this.Controls.Add(this.lblAlfabeto);
            this.Controls.Add(this.txtEstados);
            this.Controls.Add(this.lblEstados);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Name = "FormEditarAutomata";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar autómata";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransiciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblEstados;
        private System.Windows.Forms.TextBox txtEstados;
        private System.Windows.Forms.Label lblAlfabeto;
        private System.Windows.Forms.TextBox txtAlfabeto;
        private System.Windows.Forms.Label lblInicial;
        private System.Windows.Forms.TextBox txtInicial;
        private System.Windows.Forms.Label lblFinales;
        private System.Windows.Forms.TextBox txtFinales;
        private System.Windows.Forms.Button btnGenerarTabla;
        private System.Windows.Forms.DataGridView dgvTransiciones;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.ListBox lstErrores;
    }
}