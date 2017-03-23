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
    public partial class TreneriForm : SingleEntityListForm<Trener>
    {
        public TreneriForm()
        {
            this.Text = "Treneri";
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
                    IList<Trener> treneri = DAOFactoryFactory.DAOFactory.GetTrenerDAO().FindAll();
                    SetItems(treneri);
                    dataGridViewUserControl1.sort<Trener>(
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

        private void DataGridViewUserControl_GridColumnHeaderMouseClick(object sender,
            GridColumnHeaderMouseClickEventArgs e)
        {
            DataGridViewUserControl dgwuc = sender as DataGridViewUserControl;
            if (dgwuc != null)
                dgwuc.onColumnHeaderMouseClick<Trener>(e.DataGridViewCellMouseEventArgs);
        }

        private void InitializeGridColumns()
        {
            AddColumn("Ime", "Ime", 100);
            AddColumn("Prezime", "Prezime", 100);
            AddColumn("Pol", "Pol", 100);
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
            return new TrenerForm(entityId);
        }

        protected override string deleteConfirmationMessage(Trener trener)
        {
            return String.Format("Da li zelite da izbrisete trenera \"{0}\"?", trener);
        }

        protected override string deleteErrorMessage()
        {
            return "Neuspesno brisanje trenera.";
        }

        protected override void delete(Trener t)
        {
            DAOFactoryFactory.DAOFactory.GetTrenerDAO().Delete(t);
        }

        protected override void updateEntityCount()
        {
            int count = dataGridViewUserControl1.getItems<Trener>().Count;
            StatusPanel.Panels[0].Text = count.ToString() + " trenera";
        }
    }
}