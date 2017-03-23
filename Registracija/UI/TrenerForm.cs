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

namespace Registracija.UI
{
    public partial class TrenerForm : EntityDetailForm
    {
        private List<Klub> klubovi;
        private string oldIme;
        private string oldPrezime;
        private readonly string PRAZNO_ITEM = "<<Prazno>>";

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

            SelectedKlub = trener.Klub;
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

            if (cmbKlub.Text.Trim() != String.Empty && cmbKlub.Text.Trim() != PRAZNO_ITEM && SelectedKlub == null)
            {
                notification.RegisterMessage(
                    "Klub", "Uneli ste nepostojeci klub.");
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

            trener.Klub = SelectedKlub;
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
    }
}