namespace Registracija.UI
{
    partial class KlubForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNaziv = new System.Windows.Forms.Label();
            this.lblMesto = new System.Windows.Forms.Label();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAdresa = new System.Windows.Forms.TextBox();
            this.lblTelefon1 = new System.Windows.Forms.Label();
            this.txtTelefon1 = new System.Windows.Forms.TextBox();
            this.lblTelefon2 = new System.Windows.Forms.Label();
            this.txtTelefon2 = new System.Windows.Forms.TextBox();
            this.txtMesto = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(150, 397);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(242, 397);
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Location = new System.Drawing.Point(18, 24);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(73, 13);
            this.lblNaziv.TabIndex = 2;
            this.lblNaziv.Text = "Naziv kluba  *";
            // 
            // lblMesto
            // 
            this.lblMesto.AutoSize = true;
            this.lblMesto.Location = new System.Drawing.Point(18, 83);
            this.lblMesto.Name = "lblMesto";
            this.lblMesto.Size = new System.Drawing.Size(46, 13);
            this.lblMesto.TabIndex = 6;
            this.lblMesto.Text = "Mesto  *";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(20, 40);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(274, 20);
            this.txtNaziv.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Adresa";
            // 
            // txtAdresa
            // 
            this.txtAdresa.Location = new System.Drawing.Point(21, 163);
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.Size = new System.Drawing.Size(273, 20);
            this.txtAdresa.TabIndex = 10;
            // 
            // lblTelefon1
            // 
            this.lblTelefon1.AutoSize = true;
            this.lblTelefon1.Location = new System.Drawing.Point(17, 208);
            this.lblTelefon1.Name = "lblTelefon1";
            this.lblTelefon1.Size = new System.Drawing.Size(52, 13);
            this.lblTelefon1.TabIndex = 11;
            this.lblTelefon1.Text = "Telefon 1";
            // 
            // txtTelefon1
            // 
            this.txtTelefon1.Location = new System.Drawing.Point(20, 224);
            this.txtTelefon1.Name = "txtTelefon1";
            this.txtTelefon1.Size = new System.Drawing.Size(100, 20);
            this.txtTelefon1.TabIndex = 12;
            // 
            // lblTelefon2
            // 
            this.lblTelefon2.AutoSize = true;
            this.lblTelefon2.Location = new System.Drawing.Point(17, 262);
            this.lblTelefon2.Name = "lblTelefon2";
            this.lblTelefon2.Size = new System.Drawing.Size(52, 13);
            this.lblTelefon2.TabIndex = 13;
            this.lblTelefon2.Text = "Telefon 2";
            // 
            // txtTelefon2
            // 
            this.txtTelefon2.Location = new System.Drawing.Point(21, 278);
            this.txtTelefon2.Name = "txtTelefon2";
            this.txtTelefon2.Size = new System.Drawing.Size(100, 20);
            this.txtTelefon2.TabIndex = 14;
            // 
            // txtMesto
            // 
            this.txtMesto.Location = new System.Drawing.Point(20, 99);
            this.txtMesto.Name = "txtMesto";
            this.txtMesto.Size = new System.Drawing.Size(126, 20);
            this.txtMesto.TabIndex = 7;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(17, 319);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(34, 13);
            this.lblEmail.TabIndex = 15;
            this.lblEmail.Text = "e-mail";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(20, 335);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(160, 20);
            this.txtEmail.TabIndex = 16;
            // 
            // KlubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(329, 432);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtMesto);
            this.Controls.Add(this.txtTelefon2);
            this.Controls.Add(this.lblTelefon2);
            this.Controls.Add(this.txtTelefon1);
            this.Controls.Add(this.lblTelefon1);
            this.Controls.Add(this.txtAdresa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.lblMesto);
            this.Controls.Add(this.lblNaziv);
            this.Name = "KlubForm";
            this.Shown += new System.EventHandler(this.KlubForm_Shown);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblNaziv, 0);
            this.Controls.SetChildIndex(this.lblMesto, 0);
            this.Controls.SetChildIndex(this.txtNaziv, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtAdresa, 0);
            this.Controls.SetChildIndex(this.lblTelefon1, 0);
            this.Controls.SetChildIndex(this.txtTelefon1, 0);
            this.Controls.SetChildIndex(this.lblTelefon2, 0);
            this.Controls.SetChildIndex(this.txtTelefon2, 0);
            this.Controls.SetChildIndex(this.txtMesto, 0);
            this.Controls.SetChildIndex(this.lblEmail, 0);
            this.Controls.SetChildIndex(this.txtEmail, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNaziv;
        private System.Windows.Forms.Label lblMesto;
        protected System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAdresa;
        private System.Windows.Forms.Label lblTelefon1;
        private System.Windows.Forms.TextBox txtTelefon1;
        private System.Windows.Forms.Label lblTelefon2;
        private System.Windows.Forms.TextBox txtTelefon2;
        private System.Windows.Forms.TextBox txtMesto;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;

    }
}
