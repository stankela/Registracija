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
    public partial class TrenerForm : EntityDetailForm
    {
        private List<Klub> klubovi;
        private string oldIme;
        private string oldPrezime;
        private readonly string PRAZNO_ITEM = "<<Prazno>>";
        private readonly string PROFESIONALAN = "Profesionalan";
        private readonly string NEPROFESIONALAN = "Neprofesionalan";

        public TrenerForm(Nullable<int> trenerId)
        {
            InitializeComponent();
            initialize(trenerId, true);
        }

        protected override void loadData()
        {
            klubovi = new List<Klub>(DAOFactoryFactory.DAOFactory.GetKlubDAO().FindAll());
        }

        protected override void initUI()
        {
            base.initUI();
            this.Text = "Trener";

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

            txtFoto.ReadOnly = true;
            txtFoto.BackColor = SystemColors.Window;

            txtIzvodMKR.ReadOnly = true;
            txtIzvodMKR.BackColor = SystemColors.Window;

            cmbKlub.DropDownStyle = ComboBoxStyle.DropDown;
            setKlubovi(klubovi);
            SelectedKlub = null;
            cmbKlub.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbKlub.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbVrstaTrenerskogAngazmana.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVrstaTrenerskogAngazmana.Items.AddRange(new string[] { PROFESIONALAN, NEPROFESIONALAN });
            cmbVrstaTrenerskogAngazmana.SelectedIndex = -1;

            txtNazivFakulteta.Text = String.Empty;
            txtRedovnoZanimanje.Text = String.Empty;
            txtGodinaPocetkaTrenerskogRada.Text = String.Empty;
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
            return DAOFactoryFactory.DAOFactory.GetTrenerDAO().FindById(id);
        }

        protected override void saveOriginalData(DomainObject entity)
        {
            Trener trener = (Trener)entity;
            oldIme = trener.Ime;
            oldPrezime = trener.Prezime;
        }

        protected override void updateUIFromEntity(DomainObject entity)
        {
            Trener trener = (Trener)entity;
            txtIme.Text = trener.Ime;
            txtPrezime.Text = trener.Prezime;

            cmbPol.SelectedIndex = -1;
            if (trener.Pol == Pol.Muski)
                cmbPol.SelectedIndex = 0;
            else if (trener.Pol == Pol.Zenski)
                cmbPol.SelectedIndex = 1;

            txtDatRodj.Text = String.Empty;
            if (trener.DatumRodjenja != null)
                txtDatRodj.Text = trener.DatumRodjenja.Value.ToString("d");

            txtJMBG.Text = trener.JMBG;

            txtRegBroj.Text = trener.RegistarskiBroj;

            txtMesto.Text = trener.Mesto;
            txtAdresa.Text = trener.Adresa;
            txtTelefon1.Text = trener.Telefon1;
            txtTelefon2.Text = trener.Telefon2;
            txtEmail.Text = trener.Email;

            txtFoto.Text = trener.FotoFile;
            if (txtFoto.Text != String.Empty)
                btnDodajFoto.Text = "Promeni";

            txtIzvodMKR.Text = trener.IzvodMKRFile;
            if (txtIzvodMKR.Text != String.Empty)
                btnDodajIzvodMKR.Text = "Promeni";

            SelectedKlub = trener.Klub;

            if (!String.IsNullOrEmpty(trener.VrstaTrenerskogAngazmana))
                cmbVrstaTrenerskogAngazmana.SelectedItem = trener.VrstaTrenerskogAngazmana;
            else
                cmbVrstaTrenerskogAngazmana.SelectedIndex = -1;

            txtNazivFakulteta.Text = trener.NazivFakulteta;
            txtRedovnoZanimanje.Text = trener.RedovnoZanimanje;
            txtGodinaPocetkaTrenerskogRada.Text = String.Empty;
            if (trener.GodinaPocetkaTrenerskogRada != null)
                txtGodinaPocetkaTrenerskogRada.Text = trener.GodinaPocetkaTrenerskogRada.ToString();
        }

        protected override void requiredFieldsAndFormatValidation(Notification notification)
        {
            if (txtIme.Text.Trim() == String.Empty)
            {
                notification.RegisterMessage(
                    "Ime", "Ime je obavezno.");
            }
            if (txtPrezime.Text.Trim() == String.Empty)
            {
                notification.RegisterMessage(
                    "Prezime", "Prezime je obavezno.");
            }
            if (cmbPol.SelectedIndex == -1)
            {
                notification.RegisterMessage(
                    "Pol", "Pol je obavezan.");
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
            if (txtGodinaPocetkaTrenerskogRada.Text.Trim() != String.Empty
            && !short.TryParse(txtGodinaPocetkaTrenerskogRada.Text, out dummyShort))
            {
                notification.RegisterMessage(
                    "GodinaPocetkaTrenerskogRada", "Neispravan format za godinu.");
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

                case "VrstaTrenerskogAngazmana":
                    cmbVrstaTrenerskogAngazmana.Focus();
                    break;

                case "GodinaPocetkaTrenerskogRada":
                    txtGodinaPocetkaTrenerskogRada.Focus();
                    break;

                case "NazivFakulteta":
                    txtNazivFakulteta.Focus();
                    break;

                case "RedovnoZanimanje":
                    txtRedovnoZanimanje.Focus();
                    break;

                default:
                    throw new ArgumentException();
            }
        }

        protected override DomainObject createNewEntity()
        {
            return new Trener();
        }

        protected override void updateEntityFromUI(DomainObject entity)
        {
            Trener trener = (Trener)entity;
            trener.Ime = txtIme.Text.Trim();
            trener.Prezime = txtPrezime.Text.Trim();

            if (cmbPol.SelectedIndex == 0)
                trener.Pol = Pol.Muski;
            else
                trener.Pol = Pol.Zenski;

            trener.Prezime = txtPrezime.Text.Trim();

            if (txtDatRodj.Text.Trim() == String.Empty)
                trener.DatumRodjenja = null;
            else
                trener.DatumRodjenja = DateTime.Parse(txtDatRodj.Text);

            trener.JMBG = txtJMBG.Text.Trim();

            trener.RegistarskiBroj = txtRegBroj.Text.Trim();

            trener.Mesto = txtMesto.Text.Trim();
            trener.Adresa = txtAdresa.Text.Trim();
            trener.Telefon1 = txtTelefon1.Text.Trim();
            trener.Telefon2 = txtTelefon2.Text.Trim();
            trener.Email = txtEmail.Text.Trim();

            trener.FotoFile = txtFoto.Text.Trim();
            trener.IzvodMKRFile = txtIzvodMKR.Text.Trim();

            trener.Klub = SelectedKlub;

            if (cmbVrstaTrenerskogAngazmana.SelectedItem == null)
                trener.VrstaTrenerskogAngazmana = String.Empty;
            else if (cmbVrstaTrenerskogAngazmana.SelectedItem.ToString() == PROFESIONALAN)
                trener.VrstaTrenerskogAngazmana = PROFESIONALAN;
            else if (cmbVrstaTrenerskogAngazmana.SelectedItem.ToString() == NEPROFESIONALAN)
                trener.VrstaTrenerskogAngazmana = NEPROFESIONALAN;

            trener.NazivFakulteta = txtNazivFakulteta.Text.Trim();
            trener.RedovnoZanimanje = txtRedovnoZanimanje.Text.Trim();
            if (txtGodinaPocetkaTrenerskogRada.Text.Trim() == String.Empty)
                trener.GodinaPocetkaTrenerskogRada = null;
            else
                trener.GodinaPocetkaTrenerskogRada = short.Parse(txtGodinaPocetkaTrenerskogRada.Text);
        }

        protected override void updateEntity(DomainObject entity)
        {
            DAOFactoryFactory.DAOFactory.GetTrenerDAO().Update((Trener)entity);
        }

        protected override void addEntity(DomainObject entity)
        {
            DAOFactoryFactory.DAOFactory.GetTrenerDAO().Add((Trener)entity);
        }

        protected override void checkBusinessRulesOnAdd(DomainObject entity)
        {
            Trener trener = (Trener)entity;
            Notification notification = new Notification();

            if (DAOFactoryFactory.DAOFactory.GetTrenerDAO().existsTrener(trener.Ime, trener.Prezime))
            {
                notification.RegisterMessage("Ime",
                    "Trener sa datim imenom i prezimenom vec postoji.");
                throw new BusinessException(notification);
            }
        }

        protected override void checkBusinessRulesOnUpdate(DomainObject entity)
        {
            Trener trener = (Trener)entity;
            Notification notification = new Notification();

            bool imePrezimeChanged = (trener.Ime.ToUpper() != oldIme.ToUpper()
                || trener.Prezime.ToUpper() != oldPrezime.ToUpper()) ? true : false;
            if (imePrezimeChanged
            && DAOFactoryFactory.DAOFactory.GetTrenerDAO().existsTrener(trener.Ime, trener.Prezime))
            {
                notification.RegisterMessage("Ime",
                    "Trener sa datim imenom i prezimenom vec postoji.");
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

        private void TrenerForm_Shown(object sender, EventArgs e)
        {
            if (!editMode)
            {
                txtIme.Focus();
            }
        }

        // TODO4 TODO5: Handleri za Foto i IzvodMKR (Dodaj i Prikazi) su skoro identicni, osim foldera i text boxa. Probaj
        // da izdvojis u jedan metod. Isto i za gimnasticare i sudije.
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