using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Registracija.Domain;
using Registracija.Exceptions;
using Registracija.Data;
using System.Collections.Specialized;
using Registracija.Util;
using Registracija.Dao;
using NHibernate;
using NHibernate.Context;
using Registracija.Dao.NHibernate;
using System.IO;

namespace Registracija.UI
{
    public partial class GimnasticarForm : EntityDetailForm
    {
        private List<KategorijaGimnasticara> kategorije;
        private List<Klub> klubovi;
        private List<Trener> treneri;
        private string oldIme;
        private string oldPrezime;
        private string oldSrednjeIme;
        private Datum oldDatumRodjenja;
        private string oldRegBroj;
        private readonly string PRAZNO_ITEM = "<<Prazno>>";
        private List<Gimnasticar> gimnasticari;

        private Gimnasticar gimnasticarToEdit;
        public Gimnasticar GimnasticarToEdit
        {
            get { return gimnasticarToEdit; }
        }

        public GimnasticarForm(Nullable<int> gimnasticarId)
        {
            InitializeComponent();

            // NOTE: Ponistavam AcceptButton (koji je u EntityDetailForm postavljen na btnOk), zato sto se pojavljuju
            // problemi kada npr. dodajem novog gimnasticara, pa onda u dijalogu izaberem postojeceg gimnasticara iz baze.
            // Tada, umesto da otvori dijalog sa podacima za novog gimnasticara, program se ponasa kao da je kliknuto
            // na OK, i izvrsava validaciju za podatke iz dijaloga i npr. posto gimnastika jos nije unesena (zato sto
            // unosimo novog gimnasticara), prikazuje prozor "Gimnastika je obavezna". Da bi se ovo izbeglo, simuliram
            // AcceptButton overrajdovanjem metoda ProcessCmdKey (vidi dole).
            this.AcceptButton = null;

            initialize(gimnasticarId, true);
        }

        protected override void loadData()
        {
            if (editMode)
                kategorije = new List<KategorijaGimnasticara>(
                    DAOFactoryFactory.DAOFactory.GetKategorijaGimnasticaraDAO()
                    .FindByGimnastika(((Gimnasticar)entity).Gimnastika));
            else
                kategorije = new List<KategorijaGimnasticara>();

            klubovi = new List<Klub>(DAOFactoryFactory.DAOFactory.GetKlubDAO().FindAll());
            treneri = new List<Trener>(DAOFactoryFactory.DAOFactory.GetTrenerDAO().FindAll());
            gimnasticari = new List<Gimnasticar>(DAOFactoryFactory.DAOFactory.GetGimnasticarDAO().FindAll());
        }

        protected override void initUI()
        {
            base.initUI();
            this.Text = "Gimnasticar";

            txtIme.Text = String.Empty;
            txtSrednjeIme.Text = String.Empty;

            txtPrezime.Text = String.Empty;
            txtPrezime.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPrezime.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txtDatRodj.Text = String.Empty;
            txtJMBG.Text = String.Empty;
            txtRegBroj.Text = String.Empty;
            txtDatumPoslReg.Text = String.Empty;

            txtMesto.Text = String.Empty;
            txtAdresa.Text = String.Empty;
            txtTelefon1.Text = String.Empty;
            txtTelefon2.Text = String.Empty;
            txtEmail.Text = String.Empty;

            txtFoto.ReadOnly = true;
            txtFoto.BackColor = SystemColors.Window;

            txtIzvodMKR.ReadOnly = true;
            txtIzvodMKR.BackColor = SystemColors.Window;

            cmbGimnastika.DropDownStyle = ComboBoxStyle.DropDownList;
            setGimnastike();
            SelectedGimnastika = Gimnastika.Undefined;

            cmbKategorija.DropDownStyle = ComboBoxStyle.DropDown;
            setKategorije(kategorije);
            SelectedKategorija = null;
            cmbKategorija.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbKategorija.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbKlub.DropDownStyle = ComboBoxStyle.DropDown;
            setKlubovi(klubovi);
            SelectedKlub = null;
            cmbKlub.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbKlub.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbTrener.DropDownStyle = ComboBoxStyle.DropDown;
            setTreneri(treneri);
            SelectedTrener = null;
            cmbTrener.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbTrener.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void setGimnastike()
        {
            cmbGimnastika.Items.AddRange(new string[] { "MSG", "ZSG" });
        }

        private Gimnastika SelectedGimnastika
        {
            get
            {
                if (cmbGimnastika.SelectedIndex == 0)
                    return Gimnastika.MSG;
                else if (cmbGimnastika.SelectedIndex == 1)
                    return Gimnastika.ZSG;
                else
                    return Gimnastika.Undefined;
            }
            set
            {
                if (value == Gimnastika.MSG)
                    cmbGimnastika.SelectedIndex = 0;
                else if (value == Gimnastika.ZSG)
                    cmbGimnastika.SelectedIndex = 1;
                else
                    cmbGimnastika.SelectedIndex = -1;
            }
        }

        private void setKategorije(List<KategorijaGimnasticara> kategorije)
        {
            List<object> items = new List<object>();
            items.Add(PRAZNO_ITEM);
            items.AddRange(kategorije.ToArray());
            cmbKategorija.DisplayMember = "Naziv";
            cmbKategorija.DataSource = items;
            // NOTE: If the specified DisplayMember property does not exist on the
            // object (as is the case for PRAZNO_ITEM) or the value of DisplayMember
            // is an empty string (""), the results of the object's ToString method
            // are displayed instead.
        }

        private KategorijaGimnasticara SelectedKategorija
        {
            get { return cmbKategorija.SelectedItem as KategorijaGimnasticara; }
            set { cmbKategorija.SelectedItem = value; }
        }

        private void setKlubovi(List<Klub> klubovi)
        {
            List<object> items = new List<object>();
            items.Add(PRAZNO_ITEM);
            items.AddRange(klubovi.ToArray());
            cmbKlub.DisplayMember = "Naziv";
            cmbKlub.DataSource = items;
        }

        private void setTreneri(List<Trener> treneri)
        {
            List<object> items = new List<object>();
            items.Add(PRAZNO_ITEM);
            items.AddRange(treneri.ToArray());
            // TODO4 TODO5: Iako sam stavio PrezimeIme, prikazuje se ime pa prezime (tj. poziva se ToString())
            cmbTrener.DisplayMember = "PrezimeIme";
            cmbTrener.DataSource = items;
        }

        private Klub SelectedKlub
        {
            get { return cmbKlub.SelectedItem as Klub; }
            set { cmbKlub.SelectedItem = value; }
        }

        private Trener SelectedTrener
        {
            get { return cmbTrener.SelectedItem as Trener; }
            set { cmbTrener.SelectedItem = value; }
        }

        protected override DomainObject getEntityById(int id)
        {
            return DAOFactoryFactory.DAOFactory.GetGimnasticarDAO().FindById(id);
        }

        protected override void saveOriginalData(DomainObject entity)
        {
            Gimnasticar gimnasticar = (Gimnasticar)entity;
            oldIme = gimnasticar.Ime;
            oldSrednjeIme = gimnasticar.SrednjeIme;
            oldPrezime = gimnasticar.Prezime;
            oldDatumRodjenja = gimnasticar.DatumRodjenja;
            oldRegBroj = gimnasticar.RegistarskiBroj;
        }

        protected override void updateUIFromEntity(DomainObject entity)
        {
            Gimnasticar gimnasticar = (Gimnasticar)entity;
            txtIme.Text = gimnasticar.Ime;

            txtSrednjeIme.Text = String.Empty;
            if (!string.IsNullOrEmpty(gimnasticar.SrednjeIme))
                txtSrednjeIme.Text = gimnasticar.SrednjeIme;

            txtPrezime.Text = gimnasticar.Prezime;

            txtDatRodj.Text = String.Empty;
            if (gimnasticar.DatumRodjenja != null)
                txtDatRodj.Text = gimnasticar.DatumRodjenja.ToString("d");

            txtJMBG.Text = gimnasticar.JMBG;

            txtRegBroj.Text = gimnasticar.RegistarskiBroj;

            txtDatumPoslReg.Text = String.Empty;
            if (gimnasticar.DatumPoslednjeRegistracije != null)
                txtDatumPoslReg.Text = gimnasticar.DatumPoslednjeRegistracije.ToString("d");

            txtMesto.Text = gimnasticar.Mesto;
            txtAdresa.Text = gimnasticar.Adresa;
            txtTelefon1.Text = gimnasticar.Telefon1;
            txtTelefon2.Text = gimnasticar.Telefon2;
            txtEmail.Text = gimnasticar.Email;

            txtFoto.Text = gimnasticar.FotoFile;
            if (txtFoto.Text != String.Empty)
                btnDodajFoto.Text = "Promeni";

            txtIzvodMKR.Text = gimnasticar.IzvodMKRFile;
            if (txtIzvodMKR.Text != String.Empty)
                btnDodajIzvodMKR.Text = "Promeni";

            SelectedGimnastika = gimnasticar.Gimnastika;

            SelectedKategorija = gimnasticar.Kategorija;
            SelectedKlub = gimnasticar.Klub;
            SelectedTrener = gimnasticar.Trener;
        }

        protected override void requiredFieldsAndFormatValidation(Notification notification)
        {
            Datum dummyDatum;
            if (txtIme.Text.Trim() == String.Empty)
            {
                notification.RegisterMessage(
                    "Ime", "Ime gimnasticara je obavezno.");
            }
            if (txtPrezime.Text.Trim() == String.Empty)
            {
                notification.RegisterMessage(
                    "Prezime", "Prezime gimnasticara je obavezno.");
            }
            if (SelectedGimnastika == Gimnastika.Undefined)
            {
                notification.RegisterMessage(
                    "Gimnastika", "Gimnastika je obavezna.");
            }
            if (txtDatRodj.Text.Trim() != String.Empty
            && !Datum.TryParse(txtDatRodj.Text, out dummyDatum))
            {
                notification.RegisterMessage(
                    "DatumRodjenja", "Neispravan format za datum ili godinu rodjenja.");
            }

            if (txtDatumPoslReg.Text.Trim() != String.Empty
            && !Datum.TryParse(txtDatumPoslReg.Text, out dummyDatum))
            {
                notification.RegisterMessage(
                    "DatumPoslednjeRegistracije", "Neispravan format za datum ili godinu poslednje registracije.");
            }

            if (cmbKlub.Text.Trim() != String.Empty && cmbKlub.Text.Trim() != PRAZNO_ITEM && SelectedKlub == null)
            {
                notification.RegisterMessage(
                    "Klub", "Uneli ste nepostojeci klub.");
            }

            if (cmbTrener.Text.Trim() != String.Empty && cmbTrener.Text.Trim() != PRAZNO_ITEM && SelectedTrener == null)
            {
                notification.RegisterMessage(
                    "Trener", "Uneli ste nepostojeceg trenera.");
            }

            if (cmbKategorija.Text.Trim() != String.Empty && cmbKategorija.Text.Trim() != PRAZNO_ITEM
                && SelectedKategorija == null)
            {
                notification.RegisterMessage(
                    "Kategorija", "Uneli ste nepostojecu kategoriju.");
            }
        }

        protected override void setFocus(string propertyName)
        {
            switch (propertyName)
            {
                case "Ime":
                    txtIme.Focus();
                    break;

                case "SrednjeIme":
                    txtSrednjeIme.Focus();
                    break;

                case "Prezime":
                    txtPrezime.Focus();
                    break;

                case "Gimnastika":
                    cmbGimnastika.Focus();
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

                case "DatumPoslednjeRegistracije":
                    txtDatumPoslReg.Focus();
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

                case "Kategorija":
                    cmbKategorija.Focus();
                    break;

                case "Klub":
                    cmbKlub.Focus();
                    break;

                case "Trener":
                    cmbTrener.Focus();
                    break;

                default:
                    throw new ArgumentException();
            }
        }

        protected override DomainObject createNewEntity()
        {
            return new Gimnasticar();
        }

        protected override void updateEntityFromUI(DomainObject entity)
        {
            Gimnasticar gimnasticar = (Gimnasticar)entity;
            
            gimnasticar.Ime = txtIme.Text.Trim();
            
            if (txtSrednjeIme.Text.Trim() == String.Empty)
                gimnasticar.SrednjeIme = null;
            else
                gimnasticar.SrednjeIme = txtSrednjeIme.Text.Trim();
            
            gimnasticar.Prezime = txtPrezime.Text.Trim();

            if (txtDatRodj.Text.Trim() == String.Empty)
                gimnasticar.DatumRodjenja = null;
            else
                gimnasticar.DatumRodjenja = Datum.Parse(txtDatRodj.Text);

            gimnasticar.JMBG = txtJMBG.Text.Trim();

            gimnasticar.Gimnastika = SelectedGimnastika;

            gimnasticar.RegistarskiBroj = txtRegBroj.Text.Trim();

            if (txtDatumPoslReg.Text.Trim() == String.Empty)
                gimnasticar.DatumPoslednjeRegistracije = null;
            else
                gimnasticar.DatumPoslednjeRegistracije = Datum.Parse(txtDatumPoslReg.Text);

            gimnasticar.Mesto = txtMesto.Text.Trim();
            gimnasticar.Adresa = txtAdresa.Text.Trim();
            gimnasticar.Telefon1 = txtTelefon1.Text.Trim();
            gimnasticar.Telefon2 = txtTelefon2.Text.Trim();
            gimnasticar.Email = txtEmail.Text.Trim();

            gimnasticar.FotoFile = txtFoto.Text.Trim();
            gimnasticar.IzvodMKRFile = txtIzvodMKR.Text.Trim();

            gimnasticar.Klub = SelectedKlub;
            gimnasticar.Trener = SelectedTrener;
            gimnasticar.Kategorija = SelectedKategorija;
        }

        protected override void updateEntity(DomainObject entity)
        {
            // NOTE: Desava mi se greska kada menjam datum rodjenja:
            // Error: a different object with the same identifier value was already associated with the session.

            // Moguce je da greska ima veze sa time sto je DatumRodjenja (koji se koristi u Equals za poredjenje)
            // u .hbm fajlu mapiran kao component. Kada menjam ime ili prezime (koji se takodje koriste u Equals)
            // greska se ne pojavljuje. Mada, interesantno je da u GimnasticarUcesnikForm ne postoji taj problem.
                        
            // Ovo je objasnjenje koje sam nasao za workaround koji resava problem:
            // This error is raised from nHibernate when you are updating an instance of an Entity that is saved on the
            // Cache. Basically nHibernate stores your objects on the cache once you loaded it, so next calls would get
            // it from the cache. If you update an instance that is present on the cache nHibernate throws this error
            // otherwise it could cause dirty reads and conflicts regarding loading the old copy of the object. To get
            // around this, you need to remove the object from the cache using the Evict method.

            try
            {
                // TODO3: Evict sam okruzio sa try/catch zato sto kada promenim srednje ime dobijam izuzetak "The given
                // key was not present in the dictionary". Proveri u NHibernate in Action zasto se ovo desava.
                DAOFactoryFactory.DAOFactory.GetGimnasticarDAO().Evict((Gimnasticar)entity);
            }
            catch (Exception)
            { }

            DAOFactoryFactory.DAOFactory.GetGimnasticarDAO().Update((Gimnasticar)entity);
        }

        protected override void addEntity(DomainObject entity)
        {
            DAOFactoryFactory.DAOFactory.GetGimnasticarDAO().Add((Gimnasticar)entity);
        }

        protected override void checkBusinessRulesOnAdd(DomainObject entity)
        {
            Gimnasticar g = (Gimnasticar)entity;
            Notification notification = new Notification();
            GimnasticarDAO gimnasticarDAO = DAOFactoryFactory.DAOFactory.GetGimnasticarDAO();

            if (gimnasticarDAO.existsGimnasticarImePrezimeSrednjeImeDatumRodjenja(g.Ime, g.Prezime, g.SrednjeIme,
                g.DatumRodjenja))
            {
                notification.RegisterMessage("Ime", 
                    "Gimnasticar sa datim imenom, prezimenom i datumom rodjenja vec postoji.");
                throw new BusinessException(notification);
            }

            if (!String.IsNullOrEmpty(g.RegistarskiBroj) && gimnasticarDAO.existsGimnasticarRegBroj(g.RegistarskiBroj))
            {
                notification.RegisterMessage("RegistarskiBroj", 
                    "Gimnasticar sa datim registarskim brojem vec postoji.");
                throw new BusinessException(notification);
            }
        }

        protected override void checkBusinessRulesOnUpdate(DomainObject entity)
        {
            Gimnasticar g = (Gimnasticar)entity;
            Notification notification = new Notification();
            GimnasticarDAO gimnasticarDAO = DAOFactoryFactory.DAOFactory.GetGimnasticarDAO();

            if (hasImeSrednjeImePrezimeDatumRodjenjaChanged(g)
            && gimnasticarDAO.existsGimnasticarImePrezimeSrednjeImeDatumRodjenja(g.Ime, g.Prezime, g.SrednjeIme,
                g.DatumRodjenja))
            {
                notification.RegisterMessage("Ime",
                    "Gimnasticar sa datim imenom, prezimenom i datumom rodjenja vec postoji.");
                throw new BusinessException(notification);
            }

            bool regBrojChanged = (g.RegistarskiBroj != oldRegBroj) ? true : false;            
            if (regBrojChanged && !String.IsNullOrEmpty(g.RegistarskiBroj) && gimnasticarDAO.existsGimnasticarRegBroj(g.RegistarskiBroj))
            {
                notification.RegisterMessage("RegistarskiBroj",
                    "Gimnasticar sa datim registarskim brojem vec postoji.");
                throw new BusinessException(notification);
            }
        }

        private bool hasImeSrednjeImePrezimeDatumRodjenjaChanged(Gimnasticar g)
        {
            bool equals = g.Ime.ToUpper() == oldIme.ToUpper()
                && g.Prezime.ToUpper() == oldPrezime.ToUpper();
            if (equals)
            {
                equals = string.IsNullOrEmpty(g.SrednjeIme)
                    && string.IsNullOrEmpty(oldSrednjeIme)
                || (!string.IsNullOrEmpty(g.SrednjeIme)
                    && !string.IsNullOrEmpty(oldSrednjeIme)
                    && g.SrednjeIme.ToUpper() == oldSrednjeIme.ToUpper());
            }
            if (equals)
            {
                equals = g.DatumRodjenja == oldDatumRodjenja;
            }
            return !equals;
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

        private void btnAddTrener_Click(object sender, EventArgs e)
        {
            try
            {
                TrenerForm form = new TrenerForm(null);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Trener t = (Trener)form.Entity;
                    treneri.Add(t);
                    treneri.Sort();
                    setTreneri(treneri);
                    SelectedTrener = t;
                }
            }
            catch (InfrastructureException ex)
            {
                MessageDialogs.showError(ex.Message, this.Text);
            }
        }
        
        private void btnAddKategorija_Click(object sender, EventArgs e)
        {
            try
            {
                KategorijaGimnasticaraForm form = new KategorijaGimnasticaraForm(null);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    reloadKategorije(SelectedGimnastika);

                    KategorijaGimnasticara newKat = (KategorijaGimnasticara)form.Entity;
                    if (kategorije.IndexOf(newKat) != -1)
                        SelectedKategorija = newKat;
                    else
                        SelectedKategorija = null;
                }
            }
            catch (InfrastructureException ex)
            {
                MessageDialogs.showError(ex.Message, this.Text);
            }
        }

        protected override void discardChanges()
        {
            // TODO: Razmotri da li bi trebalo da se brisu entiteti dodati
            // pritiskom na dugme (...) ako korisnik zatvori dijalog sa Cancel ili X.
            // (ovo vazi i za ostale dijaloge). Ovde je problem kako pratiti cascading
            // changes - npr. ako korisnik doda nov klub, a u dijalogu za klub doda
            // novo mesto itd.

            // NOTE: Ako implementiras discardChanges metod, kod okruzi sa try catch
            // blokom, jer u suprotnom ako se desi unhandled exception dijalog nece
            // biti zatvoren. (Ako se u bilo kom handleru dijaloga dogodi unhandled
            // exception, kontrola ostaje unutar dijaloga, a metod discardChanged se
            // poziva iz btnCancel_Click i EntityDetailForm_FormClosed handlera. )
        }

        private void cmbKategorija_DropDown(object sender, EventArgs e)
        {
            if (SelectedGimnastika == Gimnastika.Undefined)
                MessageDialogs.showMessage("Najpre unesite gimnastiku.", this.Text);
        }

        private void cmbGimnastika_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (initializing)
                return;
            reloadKategorije(SelectedGimnastika);
            SelectedKategorija = null;
        }

        private void reloadKategorije(Gimnastika gimnastika)
        {
            if (gimnastika != Gimnastika.Undefined)
            {
                ISession session = null;
                try
                {
                    using (session = NHibernateHelper.Instance.OpenSession())
                    using (session.BeginTransaction())
                    {
                        CurrentSessionContext.Bind(session);
                        kategorije = new List<KategorijaGimnasticara>(
                            DAOFactoryFactory.DAOFactory.GetKategorijaGimnasticaraDAO().FindByGimnastika(gimnastika));
                    }
                }
                catch (Exception ex)
                {
                    if (session != null && session.Transaction != null && session.Transaction.IsActive)
                        session.Transaction.Rollback();
                    MessageDialogs.showMessage(
                        Strings.getFullDatabaseAccessExceptionMessage(ex), this.Text);
                    Close();
                    return;
                }
                finally
                {
                    CurrentSessionContext.Unbind(NHibernateHelper.Instance.SessionFactory);
                }
            }
            else
            {
                kategorije = new List<KategorijaGimnasticara>();
            }

            setKategorije(kategorije);
        }

        private void GimnasticarForm_Shown(object sender, EventArgs e)
        {
            if (!editMode)
                txtIme.Focus();
            else
                btnCancel.Focus();
        }

        private void txtPrezime_Enter(object sender, EventArgs e)
        {
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            
            string ime = txtIme.Text.Trim();
            foreach (Gimnasticar g in gimnasticari)
            {
                if (g.Ime.ToUpper() == ime.ToUpper())
                {
                    string s = g.Prezime;
                    if (g.DatumRodjenja != null)
                    {
                        s += ", " + g.DatumRodjenja.ToString("dd.MM.yyyy");
                    }
                    if (g.SrednjeIme == null || g.SrednjeIme == string.Empty)
                    {
                        col.Add(s);
                    }
                    else
                        col.Add(s + "   (" + g.ImeSrednjeImePrezimeDatumRodjenja + ")");
                }
            }

            txtPrezime.AutoCompleteCustomSource = col;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // NOTE: Vidi komentar u konstruktoru zasto je potreban ovaj metod.
            if (keyData == Keys.Enter && !txtPrezime.Focused && !btnCancel.Focused)
            {
                // Simuliraj klik na OK.
                btnOk.PerformClick();
                return true;
            }

            // Inace, odradi standardnu obradu za pritisak tastera. Ako je pritisnut Enter u txtPrezime, pozvace se
            // txtPrezime_KeyDown.
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtPrezime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            Gimnasticar g;
            if (txtPrezime.Text.IndexOf('(') != -1 && txtPrezime.Text.IndexOf(')') != -1)
            {
                string imeSrednjeImePrezimeDatumRodjenja = txtPrezime.Text.Substring(txtPrezime.Text.IndexOf('(')).Trim();

                // Ukloni zagrade
                imeSrednjeImePrezimeDatumRodjenja = 
                    imeSrednjeImePrezimeDatumRodjenja.Substring(1, imeSrednjeImePrezimeDatumRodjenja.Length - 2).Trim();

                g = findGimnasticar(imeSrednjeImePrezimeDatumRodjenja.Trim());
            }
            else
            {
                string prezime = String.Empty;
                Datum datumRodjenja = null;
                int index = txtPrezime.Text.IndexOf(',');
                if (index != -1)
                {
                    prezime = txtPrezime.Text.Substring(0, index).Trim();
                    datumRodjenja = Datum.Parse(txtPrezime.Text.Substring(index + 1).Trim());
                }
                else
                {
                    prezime = txtPrezime.Text.Trim();
                }
                g = findGimnasticar(txtIme.Text.Trim(), String.Empty, prezime, datumRodjenja);
            }

            if (g != null)
            {
                gimnasticarToEdit = g;
                closedByOK = true;
                DialogResult = DialogResult.OK;
                //Close();
                return;
            }
        }

        private Gimnasticar findGimnasticar(string imeSrednjeImePrezimeDatumRodjenja)
        {
            foreach (Gimnasticar g in gimnasticari)
            {
                if (g.ImeSrednjeImePrezimeDatumRodjenja.ToUpper() == imeSrednjeImePrezimeDatumRodjenja.ToUpper())
                    return g;
            }
            return null;
        }

        private Gimnasticar findGimnasticar(string ime, string srednjeIme, string prezime, Datum datumRodjenja)
        {
            foreach (Gimnasticar g in gimnasticari)
            {
                string srednjeImeGim = g.SrednjeIme == null ? String.Empty : g.SrednjeIme.ToUpper();
                bool datumRodjenjaEquals = (datumRodjenja == null && g.DatumRodjenja == null)
                    || (datumRodjenja != null && g.DatumRodjenja != null && datumRodjenja.Equals(g.DatumRodjenja));
                if (g.Ime.ToUpper() == ime.Trim().ToUpper() && g.Prezime.ToUpper() == prezime.Trim().ToUpper()
                        && srednjeImeGim == srednjeIme.Trim().ToUpper() && datumRodjenjaEquals)
                    return g;
            }
            return null;
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