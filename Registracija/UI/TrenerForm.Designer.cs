namespace Registracija.UI
{
    partial class TrenerForm
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
            this.lblIme = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.lblPol = new System.Windows.Forms.Label();
            this.cmbPol = new System.Windows.Forms.ComboBox();
            this.btnAddKlub = new System.Windows.Forms.Button();
            this.cmbKlub = new System.Windows.Forms.ComboBox();
            this.lblKlub = new System.Windows.Forms.Label();
            this.lblDatumRodjenja = new System.Windows.Forms.Label();
            this.txtDatRodj = new System.Windows.Forms.TextBox();
            this.lblJMBG = new System.Windows.Forms.Label();
            this.txtJMBG = new System.Windows.Forms.TextBox();
            this.lblRegBroj = new System.Windows.Forms.Label();
            this.txtRegBroj = new System.Windows.Forms.TextBox();
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
            this.lblFoto = new System.Windows.Forms.Label();
            this.txtFoto = new System.Windows.Forms.TextBox();
            this.btnDodajFoto = new System.Windows.Forms.Button();
            this.btnPrikaziFoto = new System.Windows.Forms.Button();
            this.lblIzvodMKR = new System.Windows.Forms.Label();
            this.txtIzvodMKR = new System.Windows.Forms.TextBox();
            this.btnDodajIzvodMKR = new System.Windows.Forms.Button();
            this.btnPrikaziIzvodMKR = new System.Windows.Forms.Button();
            this.lblVrstaTrenerskogAngazmana = new System.Windows.Forms.Label();
            this.cmbVrstaTrenerskogAngazmana = new System.Windows.Forms.ComboBox();
            this.lblNazivFakulteta = new System.Windows.Forms.Label();
            this.txtNazivFakulteta = new System.Windows.Forms.TextBox();
            this.lblRedovnoZanimanje = new System.Windows.Forms.Label();
            this.txtRedovnoZanimanje = new System.Windows.Forms.TextBox();
            this.lblGodinaPocetkaTrenerskogRada = new System.Windows.Forms.Label();
            this.txtGodinaPocetkaTrenerskogRada = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(722, 500);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(814, 500);
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Location = new System.Drawing.Point(12, 20);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(34, 13);
            this.lblIme.TabIndex = 2;
            this.lblIme.Text = "Ime  *";
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(12, 36);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(100, 20);
            this.txtIme.TabIndex = 3;
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Location = new System.Drawing.Point(129, 20);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(54, 13);
            this.lblPrezime.TabIndex = 4;
            this.lblPrezime.Text = "Prezime  *";
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(132, 36);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(100, 20);
            this.txtPrezime.TabIndex = 5;
            // 
            // lblPol
            // 
            this.lblPol.AutoSize = true;
            this.lblPol.Location = new System.Drawing.Point(255, 20);
            this.lblPol.Name = "lblPol";
            this.lblPol.Size = new System.Drawing.Size(32, 13);
            this.lblPol.TabIndex = 6;
            this.lblPol.Text = "Pol  *";
            // 
            // cmbPol
            // 
            this.cmbPol.FormattingEnabled = true;
            this.cmbPol.Location = new System.Drawing.Point(255, 36);
            this.cmbPol.Name = "cmbPol";
            this.cmbPol.Size = new System.Drawing.Size(68, 21);
            this.cmbPol.TabIndex = 7;
            // 
            // btnAddKlub
            // 
            this.btnAddKlub.Location = new System.Drawing.Point(225, 191);
            this.btnAddKlub.Name = "btnAddKlub";
            this.btnAddKlub.Size = new System.Drawing.Size(24, 23);
            this.btnAddKlub.TabIndex = 34;
            this.btnAddKlub.Text = "...";
            this.btnAddKlub.UseVisualStyleBackColor = true;
            this.btnAddKlub.Click += new System.EventHandler(this.btnAddKlub_Click);
            // 
            // cmbKlub
            // 
            this.cmbKlub.FormattingEnabled = true;
            this.cmbKlub.Location = new System.Drawing.Point(12, 192);
            this.cmbKlub.Name = "cmbKlub";
            this.cmbKlub.Size = new System.Drawing.Size(207, 21);
            this.cmbKlub.TabIndex = 33;
            // 
            // lblKlub
            // 
            this.lblKlub.AutoSize = true;
            this.lblKlub.Location = new System.Drawing.Point(9, 176);
            this.lblKlub.Name = "lblKlub";
            this.lblKlub.Size = new System.Drawing.Size(28, 13);
            this.lblKlub.TabIndex = 25;
            this.lblKlub.Text = "Klub";
            // 
            // lblDatumRodjenja
            // 
            this.lblDatumRodjenja.AutoSize = true;
            this.lblDatumRodjenja.Location = new System.Drawing.Point(12, 74);
            this.lblDatumRodjenja.Name = "lblDatumRodjenja";
            this.lblDatumRodjenja.Size = new System.Drawing.Size(78, 13);
            this.lblDatumRodjenja.TabIndex = 28;
            this.lblDatumRodjenja.Text = "Datum rodjenja";
            // 
            // txtDatRodj
            // 
            this.txtDatRodj.Location = new System.Drawing.Point(15, 90);
            this.txtDatRodj.Name = "txtDatRodj";
            this.txtDatRodj.Size = new System.Drawing.Size(100, 20);
            this.txtDatRodj.TabIndex = 29;
            // 
            // lblJMBG
            // 
            this.lblJMBG.AutoSize = true;
            this.lblJMBG.Location = new System.Drawing.Point(148, 74);
            this.lblJMBG.Name = "lblJMBG";
            this.lblJMBG.Size = new System.Drawing.Size(36, 13);
            this.lblJMBG.TabIndex = 30;
            this.lblJMBG.Text = "JMBG";
            // 
            // txtJMBG
            // 
            this.txtJMBG.Location = new System.Drawing.Point(149, 90);
            this.txtJMBG.Name = "txtJMBG";
            this.txtJMBG.Size = new System.Drawing.Size(100, 20);
            this.txtJMBG.TabIndex = 31;
            // 
            // lblRegBroj
            // 
            this.lblRegBroj.AutoSize = true;
            this.lblRegBroj.Location = new System.Drawing.Point(12, 126);
            this.lblRegBroj.Name = "lblRegBroj";
            this.lblRegBroj.Size = new System.Drawing.Size(88, 13);
            this.lblRegBroj.TabIndex = 32;
            this.lblRegBroj.Text = "Registracioni broj";
            // 
            // txtRegBroj
            // 
            this.txtRegBroj.Location = new System.Drawing.Point(15, 142);
            this.txtRegBroj.Name = "txtRegBroj";
            this.txtRegBroj.Size = new System.Drawing.Size(100, 20);
            this.txtRegBroj.TabIndex = 32;
            // 
            // lblMesto
            // 
            this.lblMesto.AutoSize = true;
            this.lblMesto.Location = new System.Drawing.Point(12, 241);
            this.lblMesto.Name = "lblMesto";
            this.lblMesto.Size = new System.Drawing.Size(91, 13);
            this.lblMesto.TabIndex = 34;
            this.lblMesto.Text = "Mesto stanovanja";
            // 
            // txtMesto
            // 
            this.txtMesto.Location = new System.Drawing.Point(12, 257);
            this.txtMesto.Name = "txtMesto";
            this.txtMesto.Size = new System.Drawing.Size(100, 20);
            this.txtMesto.TabIndex = 35;
            // 
            // lblAdresa
            // 
            this.lblAdresa.AutoSize = true;
            this.lblAdresa.Location = new System.Drawing.Point(132, 241);
            this.lblAdresa.Name = "lblAdresa";
            this.lblAdresa.Size = new System.Drawing.Size(40, 13);
            this.lblAdresa.TabIndex = 36;
            this.lblAdresa.Text = "Adresa";
            // 
            // txtAdresa
            // 
            this.txtAdresa.Location = new System.Drawing.Point(132, 257);
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.Size = new System.Drawing.Size(170, 20);
            this.txtAdresa.TabIndex = 37;
            // 
            // lblTelefon1
            // 
            this.lblTelefon1.AutoSize = true;
            this.lblTelefon1.Location = new System.Drawing.Point(326, 241);
            this.lblTelefon1.Name = "lblTelefon1";
            this.lblTelefon1.Size = new System.Drawing.Size(52, 13);
            this.lblTelefon1.TabIndex = 38;
            this.lblTelefon1.Text = "Telefon 1";
            // 
            // txtTelefon1
            // 
            this.txtTelefon1.Location = new System.Drawing.Point(329, 257);
            this.txtTelefon1.Name = "txtTelefon1";
            this.txtTelefon1.Size = new System.Drawing.Size(80, 20);
            this.txtTelefon1.TabIndex = 39;
            // 
            // lblTelefon2
            // 
            this.lblTelefon2.AutoSize = true;
            this.lblTelefon2.Location = new System.Drawing.Point(432, 241);
            this.lblTelefon2.Name = "lblTelefon2";
            this.lblTelefon2.Size = new System.Drawing.Size(52, 13);
            this.lblTelefon2.TabIndex = 40;
            this.lblTelefon2.Text = "Telefon 2";
            // 
            // txtTelefon2
            // 
            this.txtTelefon2.Location = new System.Drawing.Point(435, 257);
            this.txtTelefon2.Name = "txtTelefon2";
            this.txtTelefon2.Size = new System.Drawing.Size(76, 20);
            this.txtTelefon2.TabIndex = 41;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(12, 300);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(34, 13);
            this.lblEmail.TabIndex = 42;
            this.lblEmail.Text = "e-mail";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(15, 316);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(157, 20);
            this.txtEmail.TabIndex = 43;
            // 
            // lblFoto
            // 
            this.lblFoto.AutoSize = true;
            this.lblFoto.Location = new System.Drawing.Point(12, 359);
            this.lblFoto.Name = "lblFoto";
            this.lblFoto.Size = new System.Drawing.Size(56, 13);
            this.lblFoto.TabIndex = 44;
            this.lblFoto.Text = "Fotografija";
            // 
            // txtFoto
            // 
            this.txtFoto.Location = new System.Drawing.Point(15, 375);
            this.txtFoto.Name = "txtFoto";
            this.txtFoto.Size = new System.Drawing.Size(157, 20);
            this.txtFoto.TabIndex = 45;
            // 
            // btnDodajFoto
            // 
            this.btnDodajFoto.Location = new System.Drawing.Point(187, 373);
            this.btnDodajFoto.Name = "btnDodajFoto";
            this.btnDodajFoto.Size = new System.Drawing.Size(62, 23);
            this.btnDodajFoto.TabIndex = 46;
            this.btnDodajFoto.Text = "Dodaj";
            this.btnDodajFoto.UseVisualStyleBackColor = true;
            this.btnDodajFoto.Click += new System.EventHandler(this.btnDodajFoto_Click);
            // 
            // btnPrikaziFoto
            // 
            this.btnPrikaziFoto.Location = new System.Drawing.Point(258, 373);
            this.btnPrikaziFoto.Name = "btnPrikaziFoto";
            this.btnPrikaziFoto.Size = new System.Drawing.Size(53, 23);
            this.btnPrikaziFoto.TabIndex = 47;
            this.btnPrikaziFoto.Text = "Prikazi";
            this.btnPrikaziFoto.UseVisualStyleBackColor = true;
            this.btnPrikaziFoto.Click += new System.EventHandler(this.btnPrikaziFoto_Click);
            // 
            // lblIzvodMKR
            // 
            this.lblIzvodMKR.AutoSize = true;
            this.lblIzvodMKR.Location = new System.Drawing.Point(12, 414);
            this.lblIzvodMKR.Name = "lblIzvodMKR";
            this.lblIzvodMKR.Size = new System.Drawing.Size(154, 13);
            this.lblIzvodMKR.TabIndex = 48;
            this.lblIzvodMKR.Text = "Izvod iz maticne knjige rodjenih";
            // 
            // txtIzvodMKR
            // 
            this.txtIzvodMKR.Location = new System.Drawing.Point(12, 430);
            this.txtIzvodMKR.Name = "txtIzvodMKR";
            this.txtIzvodMKR.Size = new System.Drawing.Size(160, 20);
            this.txtIzvodMKR.TabIndex = 49;
            // 
            // btnDodajIzvodMKR
            // 
            this.btnDodajIzvodMKR.Location = new System.Drawing.Point(187, 428);
            this.btnDodajIzvodMKR.Name = "btnDodajIzvodMKR";
            this.btnDodajIzvodMKR.Size = new System.Drawing.Size(62, 23);
            this.btnDodajIzvodMKR.TabIndex = 50;
            this.btnDodajIzvodMKR.Text = "Dodaj";
            this.btnDodajIzvodMKR.UseVisualStyleBackColor = true;
            this.btnDodajIzvodMKR.Click += new System.EventHandler(this.btnDodajIzvodMKR_Click);
            // 
            // btnPrikaziIzvodMKR
            // 
            this.btnPrikaziIzvodMKR.Location = new System.Drawing.Point(258, 427);
            this.btnPrikaziIzvodMKR.Name = "btnPrikaziIzvodMKR";
            this.btnPrikaziIzvodMKR.Size = new System.Drawing.Size(53, 23);
            this.btnPrikaziIzvodMKR.TabIndex = 51;
            this.btnPrikaziIzvodMKR.Text = "Prikazi";
            this.btnPrikaziIzvodMKR.UseVisualStyleBackColor = true;
            this.btnPrikaziIzvodMKR.Click += new System.EventHandler(this.btnPrikaziIzvodMKR_Click);
            // 
            // lblVrstaTrenerskogAngazmana
            // 
            this.lblVrstaTrenerskogAngazmana.AutoSize = true;
            this.lblVrstaTrenerskogAngazmana.Location = new System.Drawing.Point(583, 39);
            this.lblVrstaTrenerskogAngazmana.Name = "lblVrstaTrenerskogAngazmana";
            this.lblVrstaTrenerskogAngazmana.Size = new System.Drawing.Size(142, 13);
            this.lblVrstaTrenerskogAngazmana.TabIndex = 52;
            this.lblVrstaTrenerskogAngazmana.Text = "Vrsta trenerskog angazmana";
            // 
            // cmbVrstaTrenerskogAngazmana
            // 
            this.cmbVrstaTrenerskogAngazmana.FormattingEnabled = true;
            this.cmbVrstaTrenerskogAngazmana.Location = new System.Drawing.Point(586, 55);
            this.cmbVrstaTrenerskogAngazmana.Name = "cmbVrstaTrenerskogAngazmana";
            this.cmbVrstaTrenerskogAngazmana.Size = new System.Drawing.Size(139, 21);
            this.cmbVrstaTrenerskogAngazmana.TabIndex = 53;
            // 
            // lblNazivFakulteta
            // 
            this.lblNazivFakulteta.AutoSize = true;
            this.lblNazivFakulteta.Location = new System.Drawing.Point(583, 94);
            this.lblNazivFakulteta.Name = "lblNazivFakulteta";
            this.lblNazivFakulteta.Size = new System.Drawing.Size(205, 13);
            this.lblNazivFakulteta.TabIndex = 54;
            this.lblNazivFakulteta.Text = "Nacin sticanja trenerskog zvanja - fakultet";
            // 
            // txtNazivFakulteta
            // 
            this.txtNazivFakulteta.Location = new System.Drawing.Point(586, 110);
            this.txtNazivFakulteta.Name = "txtNazivFakulteta";
            this.txtNazivFakulteta.Size = new System.Drawing.Size(278, 20);
            this.txtNazivFakulteta.TabIndex = 55;
            // 
            // lblRedovnoZanimanje
            // 
            this.lblRedovnoZanimanje.AutoSize = true;
            this.lblRedovnoZanimanje.Location = new System.Drawing.Point(583, 149);
            this.lblRedovnoZanimanje.Name = "lblRedovnoZanimanje";
            this.lblRedovnoZanimanje.Size = new System.Drawing.Size(261, 13);
            this.lblRedovnoZanimanje.TabIndex = 56;
            this.lblRedovnoZanimanje.Text = "Redovno zanimanje (za neprofesionalno angazovane)";
            // 
            // txtRedovnoZanimanje
            // 
            this.txtRedovnoZanimanje.Location = new System.Drawing.Point(584, 165);
            this.txtRedovnoZanimanje.Name = "txtRedovnoZanimanje";
            this.txtRedovnoZanimanje.Size = new System.Drawing.Size(280, 20);
            this.txtRedovnoZanimanje.TabIndex = 57;
            // 
            // lblGodinaPocetkaTrenerskogRada
            // 
            this.lblGodinaPocetkaTrenerskogRada.AutoSize = true;
            this.lblGodinaPocetkaTrenerskogRada.Location = new System.Drawing.Point(583, 209);
            this.lblGodinaPocetkaTrenerskogRada.Name = "lblGodinaPocetkaTrenerskogRada";
            this.lblGodinaPocetkaTrenerskogRada.Size = new System.Drawing.Size(160, 13);
            this.lblGodinaPocetkaTrenerskogRada.TabIndex = 58;
            this.lblGodinaPocetkaTrenerskogRada.Text = "Godina pocetka trenerskog rada";
            // 
            // txtGodinaPocetkaTrenerskogRada
            // 
            this.txtGodinaPocetkaTrenerskogRada.Location = new System.Drawing.Point(584, 225);
            this.txtGodinaPocetkaTrenerskogRada.Name = "txtGodinaPocetkaTrenerskogRada";
            this.txtGodinaPocetkaTrenerskogRada.Size = new System.Drawing.Size(70, 20);
            this.txtGodinaPocetkaTrenerskogRada.TabIndex = 59;
            // 
            // TrenerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 535);
            this.Controls.Add(this.txtGodinaPocetkaTrenerskogRada);
            this.Controls.Add(this.lblGodinaPocetkaTrenerskogRada);
            this.Controls.Add(this.txtRedovnoZanimanje);
            this.Controls.Add(this.lblRedovnoZanimanje);
            this.Controls.Add(this.txtNazivFakulteta);
            this.Controls.Add(this.lblNazivFakulteta);
            this.Controls.Add(this.cmbVrstaTrenerskogAngazmana);
            this.Controls.Add(this.lblVrstaTrenerskogAngazmana);
            this.Controls.Add(this.btnPrikaziIzvodMKR);
            this.Controls.Add(this.btnDodajIzvodMKR);
            this.Controls.Add(this.txtIzvodMKR);
            this.Controls.Add(this.lblIzvodMKR);
            this.Controls.Add(this.btnPrikaziFoto);
            this.Controls.Add(this.btnDodajFoto);
            this.Controls.Add(this.txtFoto);
            this.Controls.Add(this.lblFoto);
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
            this.Controls.Add(this.txtRegBroj);
            this.Controls.Add(this.lblRegBroj);
            this.Controls.Add(this.txtJMBG);
            this.Controls.Add(this.lblJMBG);
            this.Controls.Add(this.txtDatRodj);
            this.Controls.Add(this.lblDatumRodjenja);
            this.Controls.Add(this.btnAddKlub);
            this.Controls.Add(this.cmbKlub);
            this.Controls.Add(this.lblKlub);
            this.Controls.Add(this.cmbPol);
            this.Controls.Add(this.lblIme);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.lblPol);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.lblPrezime);
            this.Name = "TrenerForm";
            this.Text = "TrenerForm";
            this.Shown += new System.EventHandler(this.TrenerForm_Shown);
            this.Controls.SetChildIndex(this.lblPrezime, 0);
            this.Controls.SetChildIndex(this.txtPrezime, 0);
            this.Controls.SetChildIndex(this.lblPol, 0);
            this.Controls.SetChildIndex(this.txtIme, 0);
            this.Controls.SetChildIndex(this.lblIme, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.cmbPol, 0);
            this.Controls.SetChildIndex(this.lblKlub, 0);
            this.Controls.SetChildIndex(this.cmbKlub, 0);
            this.Controls.SetChildIndex(this.btnAddKlub, 0);
            this.Controls.SetChildIndex(this.lblDatumRodjenja, 0);
            this.Controls.SetChildIndex(this.txtDatRodj, 0);
            this.Controls.SetChildIndex(this.lblJMBG, 0);
            this.Controls.SetChildIndex(this.txtJMBG, 0);
            this.Controls.SetChildIndex(this.lblRegBroj, 0);
            this.Controls.SetChildIndex(this.txtRegBroj, 0);
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
            this.Controls.SetChildIndex(this.lblFoto, 0);
            this.Controls.SetChildIndex(this.txtFoto, 0);
            this.Controls.SetChildIndex(this.btnDodajFoto, 0);
            this.Controls.SetChildIndex(this.btnPrikaziFoto, 0);
            this.Controls.SetChildIndex(this.lblIzvodMKR, 0);
            this.Controls.SetChildIndex(this.txtIzvodMKR, 0);
            this.Controls.SetChildIndex(this.btnDodajIzvodMKR, 0);
            this.Controls.SetChildIndex(this.btnPrikaziIzvodMKR, 0);
            this.Controls.SetChildIndex(this.lblVrstaTrenerskogAngazmana, 0);
            this.Controls.SetChildIndex(this.cmbVrstaTrenerskogAngazmana, 0);
            this.Controls.SetChildIndex(this.lblNazivFakulteta, 0);
            this.Controls.SetChildIndex(this.txtNazivFakulteta, 0);
            this.Controls.SetChildIndex(this.lblRedovnoZanimanje, 0);
            this.Controls.SetChildIndex(this.txtRedovnoZanimanje, 0);
            this.Controls.SetChildIndex(this.lblGodinaPocetkaTrenerskogRada, 0);
            this.Controls.SetChildIndex(this.txtGodinaPocetkaTrenerskogRada, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Label lblPol;
        private System.Windows.Forms.ComboBox cmbPol;
        private System.Windows.Forms.Button btnAddKlub;
        private System.Windows.Forms.ComboBox cmbKlub;
        private System.Windows.Forms.Label lblKlub;
        private System.Windows.Forms.Label lblDatumRodjenja;
        private System.Windows.Forms.TextBox txtDatRodj;
        private System.Windows.Forms.Label lblJMBG;
        private System.Windows.Forms.TextBox txtJMBG;
        private System.Windows.Forms.Label lblRegBroj;
        private System.Windows.Forms.TextBox txtRegBroj;
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
        private System.Windows.Forms.Label lblFoto;
        private System.Windows.Forms.TextBox txtFoto;
        private System.Windows.Forms.Button btnDodajFoto;
        private System.Windows.Forms.Button btnPrikaziFoto;
        private System.Windows.Forms.Label lblIzvodMKR;
        private System.Windows.Forms.TextBox txtIzvodMKR;
        private System.Windows.Forms.Button btnDodajIzvodMKR;
        private System.Windows.Forms.Button btnPrikaziIzvodMKR;
        private System.Windows.Forms.Label lblVrstaTrenerskogAngazmana;
        private System.Windows.Forms.ComboBox cmbVrstaTrenerskogAngazmana;
        private System.Windows.Forms.Label lblNazivFakulteta;
        private System.Windows.Forms.TextBox txtNazivFakulteta;
        private System.Windows.Forms.Label lblRedovnoZanimanje;
        private System.Windows.Forms.TextBox txtRedovnoZanimanje;
        private System.Windows.Forms.Label lblGodinaPocetkaTrenerskogRada;
        private System.Windows.Forms.TextBox txtGodinaPocetkaTrenerskogRada;
    }
}