namespace AutomataUnionApp.Formularios
{
    partial class FormUnion
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
            this.lblAutomata1 = new System.Windows.Forms.Label();
            this.cmbAutomata1 = new System.Windows.Forms.ComboBox();
            this.lblAutomata2 = new System.Windows.Forms.Label();
            this.cmbAutomata2 = new System.Windows.Forms.ComboBox();
            this.btnGenerarUnion = new System.Windows.Forms.Button();
            this.lstErrores = new System.Windows.Forms.ListBox();
            this.dgvResultado = new System.Windows.Forms.DataGridView();
            this.lblComponentes = new System.Windows.Forms.Label();
            this.lstComponentes = new System.Windows.Forms.ListBox();
            this.btnProbarCadenas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
            this.SuspendLayout();
            //
            // lblAutomata1
            //
            this.lblAutomata1.AutoSize = true;
            this.lblAutomata1.Location = new System.Drawing.Point(20, 20);
            this.lblAutomata1.Name = "lblAutomata1";
            this.lblAutomata1.Size = new System.Drawing.Size(72, 15);
            this.lblAutomata1.TabIndex = 0;
            this.lblAutomata1.Text = "Autómata 1:";
            //
            // cmbAutomata1
            //
            this.cmbAutomata1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAutomata1.Location = new System.Drawing.Point(120, 17);
            this.cmbAutomata1.Name = "cmbAutomata1";
            this.cmbAutomata1.Size = new System.Drawing.Size(300, 23);
            this.cmbAutomata1.TabIndex = 1;
            //
            // lblAutomata2
            //
            this.lblAutomata2.AutoSize = true;
            this.lblAutomata2.Location = new System.Drawing.Point(20, 55);
            this.lblAutomata2.Name = "lblAutomata2";
            this.lblAutomata2.Size = new System.Drawing.Size(72, 15);
            this.lblAutomata2.TabIndex = 2;
            this.lblAutomata2.Text = "Autómata 2:";
            //
            // cmbAutomata2
            //
            this.cmbAutomata2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAutomata2.Location = new System.Drawing.Point(120, 52);
            this.cmbAutomata2.Name = "cmbAutomata2";
            this.cmbAutomata2.Size = new System.Drawing.Size(300, 23);
            this.cmbAutomata2.TabIndex = 3;
            //
            // btnGenerarUnion
            //
            this.btnGenerarUnion.Location = new System.Drawing.Point(20, 95);
            this.btnGenerarUnion.Name = "btnGenerarUnion";
            this.btnGenerarUnion.Size = new System.Drawing.Size(180, 30);
            this.btnGenerarUnion.TabIndex = 4;
            this.btnGenerarUnion.Text = "Generar unión";
            this.btnGenerarUnion.UseVisualStyleBackColor = true;
            this.btnGenerarUnion.Click += new System.EventHandler(this.BtnGenerarUnion_Click);
            //
            // lstErrores
            //
            this.lstErrores.FormattingEnabled = true;
            this.lstErrores.Location = new System.Drawing.Point(20, 135);
            this.lstErrores.Name = "lstErrores";
            this.lstErrores.Size = new System.Drawing.Size(560, 64);
            this.lstErrores.TabIndex = 5;
            //
            // dgvResultado
            //
            this.dgvResultado.AllowUserToAddRows = false;
            this.dgvResultado.AllowUserToDeleteRows = false;
            this.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultado.Location = new System.Drawing.Point(20, 205);
            this.dgvResultado.Name = "dgvResultado";
            this.dgvResultado.ReadOnly = true;
            this.dgvResultado.RowHeadersVisible = false;
            this.dgvResultado.Size = new System.Drawing.Size(560, 220);
            this.dgvResultado.TabIndex = 6;
            //
            // lblComponentes
            //
            this.lblComponentes.AutoSize = true;
            this.lblComponentes.Location = new System.Drawing.Point(20, 435);
            this.lblComponentes.Name = "lblComponentes";
            this.lblComponentes.Size = new System.Drawing.Size(220, 15);
            this.lblComponentes.TabIndex = 7;
            this.lblComponentes.Text = "Componentes del autómata unión:";
            //
            // lstComponentes
            //
            this.lstComponentes.FormattingEnabled = true;
            this.lstComponentes.Location = new System.Drawing.Point(20, 460);
            this.lstComponentes.Name = "lstComponentes";
            this.lstComponentes.Size = new System.Drawing.Size(560, 94);
            this.lstComponentes.TabIndex = 8;
            //
            // btnProbarCadenas
            //
            this.btnProbarCadenas.Enabled = false;
            this.btnProbarCadenas.Location = new System.Drawing.Point(20, 560);
            this.btnProbarCadenas.Name = "btnProbarCadenas";
            this.btnProbarCadenas.Size = new System.Drawing.Size(150, 30);
            this.btnProbarCadenas.TabIndex = 9;
            this.btnProbarCadenas.Text = "Probar cadenas";
            this.btnProbarCadenas.UseVisualStyleBackColor = true;
            this.btnProbarCadenas.Click += new System.EventHandler(this.BtnProbarCadenas_Click);
            //
            // FormUnion
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(620, 620);
            this.Controls.Add(this.btnProbarCadenas);
            this.Controls.Add(this.lstComponentes);
            this.Controls.Add(this.lblComponentes);
            this.Controls.Add(this.dgvResultado);
            this.Controls.Add(this.lstErrores);
            this.Controls.Add(this.btnGenerarUnion);
            this.Controls.Add(this.cmbAutomata2);
            this.Controls.Add(this.lblAutomata2);
            this.Controls.Add(this.cmbAutomata1);
            this.Controls.Add(this.lblAutomata1);
            this.Name = "FormUnion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unión de autómatas";
            this.Load += new System.EventHandler(this.FormUnion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblAutomata1;
        private System.Windows.Forms.ComboBox cmbAutomata1;
        private System.Windows.Forms.Label lblAutomata2;
        private System.Windows.Forms.ComboBox cmbAutomata2;
        private System.Windows.Forms.Button btnGenerarUnion;
        private System.Windows.Forms.ListBox lstErrores;
        private System.Windows.Forms.DataGridView dgvResultado;
        private System.Windows.Forms.Label lblComponentes;
        private System.Windows.Forms.ListBox lstComponentes;
        private System.Windows.Forms.Button btnProbarCadenas;
    }
}