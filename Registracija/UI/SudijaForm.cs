using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Registracija.Domain;
using Registracija.Exceptions;
using Registracija.Util;
using Registracija.Dao;
using System.IO;

namespace Registracija.UI
{
    public partial class SudijaForm : EntityDetailForm
    {
        private List<Klub> klubovi;
        private string oldIme;
        private string oldPrezime;
        private readonly string PRAZNO_ITEM = "<<Prazno>>";

        public SudijaForm(Nullable<int> sudijaId)
        {
            InitializeComponent();
            initialize(sudijaId, true);
        }

        protected override void loadData()
        {
            klubovi = new List<Klub>(DAOFactoryFactory.DAOFactory.GetKlubDAO().FindAll());
        }

        protected override void initUI()
        {
            base.initUI();
            this.Text = "Sudija";

            txtIme.Text = String.Empty;
            txtPrezime.Text = String.Empty;

            cmbPol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPol.Items.AddRange(new string[] { "Muski", "Zenski" });
            cmbPol.SelectedIndex = -1;

            txtDatRodj.Text = String.Empty;
            txtJMBG.Text = String.Empty;
            txtRegBroj.Text = String.Empty;

            txtMesto.Text = String.Empty;
            txtAdresa.Text = String.Empty;
            txtTelefon1.Text = String.Empty;
            txtTelefon2.Text = String.Empty;
            txtEmail.Text = String.Empty;

            txtPoslSudZvanje.Text = String.Empty;
            txtNivoSudZvanja.Text = String.Empty;
            txtGodPoslZvanja.Text = String.Empty;
            txtGodPrvogZvanja.Text = String.Empty;
            
            txtFoto.ReadOnly = true;
            txtFoto.BackColor = SystemColors.Window;

            txtIzvodMKR.ReadOnly = true;
            txtIzvodMKR.BackColor = SystemColors.Window;
            
            cmbKlub.DropDownStyle = ComboBoxStyle.DropDown;
            setKlubovi(klubovi);
            SelectedKlub = null;
            cmbKlub.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbKlub.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void setKlubovi(List<Klub> klubovi)
        {
            List<object> items = new List<object>();
            items.Add(PRAZNO_ITEM);
            items.AddRange(klubovi.ToArray());
            cmbKlub.DisplayMember = "Naziv";
            cmbKlub.DataSource = items;
        }

        private Klub SelectedKlub
        {
            get { return cmbKlub.SelectedItem as Klub; }
            set { cmbKlub.SelectedItem = value; }
        }

        protected override DomainObject getEntityById(int id)
        {
            return DAOFactoryFactory.DAOFactory.GetSudijaDAO().FindById(id);
        }

        protected override void saveOriginalData(DomainObject entity)
        {
            Sudija sudija = (Sudija)entity;
            oldIme = sudija.Ime;
            oldPrezime = sudija.Prezime;
        }

        protected override void updateUIFromEntity(DomainObject entity)
        {
            Sudija sudija = (Sudija)entity;
            txtIme.Text = sudija.Ime;
            txtPrezime.Text = sudija.Prezime;

            cmbPol.SelectedIndex = -1;
            if (sudija.Pol == Pol.Muski)
                cmbPol.SelectedIndex = 0;
            else if (sudija.Pol == Pol.Zenski)
                cmbPol.SelectedIndex = 1;

            txtDatRodj.Text = String.Empty;
            if (sudija.DatumRodjenja != null)
                txtDatRodj.Text = sudija.DatumRodjenja.Value.ToString("d");

            txtJMBG.Text = sudija.JMBG;

            txtRegBroj.Text = sudija.RegistarskiBroj;

            txtMesto.Text = sudija.Mesto;
            txtAdresa.Text = sudija.Adresa;
            txtTelefon1.Text = sudija.Telefon1;
            txtTelefon2.Text = sudija.Telefon2;
            txtEmail.Text = sudija.Email;

            txtPoslSudZvanje.Text = sudija.PoslednjeSudijskoZvanje;
            txtNivoSudZvanja.Text = sudija.NivoSudijskogZvanja;
            txtGodPoslZvanja.Text = String.Empty;
            if (sudija.GodinaPoslednjegSudijskogZvanja != null)
                txtGodPoslZvanja.Text = sudija.GodinaPoslednjegSudijskogZvanja.ToString();
            txtGodPrvogZvanja.Text = String.Empty;
            if (sudija.GodinaPrvogSudijskogZvanja != null)
                txtGodPrvogZvanja.Text = sudija.GodinaPrvogSudijskogZvanja.ToString();

            txtFoto.Text = sudija.FotoFile;
            if (txtFoto.Text != String.Empty)
                btnDodajFoto.Text = "Promeni";

            txtIzvodMKR.Text = sudija.IzvodMKRFile;
            if (txtIzvodMKR.Text != String.Empty)
                btnDodajIzvodMKR.Text = "Promeni";

            SelectedKlub = sudija.Klub;
        }

        protected override void requiredFieldsAndFormatValidation(Notification notification)
        {
            if (txtIme.Text.Trim() == String.Empty)
            {
                notification.RegisterMessage(
                    "Ime", "Ime sudije je obavezno.");
            }
            if (txtPrezime.Text.Trim() == String.Empty)
            {
                notification.RegisterMessage(
                    "Prezime", "Prezime sudije je obavezno.");
            }
            if (cmbPol.SelectedIndex == -1)
            {
                notification.RegisterMessage(
                    "Pol", "Pol sudije je obavezan.");
            }

            DateTime dummyDateTime;
            if (txtDatRodj.Text.Trim() != String.Empty
            && !DateTime.TryParse(txtDatRodj.Text, out dummyDateTime))
            {
                notification.RegisterMessage(
                    "DatumRodjenja", "Neispravan format za datum rodjenja.");
            }

            if (cmbKlub.Text.Trim() != String.Empty && cmbKlub.Text.Trim() != PRAZNO_ITEM && SelectedKlub == null)
            {
                notification.RegisterMessage(
                    "Klub", "Uneli ste nepostojeci klub.");
            }

            short dummyShort;
            if (txtGodPoslZvanja.Text.Trim() != String.Empty
            && !short.TryParse(txtGodPoslZvanja.Text, out dummyShort))
            {
                notification.RegisterMessage(
                    "GodinaPoslednjegSudijskogZvanja", "Neispravan format za godinu.");
            }

            if (txtGodPrvogZvanja.Text.Trim() != String.Empty
            && !short.TryParse(txtGodPrvogZvanja.Text, out dummyShort))
            {
                notification.RegisterMessage(
                    "GodinaPrvogSudijskogZvanja", "Neispravan format za godinu.");
            }
        }

        protected override void setFocus(string propertyName)
        {
            switch (propertyName)
            {
                case "Ime":
                    txtIme.Focus();
                    break;

                case "Prezime":
                    txtPrezime.Focus();
                    break;

                case "Pol":
                    cmbPol.Focus();
                    break;

                case "Klub":
                    cmbKlub.Focus();
                    break;

                case "DatumRodjenja":
                    txtDatRodj.Focus();
                    break;

                case "JMBG":
                    txtJMBG.Focus();
                    break;

                case "RegistarskiBroj":
                    txtRegBroj.Focus();
                    break;

                case "Mesto":
                    txtMesto.Focus();
                    break;

                case "Adresa":
                    txtAdresa.Focus();
                    break;

                case "Telefon1":
                    txtTelefon1.Focus();
                    break;

                case "Telefon2":
                    txtTelefon2.Focus();
                    break;

                case "Email":
                    txtEmail.Focus();
                    break;

                case "FotoFile":
                    txtFoto.Focus();
                    break;

                case "IzvodMKRFile":
                    txtIzvodMKR.Focus();
                    break;

                case "PoslednjeSudijskoZvanje":
                    txtPoslSudZvanje.Focus();
                    break;

                case "NivoSudijskogZvanja":
                    txtNivoSudZvanja.Focus();
                    break;

                case "GodinaPoslednjegSudijskogZvanja":
                    txtGodPoslZvanja.Focus();
                    break;

                case "GodinaPrvogSudijskogZvanja":
                    txtGodPrvogZvanja.Focus();
                    break;

                default:
                    throw new ArgumentException();
            }
        }

        protected override DomainObject createNewEntity()
        {
            return new Sudija();
        }

        protected override void updateEntityFromUI(DomainObject entity)
        {
            Sudija sudija = (Sudija)entity;
            sudija.Ime = txtIme.Text.Trim();
            sudija.Prezime = txtPrezime.Text.Trim();

            if (cmbPol.SelectedIndex == 0)
                sudija.Pol = Pol.Muski;
            else
                sudija.Pol = Pol.Zenski;

            if (txtDatRodj.Text.Trim() == String.Empty)
                sudija.DatumRodjenja = null;
            else
                sudija.DatumRodjenja = DateTime.Parse(txtDatRodj.Text);

            sudija.JMBG = txtJMBG.Text.Trim();

            sudija.RegistarskiBroj = txtRegBroj.Text.Trim();

            sudija.Mesto = txtMesto.Text.Trim();
            sudija.Adresa = txtAdresa.Text.Trim();
            sudija.Telefon1 = txtTelefon1.Text.Trim();
            sudija.Telefon2 = txtTelefon2.Text.Trim();
            sudija.Email = txtEmail.Text.Trim();

            sudija.PoslednjeSudijskoZvanje = txtPoslSudZvanje.Text.Trim();
            sudija.NivoSudijskogZvanja = txtNivoSudZvanja.Text.Trim();
            if (txtGodPoslZvanja.Text.Trim() == String.Empty)
                sudija.GodinaPoslednjegSudijskogZvanja = null;
            else
                sudija.GodinaPoslednjegSudijskogZvanja = short.Parse(txtGodPoslZvanja.Text);
            if (txtGodPrvogZvanja.Text.Trim() == String.Empty)
                sudija.GodinaPrvogSudijskogZvanja = null;
            else
                sudija.GodinaPrvogSudijskogZvanja = short.Parse(txtGodPrvogZvanja.Text);

            sudija.FotoFile = txtFoto.Text.Trim();
            sudija.IzvodMKRFile = txtIzvodMKR.Text.Trim();

            sudija.Klub = SelectedKlub;
        }

        protected override void updateEntity(DomainObject entity)
        {
            DAOFactoryFactory.DAOFactory.GetSudijaDAO().Update((Sudija)entity);
        }

        protected override void addEntity(DomainObject entity)
        {
            DAOFactoryFactory.DAOFactory.GetSudijaDAO().Add((Sudija)entity);
        }

        protected override void checkBusinessRulesOnAdd(DomainObject entity)
        {
            Sudija sudija = (Sudija)entity;
            Notification notification = new Notification();

            if (DAOFactoryFactory.DAOFactory.GetSudijaDAO().existsSudija(sudija.Ime, sudija.Prezime))
            {
                notification.RegisterMessage("Ime",
                    "Sudija sa datim imenom i prezimenom vec postoji.");
                throw new BusinessException(notification);
            }
        }

        protected override void checkBusinessRulesOnUpdate(DomainObject entity)
        {
            Sudija sudija = (Sudija)entity;
            Notification notification = new Notification();

            bool imePrezimeChanged = (sudija.Ime.ToUpper() != oldIme.ToUpper()
                || sudija.Prezime.ToUpper() != oldPrezime.ToUpper()) ? true : false;
            if (imePrezimeChanged
            && DAOFactoryFactory.DAOFactory.GetSudijaDAO().existsSudija(sudija.Ime, sudija.Prezime))
            {
                notification.RegisterMessage("Ime",
                    "Sudija sa datim imenom i prezimenom vec postoji.");
                throw new BusinessException(notification);
            }
        }

        private void btnAddKlub_Click(object sender, EventArgs e)
        {
            try
            {
                KlubForm form = new KlubForm(null);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Klub k = (Klub)form.Entity;
                    klubovi.Add(k);
                    klubovi.Sort();
                    setKlubovi(klubovi);
                    SelectedKlub = k;
                }
            }
            catch (InfrastructureException ex)
            {
                MessageDialogs.showError(ex.Message, this.Text);
            }
        }

        private void SudijaForm_Shown(object sender, EventArgs e)
        {
            if (!editMode)
                txtIme.Focus();
            else
                btnCancel.Focus();
        }

        private void btnDodajFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            string fileName = Path.GetFileName(ofd.FileName);
            string fileDirectory = Path.GetDirectoryName(ofd.FileName);
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string destDirectory = Path.Combine(appDirectory, ConfigurationParameters.FotografijeFolder);

            bool fileIsInDestDirectory = fileDirectory.ToUpper() == destDirectory.ToUpper();
            string newPath = Path.Combine(appDirectory, ConfigurationParameters.FotografijeFolder, fileName);

            if (!fileIsInDestDirectory && File.Exists(newPath))
            {
                // Izabran je fajl van odredisnog foldera, a u odredisnom folderu vec postoji fajl sa istim imenom.
                // Nemoj da kopiras da ne bi prebrisao stari fajl.
                MessageDialogs.showError(String.Format("Fajl sa identicnim imenom ('{0}') vec postoji u folderu {1}.", fileName,
                    ConfigurationParameters.FotografijeFolder), this.Text);
            }
            else
            {
                // Kopiraj samo ako je izabran fajl van odredisnog direktorijuma
                if (!fileIsInDestDirectory)
                    File.Copy(ofd.FileName, newPath);
                txtFoto.Text = fileName;
            }
        }

        private void btnPrikaziFoto_Click(object sender, EventArgs e)
        {
            string fileName = txtFoto.Text.Trim();
            if (!String.IsNullOrEmpty(fileName))
            {
                string path = Path.Combine(ConfigurationParameters.FotografijeFolder, fileName);
                if (!File.Exists(path))
                {
                    MessageDialogs.showMessage(String.Format("Fajl {0} ne postoji u folderu {1}.", Path.GetFileName(fileName),
                        ConfigurationParameters.FotografijeFolder), this.Text);
                }
                else
                {
                    System.Diagnostics.Process.Start(path);
                }
            }
        }

        private void btnDodajIzvodMKR_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            string fileName = Path.GetFileName(ofd.FileName);
            string fileDirectory = Path.GetDirectoryName(ofd.FileName);
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string destDirectory = Path.Combine(appDirectory, ConfigurationParameters.IzvodiMKRFolder);

            bool fileIsInDestDirectory = fileDirectory.ToUpper() == destDirectory.ToUpper();
            string newPath = Path.Combine(appDirectory, ConfigurationParameters.IzvodiMKRFolder, fileName);

            if (!fileIsInDestDirectory && File.Exists(newPath))
            {
                // Izabran je fajl van odredisnog foldera, a u odredisnom folderu vec postoji fajl sa istim imenom.
                // Nemoj da kopiras da ne bi prebrisao stari fajl.
                MessageDialogs.showError(String.Format("Fajl sa identicnim imenom ('{0}') vec postoji u folderu {1}.", fileName,
                    ConfigurationParameters.IzvodiMKRFolder), this.Text);
            }
            else
            {
                // Kopiraj samo ako je izabran fajl van odredisnog direktorijuma
                if (!fileIsInDestDirectory)
                    File.Copy(ofd.FileName, newPath);
                txtIzvodMKR.Text = fileName;
            }
        }

        private void btnPrikaziIzvodMKR_Click(object sender, EventArgs e)
        {
            string fileName = txtIzvodMKR.Text.Trim();
            if (!String.IsNullOrEmpty(fileName))
            {
                string path = Path.Combine(ConfigurationParameters.IzvodiMKRFolder, fileName);
                if (!File.Exists(path))
                {
                    MessageDialogs.showMessage(String.Format("Fajl {0} ne postoji u folderu {1}.", Path.GetFileName(fileName),
                        ConfigurationParameters.IzvodiMKRFolder), this.Text);
                }
                else
                {
                    System.Diagnostics.Process.Start(path);
                }
            }
        }
    }
}