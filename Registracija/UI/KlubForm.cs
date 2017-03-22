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
    public partial class KlubForm : EntityDetailForm
    {
        private string oldNaziv;
        private string oldKod;
        
        public KlubForm(Nullable<int> klubId)
        {
            InitializeComponent();
            initialize(klubId, true);
        }

        protected override void initUI()
        {
            base.initUI();
            this.Text = "Klub";
            txtNaziv.Text = String.Empty;
            txtKod.Text = String.Empty;
            txtMesto.Text = String.Empty;
            txtAdresa.Text = String.Empty;
            txtTelefon1.Text = String.Empty;
            txtTelefon2.Text = String.Empty;
        }

        protected override DomainObject getEntityById(int id)
        {
            return DAOFactoryFactory.DAOFactory.GetKlubDAO().FindById(id);
        }

        protected override void saveOriginalData(DomainObject entity)
        {
            Klub klub = (Klub)entity;
            oldNaziv = klub.Naziv;
            oldKod = klub.Kod;
        }

        protected override void updateUIFromEntity(DomainObject entity)
        {
            Klub klub = (Klub)entity;
            txtNaziv.Text = klub.Naziv;
            txtKod.Text = klub.Kod;
            txtMesto.Text = klub.Mesto;
            txtAdresa.Text = klub.Adresa;
            txtTelefon1.Text = klub.Telefon1;
            txtTelefon2.Text = klub.Telefon2;
        }

        protected override void requiredFieldsAndFormatValidation(Notification notification)
        {
            if (txtNaziv.Text.Trim() == String.Empty)
            {
                notification.RegisterMessage(
                    "Naziv", "Naziv kluba je obavezan.");
            }

            if (txtKod.Text.Trim() == String.Empty)
            {
                notification.RegisterMessage(
                    "Kod", "Kod kluba je obavezan.");
            }

            if (txtMesto.Text.Trim() == String.Empty)
            {
                notification.RegisterMessage(
                    "Mesto", "Mesto je obavezno.");
            }
        }

        protected override void setFocus(string propertyName)
        {
            switch (propertyName)
            {
                case "Naziv":
                    txtNaziv.Focus();
                    break;

                case "Kod":
                    txtKod.Focus();
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

                case "Mesto":
                    txtMesto.Focus();
                    break;

                default:
                    throw new ArgumentException();
            }
        }

        protected override DomainObject createNewEntity()
        {
            return new Klub();
        }

        protected override void updateEntityFromUI(DomainObject entity)
        {
            Klub klub = (Klub)entity;
            klub.Naziv = txtNaziv.Text.Trim();
            klub.Kod = txtKod.Text.Trim().ToUpper();
            klub.Mesto = txtMesto.Text.Trim();
            klub.Adresa = txtAdresa.Text.Trim();
            klub.Telefon1 = txtTelefon1.Text.Trim();
            klub.Telefon2 = txtTelefon2.Text.Trim();
        }

        protected override void updateEntity(DomainObject entity)
        {
            DAOFactoryFactory.DAOFactory.GetKlubDAO().Update((Klub)entity);
        }

        protected override void addEntity(DomainObject entity)
        {
            DAOFactoryFactory.DAOFactory.GetKlubDAO().Add((Klub)entity);
        }

        protected override void checkBusinessRulesOnAdd(DomainObject entity)
        {
            Klub klub = (Klub)entity;
            Notification notification = new Notification();

            KlubDAO klubDAO = DAOFactoryFactory.DAOFactory.GetKlubDAO();
            if (klubDAO.existsKlubNaziv(klub.Naziv))
            {
                notification.RegisterMessage("Naziv", "Klub sa datim nazivom vec postoji.");
                throw new BusinessException(notification);
            }

            if (klubDAO.existsKlubKod(klub.Kod))
            {
                notification.RegisterMessage("Kod", "Klub sa datim kodom vec postoji.");
                throw new BusinessException(notification);
            }
        }

        protected override void checkBusinessRulesOnUpdate(DomainObject entity)
        {
            Klub klub = (Klub)entity;
            Notification notification = new Notification();
            KlubDAO klubDAO = DAOFactoryFactory.DAOFactory.GetKlubDAO();

            bool nazivChanged = (klub.Naziv.ToUpper() != oldNaziv.ToUpper()) ? true : false;
            if (nazivChanged && klubDAO.existsKlubNaziv(klub.Naziv))
            {
                notification.RegisterMessage("Naziv", "Klub sa datim nazivom vec postoji.");
                throw new BusinessException(notification);
            }

            bool kodChanged = (klub.Kod.ToUpper() != oldKod.ToUpper()) ? true : false;
            if (kodChanged && klubDAO.existsKlubKod(klub.Kod))
            {
                notification.RegisterMessage("Kod", "Klub sa datim kodom vec postoji.");
                throw new BusinessException(notification);
            }
        }

        private void KlubForm_Shown(object sender, EventArgs e)
        {
            if (!editMode)
                txtNaziv.Focus();
        }
    }
}

