namespace Registracija.UI
{
    partial class GimnasticarForm
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
            this.txtIme = new System.Windows.Forms.TextBox();
            this.lblIme = new System.Windows.Forms.Label();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.lblDatRodj = new System.Windows.Forms.Label();
            this.txtDatRodj = new System.Windows.Forms.TextBox();
            this.lblRegBroj = new System.Windows.Forms.Label();
            this.txtRegBroj = new System.Windows.Forms.TextBox();
            this.lblDatumPoslReg = new System.Windows.Forms.Label();
            this.txtDatumPoslReg = new System.Windows.Forms.TextBox();
            this.lblGimnastika = new System.Windows.Forms.Label();
            this.cmbGimnastika = new System.Windows.Forms.ComboBox();
            this.lblKategorija = new System.Windows.Forms.Label();
            this.cmbKategorija = new System.Windows.Forms.ComboBox();
            this.lblKlub = new System.Windows.Forms.Label();
            this.cmbKlub = new System.Windows.Forms.ComboBox();
            this.btnAddKlub = new System.Windows.Forms.Button();
            this.btnAddKategorija = new System.Windows.Forms.Button();
            this.lblSrednjeIme = new System.Windows.Forms.Label();
            this.txtSrednjeIme = new System.Windows.Forms.TextBox();
            this.lblJMBG = new System.Windows.Forms.Label();
            this.txtJMBG = new System.Windows.Forms.TextBox();
            this.lblMesto = new System.Windows.Forms.Label();
            this.txtMesto = new System.Windows.Forms.TextBox();
            this.lblAdresa = new System.Windows.Forms.Label();
            this.txtAdresa = new System.Windows.Forms.TextBox();
            this.lblTelefon1 = new System.Windows.Forms.Label();
            this.txtTelefon1 = new System.Windows.Forms.TextBox();
            this.lblTelefon2 = new System.Windows.Forms.Label();
            this.txtTelefon2 = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(406, 495);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(498, 495);
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(24, 36);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(100, 20);
            this.txtIme.TabIndex = 3;
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Location = new System.Drawing.Point(21, 20);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(34, 13);
            this.lblIme.TabIndex = 2;
            this.lblIme.Text = "Ime  *";
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Location = new System.Drawing.Point(224, 20);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(54, 13);
            this.lblPrezime.TabIndex = 4;
            this.lblPrezime.Text = "Prezime  *";
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(227, 36);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(167, 20);
            this.txtPrezime.TabIndex = 5;
            this.txtPrezime.Enter += new System.EventHandler(this.txtPrezime_Enter);
            this.txtPrezime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrezime_KeyDown);
            // 
            // lblDatRodj
            // 
            this.lblDatRodj.AutoSize = true;
            this.lblDatRodj.Location = new System.Drawing.Point(21, 69);
            this.lblDatRodj.Name = "lblDatRodj";
            this.lblDatRodj.Size = new System.Drawing.Size(122, 13);
            this.lblDatRodj.TabIndex = 8;
            this.lblDatRodj.Text = "Datum ili godina rodjenja";
            // 
            // txtDatRodj
            // 
            this.txtDatRodj.Location = new System.Drawing.Point(24, 85);
            this.txtDatRodj.Name = "txtDatRodj";
            this.txtDatRodj.Size = new System.Drawing.Size(100, 20);
            this.txtDatRodj.TabIndex = 9;
            // 
            // lblRegBroj
            // 
            this.lblRegBroj.AutoSize = true;
            this.lblRegBroj.Location = new System.Drawing.Point(21, 126);
            this.lblRegBroj.Name = "lblRegBroj";
            this.lblRegBroj.Size = new System.Drawing.Size(79, 13);
            this.lblRegBroj.TabIndex = 12;
            this.lblRegBroj.Text = "Registarski broj";
            // 
            // txtRegBroj
            // 
            this.txtRegBroj.Location = new System.Drawing.Point(24, 142);
            this.txtRegBroj.Name = "txtRegBroj";
            this.txtRegBroj.Size = new System.Drawing.Size(85, 20);
            this.txtRegBroj.TabIndex = 13;
            // 
            // lblDatumPoslReg
            // 
            this.lblDatumPoslReg.AutoSize = true;
            this.lblDatumPoslReg.Location = new System.Drawing.Point(128, 126);
            this.lblDatumPoslReg.Name = "lblDatumPoslReg";
            this.lblDatumPoslReg.Size = new System.Drawing.Size(183, 13);
            this.lblDatumPoslReg.TabIndex = 16;
            this.lblDatumPoslReg.Text = "Datum ili godina poslednje registracije";
            // 
            // txtDatumPoslReg
            // 
            this.txtDatumPoslReg.Location = new System.Drawing.Point(131, 142);
            this.txtDatumPoslReg.Name = "txtDatumPoslReg";
            this.txtDatumPoslReg.Size = new System.Drawing.Size(100, 20);
            this.txtDatumPoslReg.TabIndex = 17;
            // 
            // lblGimnastika
            // 
            this.lblGimnastika.AutoSize = true;
            this.lblGimnastika.Location = new System.Drawing.Point(412, 20);
            this.lblGimnastika.Name = "lblGimnastika";
            this.lblGimnastika.Size = new System.Drawing.Size(69, 13);
            this.lblGimnastika.TabIndex = 6;
            this.lblGimnastika.Text = "Gimnastika  *";
            // 
            // cmbGimnastika
            // 
            this.cmbGimnastika.FormattingEnabled = true;
            this.cmbGimnastika.Location = new System.Drawing.Point(415, 36);
            this.cmbGimnastika.Name = "cmbGimnastika";
            this.cmbGimnastika.Size = new System.Drawing.Size(79, 21);
            this.cmbGimnastika.TabIndex = 7;
            this.cmbGimnastika.SelectedIndexChanged += new System.EventHandler(this.cmbGimnastika_SelectedIndexChanged);
            // 
            // lblKategorija
            // 
            this.lblKategorija.AutoSize = true;
            this.lblKategorija.Location = new System.Drawing.Point(21, 232);
            this.lblKategorija.Name = "lblKategorija";
            this.lblKategorija.Size = new System.Drawing.Size(54, 13);
            this.lblKategorija.TabIndex = 20;
            this.lblKategorija.Text = "Kategorija";
            // 
            // cmbKategorija
            // 
            this.cmbKategorija.FormattingEnabled = true;
            this.cmbKategorija.Location = new System.Drawing.Point(24, 248);
            this.cmbKategorija.Name = "cmbKategorija";
            this.cmbKategorija.Size = new System.Drawing.Size(207, 21);
            this.cmbKategorija.TabIndex = 21;
            this.cmbKategorija.DropDown += new System.EventHandler(this.cmbKategorija_DropDown);
            // 
            // lblKlub
            // 
            this.lblKlub.AutoSize = true;
            this.lblKlub.Location = new System.Drawing.Point(21, 179);
            this.lblKlub.Name = "lblKlub";
            this.lblKlub.Size = new System.Drawing.Size(28, 13);
            this.lblKlub.TabIndex = 18;
            this.lblKlub.Text = "Klub";
            // 
            // cmbKlub
            // 
            this.cmbKlub.FormattingEnabled = true;
            this.cmbKlub.Location = new System.Drawing.Point(24, 195);
            this.cmbKlub.Name = "cmbKlub";
            this.cmbKlub.Size = new System.Drawing.Size(207, 21);
            this.cmbKlub.TabIndex = 19;
            // 
            // btnAddKlub
            // 
            this.btnAddKlub.Location = new System.Drawing.Point(237, 194);
            this.btnAddKlub.Name = "btnAddKlub";
            this.btnAddKlub.Size = new System.Drawing.Size(24, 23);
            this.btnAddKlub.TabIndex = 24;
            this.btnAddKlub.Text = "...";
            this.btnAddKlub.UseVisualStyleBackColor = true;
            this.btnAddKlub.Click += new System.EventHandler(this.btnAddKlub_Click);
            // 
            // btnAddKategorija
            // 
            this.btnAddKategorija.Location = new System.Drawing.Point(237, 247);
            this.btnAddKategorija.Name = "btnAddKategorija";
            this.btnAddKategorija.Size = new System.Drawing.Size(25, 23);
            this.btnAddKategorija.TabIndex = 25;
            this.btnAddKategorija.Text = "...";
            this.btnAddKategorija.UseVisualStyleBackColor = true;
            this.btnAddKategorija.Click += new System.EventHandler(this.btnAddKategorija_Click);
            // 
            // lblSrednjeIme
            // 
            this.lblSrednjeIme.AutoSize = true;
            this.lblSrednjeIme.Location = new System.Drawing.Point(141, 21);
            this.lblSrednjeIme.Name = "lblSrednjeIme";
            this.lblSrednjeIme.Size = new System.Drawing.Size(62, 13);
            this.lblSrednjeIme.TabIndex = 26;
            this.lblSrednjeIme.Text = "Srednje ime";
            // 
            // txtSrednjeIme
            // 
            this.txtSrednjeIme.Location = new System.Drawing.Point(144, 37);
            this.txtSrednjeIme.Name = "txtSrednjeIme";
            this.txtSrednjeIme.Size = new System.Drawing.Size(59, 20);
            this.txtSrednjeIme.TabIndex = 27;
            // 
            // lblJMBG
            // 
            this.lblJMBG.AutoSize = true;
            this.lblJMBG.Location = new System.Drawing.Point(175, 69);
            this.lblJMBG.Name = "lblJMBG";
            this.lblJMBG.Size = new System.Drawing.Size(36, 13);
            this.lblJMBG.TabIndex = 28;
            this.lblJMBG.Text = "JMBG";
            // 
            // txtJMBG
            // 
            this.txtJMBG.Location = new System.Drawing.Point(178, 85);
            this.txtJMBG.Name = "txtJMBG";
            this.txtJMBG.Size = new System.Drawing.Size(133, 20);
            this.txtJMBG.TabIndex = 29;
            // 
            // lblMesto
            // 
            this.lblMesto.AutoSize = true;
            this.lblMesto.Location = new System.Drawing.Point(21, 295);
            this.lblMesto.Name = "lblMesto";
            this.lblMesto.Size = new System.Drawing.Size(91, 13);
            this.lblMesto.TabIndex = 30;
            this.lblMesto.Text = "Mesto stanovanja";
            // 
            // txtMesto
            // 
            this.txtMesto.Location = new System.Drawing.Point(24, 311);
            this.txtMesto.Name = "txtMesto";
            this.txtMesto.Size = new System.Drawing.Size(88, 20);
            this.txtMesto.TabIndex = 31;
            // 
            // lblAdresa
            // 
            this.lblAdresa.AutoSize = true;
            this.lblAdresa.Location = new System.Drawing.Point(131, 295);
            this.lblAdresa.Name = "lblAdresa";
            this.lblAdresa.Size = new System.Drawing.Size(40, 13);
            this.lblAdresa.TabIndex = 32;
            this.lblAdresa.Text = "Adresa";
            // 
            // txtAdresa
            // 
            this.txtAdresa.Location = new System.Drawing.Point(131, 311);
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.Size = new System.Drawing.Size(204, 20);
            this.txtAdresa.TabIndex = 33;
            // 
            // lblTelefon1
            // 
            this.lblTelefon1.AutoSize = true;
            this.lblTelefon1.Location = new System.Drawing.Point(356, 295);
            this.lblTelefon1.Name = "lblTelefon1";
            this.lblTelefon1.Size = new System.Drawing.Size(52, 13);
            this.lblTelefon1.TabIndex = 34;
            this.lblTelefon1.Text = "Telefon 1";
            // 
            // txtTelefon1
            // 
            this.txtTelefon1.Location = new System.Drawing.Point(359, 311);
            this.txtTelefon1.Name = "txtTelefon1";
            this.txtTelefon1.Size = new System.Drawing.Size(91, 20);
            this.txtTelefon1.TabIndex = 35;
            // 
            // lblTelefon2
            // 
            this.lblTelefon2.AutoSize = true;
            this.lblTelefon2.Location = new System.Drawing.Point(466, 295);
            this.lblTelefon2.Name = "lblTelefon2";
            this.lblTelefon2.Size = new System.Drawing.Size(52, 13);
            this.lblTelefon2.TabIndex = 36;
            this.lblTelefon2.Text = "Telefon 2";
            // 
            // txtTelefon2
            // 
            this.txtTelefon2.Location = new System.Drawing.Point(469, 311);
            this.txtTelefon2.Name = "txtTelefon2";
            this.txtTelefon2.Size = new System.Drawing.Size(88, 20);
            this.txtTelefon2.TabIndex = 37;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(21, 348);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(34, 13);
            this.lblEmail.TabIndex = 38;
            this.lblEmail.Text = "e-mail";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(24, 364);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 39;
            // 
            // GimnasticarForm
            // 
            this.AcceptButton = null;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 530);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtTelefon2);
            this.Controls.Add(this.lblTelefon2);
            this.Controls.Add(this.txtTelefon1);
            this.Controls.Add(this.lblTelefon1);
            this.Controls.Add(this.txtAdresa);
            this.Controls.Add(this.lblAdresa);
            this.Controls.Add(this.txtMesto);
            this.Controls.Add(this.lblMesto);
            this.Controls.Add(this.txtJMBG);
            this.Controls.Add(this.lblJMBG);
            this.Controls.Add(this.btnAddKategorija);
            this.Controls.Add(this.btnAddKlub);
            this.Controls.Add(this.txtSrednjeIme);
            this.Controls.Add(this.lblSrednjeIme);
            this.Controls.Add(this.cmbKlub);
            this.Controls.Add(this.lblKlub);
            this.Controls.Add(this.cmbKategorija);
            this.Controls.Add(this.lblKategorija);
            this.Controls.Add(this.cmbGimnastika);
            this.Controls.Add(this.lblGimnastika);
            this.Controls.Add(this.txtDatumPoslReg);
            this.Controls.Add(this.lblDatumPoslReg);
            this.Controls.Add(this.txtRegBroj);
            this.Controls.Add(this.lblRegBroj);
            this.Controls.Add(this.txtDatRodj);
            this.Controls.Add(this.lblDatRodj);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.lblIme);
            this.Controls.Add(this.lblPrezime);
            this.Name = "GimnasticarForm";
            this.Text = "GimnasticarForm";
            this.Shown += new System.EventHandler(this.GimnasticarForm_Shown);
            this.Controls.SetChildIndex(this.lblPrezime, 0);
            this.Controls.SetChildIndex(this.lblIme, 0);
            this.Controls.SetChildIndex(this.txtPrezime, 0);
            this.Controls.SetChildIndex(this.txtIme, 0);
            this.Controls.SetChildIndex(this.lblDatRodj, 0);
            this.Controls.SetChildIndex(this.txtDatRodj, 0);
            this.Controls.SetChildIndex(this.lblRegBroj, 0);
            this.Controls.SetChildIndex(this.txtRegBroj, 0);
            this.Controls.SetChildIndex(this.lblDatumPoslReg, 0);
            this.Controls.SetChildIndex(this.txtDatumPoslReg, 0);
            this.Controls.SetChildIndex(this.lblGimnastika, 0);
            this.Controls.SetChildIndex(this.cmbGimnastika, 0);
            this.Controls.SetChildIndex(this.lblKategorija, 0);
            this.Controls.SetChildIndex(this.cmbKategorija, 0);
            this.Controls.SetChildIndex(this.lblKlub, 0);
            this.Controls.SetChildIndex(this.cmbKlub, 0);
            this.Controls.SetChildIndex(this.lblSrednjeIme, 0);
            this.Controls.SetChildIndex(this.txtSrednjeIme, 0);
            this.Controls.SetChildIndex(this.btnAddKlub, 0);
            this.Controls.SetChildIndex(this.btnAddKategorija, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblJMBG, 0);
            this.Controls.SetChildIndex(this.txtJMBG, 0);
            this.Controls.SetChildIndex(this.lblMesto, 0);
            this.Controls.SetChildIndex(this.txtMesto, 0);
            this.Controls.SetChildIndex(this.lblAdresa, 0);
            this.Controls.SetChildIndex(this.txtAdresa, 0);
            this.Controls.SetChildIndex(this.lblTelefon1, 0);
            this.Controls.SetChildIndex(this.txtTelefon1, 0);
            this.Controls.SetChildIndex(this.lblTelefon2, 0);
            this.Controls.SetChildIndex(this.txtTelefon2, 0);
            this.Controls.SetChildIndex(this.lblEmail, 0);
            this.Controls.SetChildIndex(this.txtEmail, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Label lblDatRodj;
        private System.Windows.Forms.TextBox txtDatRodj;
        private System.Windows.Forms.Label lblRegBroj;
        private System.Windows.Forms.TextBox txtRegBroj;
        private System.Windows.Forms.Label lblDatumPoslReg;
        private System.Windows.Forms.TextBox txtDatumPoslReg;
        private System.Windows.Forms.Label lblGimnastika;
        private System.Windows.Forms.ComboBox cmbGimnastika;
        private System.Windows.Forms.Label lblKategorija;
        private System.Windows.Forms.ComboBox cmbKategorija;
        private System.Windows.Forms.Label lblKlub;
        private System.Windows.Forms.ComboBox cmbKlub;
        private System.Windows.Forms.Button btnAddKlub;
        private System.Windows.Forms.Button btnAddKategorija;
        private System.Windows.Forms.Label lblSrednjeIme;
        private System.Windows.Forms.TextBox txtSrednjeIme;
        private System.Windows.Forms.Label lblJMBG;
        private System.Windows.Forms.TextBox txtJMBG;
        private System.Windows.Forms.Label lblMesto;
        private System.Windows.Forms.TextBox txtMesto;
        private System.Windows.Forms.Label lblAdresa;
        private System.Windows.Forms.TextBox txtAdresa;
        private System.Windows.Forms.Label lblTelefon1;
        private System.Windows.Forms.TextBox txtTelefon1;
        private System.Windows.Forms.Label lblTelefon2;
        private System.Windows.Forms.TextBox txtTelefon2;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
    }
}