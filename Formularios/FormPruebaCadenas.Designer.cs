namespace AutomataUnionApp.Formularios
{
    partial class FormPruebaCadenas
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
            this.lblCadena = new System.Windows.Forms.Label();
            this.txtCadena = new System.Windows.Forms.TextBox();
            this.btnProbar = new System.Windows.Forms.Button();
            this.lblTrazaTitulo = new System.Windows.Forms.Label();
            this.txtTraza = new System.Windows.Forms.TextBox();
            this.lblTitA1 = new System.Windows.Forms.Label();
            this.lblVeredictoA1 = new System.Windows.Forms.Label();
            this.lblTitA2 = new System.Windows.Forms.Label();
            this.lblVeredictoA2 = new System.Windows.Forms.Label();
            this.lblTitUnion = new System.Windows.Forms.Label();
            this.lblVeredictoUnion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // lblCadena
            //
            this.lblCadena.AutoSize = true;
            this.lblCadena.Location = new System.Drawing.Point(20, 20);
            this.lblCadena.Name = "lblCadena";
            this.lblCadena.Size = new System.Drawing.Size(96, 15);
            this.lblCadena.TabIndex = 0;
            this.lblCadena.Text = "Cadena a probar:";
            //
            // txtCadena
            //
            this.txtCadena.Location = new System.Drawing.Point(140, 17);
            this.txtCadena.Name = "txtCadena";
            this.txtCadena.Size = new System.Drawing.Size(300, 23);
            this.txtCadena.TabIndex = 1;
            //
            // btnProbar
            //
            this.btnProbar.Location = new System.Drawing.Point(450, 16);
            this.btnProbar.Name = "btnProbar";
            this.btnProbar.Size = new System.Drawing.Size(100, 25);
            this.btnProbar.TabIndex = 2;
            this.btnProbar.Text = "Probar";
            this.btnProbar.UseVisualStyleBackColor = true;
            this.btnProbar.Click += new System.EventHandler(this.BtnProbar_Click);
            //
            // lblTrazaTitulo
            //
            this.lblTrazaTitulo.AutoSize = true;
            this.lblTrazaTitulo.Location = new System.Drawing.Point(20, 60);
            this.lblTrazaTitulo.Name = "lblTrazaTitulo";
            this.lblTrazaTitulo.Size = new System.Drawing.Size(230, 15);
            this.lblTrazaTitulo.TabIndex = 3;
            this.lblTrazaTitulo.Text = "Derivación δ̂ en el autómata unión:";
            //
            // txtTraza
            //
            this.txtTraza.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtTraza.Location = new System.Drawing.Point(20, 85);
            this.txtTraza.Multiline = true;
            this.txtTraza.Name = "txtTraza";
            this.txtTraza.ReadOnly = true;
            this.txtTraza.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTraza.Size = new System.Drawing.Size(530, 220);
            this.txtTraza.TabIndex = 4;
            //
            // lblTitA1
            //
            this.lblTitA1.AutoSize = true;
            this.lblTitA1.Location = new System.Drawing.Point(20, 320);
            this.lblTitA1.Name = "lblTitA1";
            this.lblTitA1.Size = new System.Drawing.Size(72, 15);
            this.lblTitA1.TabIndex = 5;
            this.lblTitA1.Text = "Autómata 1:";
            //
            // lblVeredictoA1
            //
            this.lblVeredictoA1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblVeredictoA1.Location = new System.Drawing.Point(20, 340);
            this.lblVeredictoA1.Name = "lblVeredictoA1";
            this.lblVeredictoA1.Size = new System.Drawing.Size(160, 25);
            this.lblVeredictoA1.TabIndex = 6;
            //
            // lblTitA2
            //
            this.lblTitA2.AutoSize = true;
            this.lblTitA2.Location = new System.Drawing.Point(210, 320);
            this.lblTitA2.Name = "lblTitA2";
            this.lblTitA2.Size = new System.Drawing.Size(72, 15);
            this.lblTitA2.TabIndex = 7;
            this.lblTitA2.Text = "Autómata 2:";
            //
            // lblVeredictoA2
            //
            this.lblVeredictoA2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblVeredictoA2.Location = new System.Drawing.Point(210, 340);
            this.lblVeredictoA2.Name = "lblVeredictoA2";
            this.lblVeredictoA2.Size = new System.Drawing.Size(160, 25);
            this.lblVeredictoA2.TabIndex = 8;
            //
            // lblTitUnion
            //
            this.lblTitUnion.AutoSize = true;
            this.lblTitUnion.Location = new System.Drawing.Point(400, 320);
            this.lblTitUnion.Name = "lblTitUnion";
            this.lblTitUnion.Size = new System.Drawing.Size(46, 15);
            this.lblTitUnion.TabIndex = 9;
            this.lblTitUnion.Text = "Unión:";
            //
            // lblVeredictoUnion
            //
            this.lblVeredictoUnion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblVeredictoUnion.Location = new System.Drawing.Point(400, 340);
            this.lblVeredictoUnion.Name = "lblVeredictoUnion";
            this.lblVeredictoUnion.Size = new System.Drawing.Size(160, 25);
            this.lblVeredictoUnion.TabIndex = 10;
            //
            // FormPruebaCadenas
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 400);
            this.Controls.Add(this.lblVeredictoUnion);
            this.Controls.Add(this.lblTitUnion);
            this.Controls.Add(this.lblVeredictoA2);
            this.Controls.Add(this.lblTitA2);
            this.Controls.Add(this.lblVeredictoA1);
            this.Controls.Add(this.lblTitA1);
            this.Controls.Add(this.txtTraza);
            this.Controls.Add(this.lblTrazaTitulo);
            this.Controls.Add(this.btnProbar);
            this.Controls.Add(this.txtCadena);
            this.Controls.Add(this.lblCadena);
            this.Name = "FormPruebaCadenas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prueba de cadenas";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblCadena;
        private System.Windows.Forms.TextBox txtCadena;
        private System.Windows.Forms.Button btnProbar;
        private System.Windows.Forms.Label lblTrazaTitulo;
        private System.Windows.Forms.TextBox txtTraza;
        private System.Windows.Forms.Label lblTitA1;
        private System.Windows.Forms.Label lblVeredictoA1;
        private System.Windows.Forms.Label lblTitA2;
        private System.Windows.Forms.Label lblVeredictoA2;
        private System.Windows.Forms.Label lblTitUnion;
        private System.Windows.Forms.Label lblVeredictoUnion;
    }
}