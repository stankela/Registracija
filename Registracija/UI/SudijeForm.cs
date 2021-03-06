using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Registracija.Domain;
using Registracija.Data;
using Registracija.Exceptions;
using NHibernate;
using NHibernate.Context;
using Registracija.Dao;

namespace Registracija.UI
{
    public partial class SudijeForm : SingleEntityListForm<Sudija>
    {
        public SudijeForm()
        {
            this.Text = "Sudije";
            this.ClientSize = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width - 20, 540);
            
            dataGridViewUserControl1.GridColumnHeaderMouseClick +=
                new EventHandler<GridColumnHeaderMouseClickEventArgs>(DataGridViewUserControl_GridColumnHeaderMouseClick);
            dataGridViewUserControl1.ShowBooleanFalse = false;
            InitializeGridColumns();

            ISession session = null;
            try
            {
                using (session = NHibernateHelper.Instance.OpenSession())
                using (session.BeginTransaction())
                {
                    CurrentSessionContext.Bind(session);
                    IList<Sudija> sudije = DAOFactoryFactory.DAOFactory.GetSudijaDAO().FindAll();
                    SetItems(sudije);
                    dataGridViewUserControl1.sort<Sudija>(
                        new string[] { "Prezime", "Ime" },
                        new ListSortDirection[] { ListSortDirection.Ascending, ListSortDirection.Ascending });
                    updateEntityCount();
                }
            }
            catch (Exception ex)
            {
                if (session != null && session.Transaction != null && session.Transaction.IsActive)
                    session.Transaction.Rollback();
                throw new InfrastructureException(ex.Message, ex);
            }
            finally
            {
                CurrentSessionContext.Unbind(NHibernateHelper.Instance.SessionFactory);
            }
        }

        // TODO: Dodaj i druge stvari koje postoje u GimnasticariForm, kao npr. filtriranje, provera prilikom unosa da li
        // sudija vec postoji i ako postoji otvaranje dijaloga za edit.

        private void DataGridViewUserControl_GridColumnHeaderMouseClick(object sender,
            GridColumnHeaderMouseClickEventArgs e)
        {
            DataGridViewUserControl dgwuc = sender as DataGridViewUserControl;
            if (dgwuc != null)
                dgwuc.onColumnHeaderMouseClick<Sudija>(e.DataGridViewCellMouseEventArgs);
        }

        private void InitializeGridColumns()
        {
            AddColumn("Ime", "Ime", 100);
            AddColumn("Prezime", "Prezime", 100);
            AddColumn("Pol", "Pol", 100);
            AddColumn("Poslednje sudijsko zvanje", "PoslednjeSudijskoZvanje", 120);
            AddColumn("Nivo sudijskog zvanja", "NivoSudijskogZvanja", 120);
            AddColumn("God. posl. zvanja", "GodinaPoslednjegSudijskogZvanja", 80);
            AddColumn("God. prvog zvanja", "GodinaPrvogSudijskogZvanja", 85);
            AddColumn("Klub", "Klub", 150);
            AddColumn("Datum rodjenja", "DatumRodjenja", 100, "{0:d}");
            AddColumn("Registracioni broj", "RegistarskiBroj", 100);
            AddColumn("JMBG", "JMBG", 100);
            AddColumn("Mesto", "Mesto", 80);
            AddColumn("Adresa", "Adresa", 140);
            AddColumn("Telefon 1", "Telefon1", 80);
            AddColumn("Telefon 2", "Telefon2", 80);
            AddColumn("E-mail", "Email", 100);
            AddColumn("Foto", "ImaFoto", 40);
            AddColumn("Izvod iz MKR", "ImaIzvodMKR", 47);
        }

        protected override EntityDetailForm createEntityDetailForm(Nullable<int> entityId)
        {
            return new SudijaForm(entityId);
        }

        protected override string deleteConfirmationMessage(Sudija sudija)
        {
            return String.Format("Da li zelite da izbrisete sudiju \"{0}\"?", sudija);
        }

        protected override string deleteErrorMessage()
        {
            return "Neuspesno brisanje sudije.";
        }

        protected override void delete(Sudija s)
        {
            DAOFactoryFactory.DAOFactory.GetSudijaDAO().Delete(s);
        }

        protected override void updateEntityCount()
        {
            int count = dataGridViewUserControl1.getItems<Sudija>().Count;
            StatusPanel.Panels[0].Text = count.ToString() + " sudija";
        }
    }
}