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
            this.lblKod = new System.Windows.Forms.Label();
            this.lblMesto = new System.Windows.Forms.Label();
            this.txtKod = new System.Windows.Forms.TextBox();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAdresa = new System.Windows.Forms.TextBox();
            this.lblTelefon1 = new System.Windows.Forms.Label();
            this.txtTelefon1 = new System.Windows.Forms.TextBox();
            this.lblTelefon2 = new System.Windows.Forms.Label();
            this.txtTelefon2 = new System.Windows.Forms.TextBox();
            this.txtMesto = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(144, 378);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(236, 378);
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Location = new System.Drawing.Point(25, 19);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(73, 13);
            this.lblNaziv.TabIndex = 2;
            this.lblNaziv.Text = "Naziv kluba  *";
            // 
            // lblKod
            // 
            this.lblKod.AutoSize = true;
            this.lblKod.Location = new System.Drawing.Point(24, 74);
            this.lblKod.Name = "lblKod";
            this.lblKod.Size = new System.Drawing.Size(80, 13);
            this.lblKod.TabIndex = 4;
            this.lblKod.Text = "Skraceni kod  *";
            // 
            // lblMesto
            // 
            this.lblMesto.AutoSize = true;
            this.lblMesto.Location = new System.Drawing.Point(25, 130);
            this.lblMesto.Name = "lblMesto";
            this.lblMesto.Size = new System.Drawing.Size(46, 13);
            this.lblMesto.TabIndex = 6;
            this.lblMesto.Text = "Mesto  *";
            // 
            // txtKod
            // 
            this.txtKod.Location = new System.Drawing.Point(27, 90);
            this.txtKod.Name = "txtKod";
            this.txtKod.Size = new System.Drawing.Size(61, 20);
            this.txtKod.TabIndex = 5;
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(27, 35);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(274, 20);
            this.txtNaziv.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Adresa";
            // 
            // txtAdresa
            // 
            this.txtAdresa.Location = new System.Drawing.Point(28, 210);
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.Size = new System.Drawing.Size(273, 20);
            this.txtAdresa.TabIndex = 10;
            // 
            // lblTelefon1
            // 
            this.lblTelefon1.AutoSize = true;
            this.lblTelefon1.Location = new System.Drawing.Point(24, 255);
            this.lblTelefon1.Name = "lblTelefon1";
            this.lblTelefon1.Size = new System.Drawing.Size(52, 13);
            this.lblTelefon1.TabIndex = 11;
            this.lblTelefon1.Text = "Telefon 1";
            // 
            // txtTelefon1
            // 
            this.txtTelefon1.Location = new System.Drawing.Point(27, 271);
            this.txtTelefon1.Name = "txtTelefon1";
            this.txtTelefon1.Size = new System.Drawing.Size(100, 20);
            this.txtTelefon1.TabIndex = 12;
            // 
            // lblTelefon2
            // 
            this.lblTelefon2.AutoSize = true;
            this.lblTelefon2.Location = new System.Drawing.Point(24, 309);
            this.lblTelefon2.Name = "lblTelefon2";
            this.lblTelefon2.Size = new System.Drawing.Size(52, 13);
            this.lblTelefon2.TabIndex = 13;
            this.lblTelefon2.Text = "Telefon 2";
            // 
            // txtTelefon2
            // 
            this.txtTelefon2.Location = new System.Drawing.Point(28, 325);
            this.txtTelefon2.Name = "txtTelefon2";
            this.txtTelefon2.Size = new System.Drawing.Size(100, 20);
            this.txtTelefon2.TabIndex = 14;
            // 
            // txtMesto
            // 
            this.txtMesto.Location = new System.Drawing.Point(27, 146);
            this.txtMesto.Name = "txtMesto";
            this.txtMesto.Size = new System.Drawing.Size(126, 20);
            this.txtMesto.TabIndex = 15;
            // 
            // KlubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(329, 416);
            this.Controls.Add(this.txtMesto);
            this.Controls.Add(this.txtTelefon2);
            this.Controls.Add(this.lblTelefon2);
            this.Controls.Add(this.txtTelefon1);
            this.Controls.Add(this.lblTelefon1);
            this.Controls.Add(this.txtAdresa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.txtKod);
            this.Controls.Add(this.lblMesto);
            this.Controls.Add(this.lblKod);
            this.Controls.Add(this.lblNaziv);
            this.Name = "KlubForm";
            this.Shown += new System.EventHandler(this.KlubForm_Shown);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblNaziv, 0);
            this.Controls.SetChildIndex(this.lblKod, 0);
            this.Controls.SetChildIndex(this.lblMesto, 0);
            this.Controls.SetChildIndex(this.txtKod, 0);
            this.Controls.SetChildIndex(this.txtNaziv, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtAdresa, 0);
            this.Controls.SetChildIndex(this.lblTelefon1, 0);
            this.Controls.SetChildIndex(this.txtTelefon1, 0);
            this.Controls.SetChildIndex(this.lblTelefon2, 0);
            this.Controls.SetChildIndex(this.txtTelefon2, 0);
            this.Controls.SetChildIndex(this.txtMesto, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNaziv;
        private System.Windows.Forms.Label lblKod;
        private System.Windows.Forms.Label lblMesto;
        protected System.Windows.Forms.TextBox txtKod;
        protected System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAdresa;
        private System.Windows.Forms.Label lblTelefon1;
        private System.Windows.Forms.TextBox txtTelefon1;
        private System.Windows.Forms.Label lblTelefon2;
        private System.Windows.Forms.TextBox txtTelefon2;
        private System.Windows.Forms.TextBox txtMesto;

    }
}
