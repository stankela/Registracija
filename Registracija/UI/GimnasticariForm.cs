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
using NHibernate;
using NHibernate.Context;
using Registracija.Dao;

namespace Registracija.UI
{
    public partial class GimnasticariForm : SingleEntityListForm<Gimnasticar>
    {
        public GimnasticariForm()
        {
            this.Text = "Gimnasticari";
            this.ClientSize = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width - 20, 540);
            this.btnUveziIzBiltena.Visible = true;
            this.btnUveziIzBiltena.Click += btnUveziIzBiltena_Click;
            this.btnPrintPreview.Visible = true;
            this.btnPrintPreview.Text = "Rezultati";
            this.btnPrintPreview.Click += btnRezultati_Click;
    
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
                    IList<Gimnasticar> gimnasticari = DAOFactoryFactory.DAOFactory.GetGimnasticarDAO().FindAll();
                    SetItems(gimnasticari);
                    dataGridViewUserControl1.sort<Gimnasticar>(
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

        protected override void prikaziSve()
        {
            ISession session = null;
            try
            {
                using (session = NHibernateHelper.Instance.OpenSession())
                using (session.BeginTransaction())
                {
                    CurrentSessionContext.Bind(session);
                    IList<Gimnasticar> gimnasticari = DAOFactoryFactory.DAOFactory.GetGimnasticarDAO().FindAll();
                    SetItems(gimnasticari);
                    dataGridViewUserControl1.sort<Gimnasticar>(
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
                dgwuc.onColumnHeaderMouseClick<Gimnasticar>(e.DataGridViewCellMouseEventArgs);
        }

        private void InitializeGridColumns()
        {
            AddColumn("Ime", "ImeSrednjeIme", 100);
            AddColumn("Prezime", "Prezime", 100);
            AddColumn("Datum rodjenja", "DatumRodjenja", 100, "{0:d}");
            AddColumn("Gimnastika", "Gimnastika", 70);
            AddColumn("Klub", "Klub", 200);
            AddColumn("Kategorija", "Kategorija", 150);
            AddColumn("Trener", "Trener", 150);
            AddColumn("Registracioni broj", "RegistarskiBroj", 100);
            AddColumn("Poslednja registr.", "DatumPoslednjeRegistracije", 100, "{0:d}");
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
            return new GimnasticarForm(entityId);
        }

        protected override string deleteConfirmationMessage(Gimnasticar gimnasticar)
        {
            return String.Format("Da li zelite da izbrisete gimnasticara \"{0}\"?", gimnasticar);
        }

        protected override string deleteErrorMessage()
        {
            return "Neuspesno brisanje gimnasticara.";
        }

        protected override void delete(Gimnasticar g)
        {
            DAOFactoryFactory.DAOFactory.GetGimnasticarDAO().Delete(g);
        }

        protected override void onApplyFilter()
        {
            if (filterForm == null || filterForm.IsDisposed)
            {
                // NOTE: IsDisposed je true kada se form zatvori (bilo pritiskom na X
                // ili pozivom Close)

                try
                {
                    filterForm = new FilterGimnasticarForm(null); // can throw
                    filterForm.Filter += new EventHandler(filterForm_Filter);
                    filterForm.Show();
                }
                catch (InfrastructureException ex)
                {
                    MessageDialogs.showError(ex.Message, this.Text);
                }
            }
            else
            {
                filterForm.Activate();
            }
        }

        private void filterForm_Filter(object sender, EventArgs e)
        {
            object filterObject = filterForm.FilterObject;
            if (filterObject != null)
                filter(filterObject);
        }

        private void filter(object filterObject)
        {
            GimnasticarFilter flt = filterObject as GimnasticarFilter;
            if (flt == null)
                return;

            ISession session = null;
            try
            {
                using (session = NHibernateHelper.Instance.OpenSession())
                using (session.BeginTransaction())
                {
                    CurrentSessionContext.Bind(session);

                    // biranje gimnasticara sa prethodnog takmicenja
                    //Takmicenje takmicenje = dataContext.GetById<Takmicenje>(5);
                    //gimnasticari = dataContext.ExecuteNamedQuery<Gimnasticar>(
                    //    "FindGimnasticariByTakmicenje",
                    //    new string[] { "takmicenje" }, new object[] { takmicenje });

                    IList<Gimnasticar> gimnasticari;
                    string failureMsg = "";
                    if (!String.IsNullOrEmpty(flt.RegBroj))
                    {
                        gimnasticari = DAOFactoryFactory.DAOFactory.GetGimnasticarDAO().FindGimnasticariByRegBroj(flt.RegBroj);
                        if (gimnasticari.Count == 0)
                            failureMsg = "Ne postoji gimnasticar sa datim registarskim brojem.";
                    }
                    else
                    {
                        gimnasticari = DAOFactoryFactory.DAOFactory.GetGimnasticarDAO().FindGimnasticari(flt.Ime,
                            flt.Prezime, flt.GodRodj, flt.Gimnastika, flt.Kategorija, flt.Klub);
                        if (gimnasticari.Count == 0)
                            failureMsg = "Ne postoje gimnasticari koji zadovoljavaju date kriterijume.";
                    }
                    SetItems(gimnasticari);
                    updateEntityCount();
                    if (gimnasticari.Count == 0)
                        MessageDialogs.showMessage(failureMsg, this.Text);
                }
            }
            catch (Exception ex)
            {
                if (session != null && session.Transaction != null && session.Transaction.IsActive)
                    session.Transaction.Rollback();
                MessageDialogs.showError(
                    Strings.getFullDatabaseAccessExceptionMessage(ex), this.Text);
            }
            finally
            {
                CurrentSessionContext.Unbind(NHibernateHelper.Instance.SessionFactory);
            }
        }

        protected override void AddNew()
        {
            try
            {
                GimnasticarForm form = (GimnasticarForm)createEntityDetailForm(null);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.GimnasticarToEdit == null)
                    {
                        Gimnasticar newEntity = (Gimnasticar)form.Entity;
                        List<Gimnasticar> items = dataGridViewUserControl1.getItems<Gimnasticar>();
                        items.Add(newEntity);
                        dataGridViewUserControl1.setItems<Gimnasticar>(items);
                        dataGridViewUserControl1.setSelectedItem<Gimnasticar>(newEntity);
                        updateEntityCount();
                    }
                    else
                    {
                        List<Gimnasticar> items = dataGridViewUserControl1.getItems<Gimnasticar>();
                        Gimnasticar g = form.GimnasticarToEdit;
                        if (items.IndexOf(g) == -1)
                        {
                            items.Add(g);
                            dataGridViewUserControl1.setItems<Gimnasticar>(items);
                            updateEntityCount();
                        }
                        dataGridViewUserControl1.setSelectedItem<Gimnasticar>(g);
                        Edit(g);
                    }
                }
            }
            catch (InfrastructureException ex)
            {
                MessageDialogs.showError(ex.Message, this.Text);
            }
        }

        public override void Edit()
        {
            if (SelectedItem == null)
                return;
            int index = dataGridViewUserControl1.getSelectedItemIndex();

            try
            {
                GimnasticarForm form = (GimnasticarForm)createEntityDetailForm(SelectedItem.Id);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.GimnasticarToEdit == null)
                    {
                        Gimnasticar entity = (Gimnasticar)form.Entity;
                        List<Gimnasticar> items = dataGridViewUserControl1.getItems<Gimnasticar>();
                        items[index] = entity;
                        dataGridViewUserControl1.setItems<Gimnasticar>(items);  // ovo ponovo sortira items
                        dataGridViewUserControl1.setSelectedItem<Gimnasticar>(entity);
                    }
                    else
                    {
                        List<Gimnasticar> items = dataGridViewUserControl1.getItems<Gimnasticar>();
                        Gimnasticar g = form.GimnasticarToEdit;
                        if (items.IndexOf(g) == -1)
                        {
                            items.Add(g);
                            dataGridViewUserControl1.setItems<Gimnasticar>(items);
                            updateEntityCount();
                        }
                        dataGridViewUserControl1.setSelectedItem<Gimnasticar>(g);
                        Edit(g);
                    }                                                                                
                }
            }
            catch (InfrastructureException ex)
            {
                MessageDialogs.showError(ex.Message, this.Text);
            }
        }

        // Ovaj metod je u sustini isti kao i Edit() metod. Poziva se kada se prilikom dodavanja novog gimnasticara ili
        // menjanja postojeceg predje u rezim rada kada se izabere novi gimnasticar ciji ce se podaci menjati. Glavni
        // razlog zasto tada pozivam ovaj metod a ne obican Edit() metod je sto postoji situacija kada naredba
        // dataGridViewUserControl1.setSelectedItem<Gimnasticar>(g) koja se poziva na kraju AddNew() i Edit() metoda
        // (u rezimu rada kada se u dijalogu izabrao novi gimnasticar ciji ce se podaci menjati) nece selektovati
        // element, i onda ce provera if (SelectedItem == null) na pocetku obicnog Edit() biti tacna i metod se nece
        // izvrsiti. A ta situacija je sledeca: kada je gimnasticar oznacen sa kursorom, a nije obojen u plavo (sto se
        // desi npr kada najpre selektujem gimnasticara, i onda kliknem van grida, tako da se boja izgubi i kursor ostaje.
        private void Edit(Gimnasticar selItem)
        {
            List<Gimnasticar> items = dataGridViewUserControl1.getItems<Gimnasticar>();
            int index = items.IndexOf(selItem);

            try
            {
                GimnasticarForm form = (GimnasticarForm)createEntityDetailForm(selItem.Id);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.GimnasticarToEdit == null)
                    {
                        Gimnasticar entity = (Gimnasticar)form.Entity;
                        items[index] = entity;
                        dataGridViewUserControl1.setItems<Gimnasticar>(items);  // ovo ponovo sortira items
                        dataGridViewUserControl1.setSelectedItem<Gimnasticar>(entity);
                    }
                    else
                    {
                        Gimnasticar g = form.GimnasticarToEdit;
                        if (items.IndexOf(g) == -1)
                        {
                            items.Add(g);
                            dataGridViewUserControl1.setItems<Gimnasticar>(items);
                            updateEntityCount();
                        }
                        dataGridViewUserControl1.setSelectedItem<Gimnasticar>(g);
                        Edit(g);
                    }
                }
            }
            catch (InfrastructureException ex)
            {
                MessageDialogs.showError(ex.Message, this.Text);
            }
        }

        protected override void updateEntityCount()
        {
            int count = dataGridViewUserControl1.getItems<Gimnasticar>().Count;
            if (count == 1)
                StatusPanel.Panels[0].Text = count.ToString() + " gimnasticar";
            else
                StatusPanel.Panels[0].Text = count.ToString() + " gimnasticara";
        }

        void btnUveziIzBiltena_Click(object sender, EventArgs e)
        {
            if (Opcije.Instance.BiltenConnectionString == null)
            {
                MessageDialogs.showMessage("Pronadjite folder za bilten i selektujte fajl 'BiltenPodaci.sdf'.", "Registracija");
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                Opcije.Instance.BiltenConnectionString = String.Format(@"Data Source={0}", ofd.FileName);
            }

            SelectGimnasticarBiltenForm form = new SelectGimnasticarBiltenForm();
            if (form.ShowDialog() != DialogResult.OK)
                return;
            
            IList<Gimnasticar> noviGimnasticari = new List<Gimnasticar>();

            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();
            bool ok = false;
            ISession session = null;
            try
            {
                using (session = NHibernateHelper.Instance.OpenSession())
                using (session.BeginTransaction())
                {
                    CurrentSessionContext.Bind(session);
                    GimnasticarDAO gimDAO = DAOFactoryFactory.DAOFactory.GetGimnasticarDAO();

                    KlubDAO klubDAO = DAOFactoryFactory.DAOFactory.GetKlubDAO();
                    KategorijaGimnasticaraDAO katDAO = DAOFactoryFactory.DAOFactory.GetKategorijaGimnasticaraDAO();

                    IDictionary<Klub, Klub> klubovi = new Dictionary<Klub, Klub>();
                    foreach (Klub k in klubDAO.FindAll())
                        klubovi.Add(k, k);
                    IDictionary<KategorijaGimnasticara, KategorijaGimnasticara> kategorije
                        = new Dictionary<KategorijaGimnasticara, KategorijaGimnasticara>();
                    foreach (KategorijaGimnasticara kat in katDAO.FindAll())
                        kategorije.Add(kat, kat);

                    foreach (GimnasticarBilten g in form.SelektovaniGimnasticari)
                    {
                        if (!gimDAO.existsGimnasticarImePrezimeSrednjeImeDatumRodjenja(g.Ime, g.Prezime, g.SrednjeIme,
                            g.DatumRodjenja))
                        {
                            Gimnasticar gim = createGimnasticar(g, klubDAO, katDAO, klubovi, kategorije);
                            noviGimnasticari.Add(gim);
                            gimDAO.Add(gim);
                        }
                    }

                    session.Transaction.Commit();
                    ok = true;
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
                Cursor.Hide();
                Cursor.Current = Cursors.Arrow;
                CurrentSessionContext.Unbind(NHibernateHelper.Instance.SessionFactory);
            }

            if (ok)
            {
                List<Gimnasticar> items = dataGridViewUserControl1.getItems<Gimnasticar>();
                foreach (Gimnasticar g in noviGimnasticari)
                {
                    items.Add(g);
                }
                dataGridViewUserControl1.setItems<Gimnasticar>(items);
                dataGridViewUserControl1.clearSelection();
                updateEntityCount();
            }
        }

        private Gimnasticar createGimnasticar(GimnasticarBilten g, KlubDAO klubDAO, KategorijaGimnasticaraDAO katDAO,
            IDictionary<Klub, Klub> klubovi, IDictionary<KategorijaGimnasticara, KategorijaGimnasticara> kategorije)
        {
            Gimnasticar result = new Gimnasticar();
            result.Ime = g.Ime;
            result.SrednjeIme = g.SrednjeIme;
            result.Prezime = g.Prezime;
            result.DatumRodjenja = g.DatumRodjenja;
            result.Gimnastika = g.Gimnastika;
            if (String.IsNullOrEmpty(g.NazivKluba))
                result.Klub = null;
            else
            {
                Klub klub = new Klub();
                klub.Naziv = g.NazivKluba;
                klub.Mesto = g.MestoKluba;
                if (!klubovi.ContainsKey(klub))
                {
                    klubovi.Add(klub, klub);
                    klubDAO.Add(klub);
                }
                else
                    klub = klubovi[klub];
                result.Klub = klub;
            }
            if (String.IsNullOrEmpty(g.NazivKategorije))
                result.Kategorija = null;
            else
            {
                KategorijaGimnasticara kat = new KategorijaGimnasticara();
                kat.Naziv = g.NazivKategorije;
                kat.Gimnastika = g.Gimnastika;
                if (!kategorije.ContainsKey(kat))
                {
                    kategorije.Add(kat, kat);
                    katDAO.Add(kat);
                }
                else
                    kat = kategorije[kat];
                result.Kategorija = kat;
            }
            return result;
        }

        void btnRezultati_Click(object sender, EventArgs e)
        {
            if (SelectedItem == null)
                return;

            if (Opcije.Instance.BiltenConnectionString == null)
            {
                MessageDialogs.showMessage("Pronadjite folder za bilten i selektujte fajl 'BiltenPodaci.sdf'.", "Registracija");
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                Opcije.Instance.BiltenConnectionString = String.Format(@"Data Source={0}", ofd.FileName);
            }

            KonacanPlasmanDAO kpDAO = new KonacanPlasmanDAO();
            kpDAO.ConnectionString = Opcije.Instance.BiltenConnectionString;

            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();
            List<KonacanPlasman> plasmani;
            try
            {
                List<KonacanPlasman> visebojTak1 = kpDAO.findVisebojTak1(SelectedItem.Ime, SelectedItem.Prezime);
                List<KonacanPlasman> visebojTak2 = kpDAO.findVisebojTak2(SelectedItem.Ime, SelectedItem.Prezime);
                List<KonacanPlasman> visebojFinaleKupa = kpDAO.findVisebojFinaleKupa(SelectedItem.Ime, SelectedItem.Prezime);
                List<KonacanPlasman> visebojZbirViseKola = kpDAO.findVisebojZbirViseKola(SelectedItem.Ime, SelectedItem.Prezime);
                List<KonacanPlasman> spraveTak1 = kpDAO.findSpraveTak1(SelectedItem.Ime, SelectedItem.Prezime);
                List<KonacanPlasman> spraveTak3 = kpDAO.findSpraveTak3(SelectedItem.Ime, SelectedItem.Prezime);
                List<KonacanPlasman> preskokTak1 = kpDAO.findPreskokTak1(SelectedItem.Ime, SelectedItem.Prezime);
                List<KonacanPlasman> preskokTak3 = kpDAO.findPreskokTak3(SelectedItem.Ime, SelectedItem.Prezime);
                List<KonacanPlasman> spraveFinaleKupa = kpDAO.findSpraveFinaleKupa(SelectedItem.Ime, SelectedItem.Prezime);

                List<KonacanPlasman> viseboj = new List<KonacanPlasman>();
                viseboj.AddRange(visebojFinaleKupa);
                viseboj.AddRange(visebojZbirViseKola);
                viseboj.AddRange(visebojTak1);
                viseboj.AddRange(visebojTak2);

                List<KonacanPlasman> sprave = new List<KonacanPlasman>();
                // Dodajem najpre finale kupa da bi, ako je postojalo odvojeno takmicenje 3 finale kupa, rezultati prebrisali
                // ove rezultate (za one gimnasticare koji su ucestvovali u odvojenom finalu kupa). Iz istog razloga najpre
                // dodajem spraveTak1 pa spraveTak3.
                sprave.AddRange(spraveFinaleKupa);
                sprave.AddRange(spraveTak1);
                sprave.AddRange(spraveTak3);
                sprave.AddRange(preskokTak1);
                sprave.AddRange(preskokTak3);

                Dictionary<int, KonacanPlasman> plasmaniMap = new Dictionary<int, KonacanPlasman>();
                foreach (KonacanPlasman kp in viseboj)
                {
                    if (plasmaniMap.ContainsKey(kp.RezultatskoTakmicenjeId))
                    {
                        if (kp.Viseboj != null)
                            plasmaniMap[kp.RezultatskoTakmicenjeId].Viseboj = kp.Viseboj;
                    }
                    else
                        plasmaniMap.Add(kp.RezultatskoTakmicenjeId, kp);
                }
                foreach (KonacanPlasman kp in sprave)
                {
                    if (plasmaniMap.ContainsKey(kp.RezultatskoTakmicenjeId))
                        updatePlasmanSprava(plasmaniMap[kp.RezultatskoTakmicenjeId], kp);
                    else
                        plasmaniMap.Add(kp.RezultatskoTakmicenjeId, kp);
                }

                plasmani = new List<KonacanPlasman>(plasmaniMap.Values);
            }
            finally
            {
                Cursor.Hide();
                Cursor.Current = Cursors.Arrow;
            }

            if (plasmani.Count == 0)
            {
                MessageDialogs.showMessage("Ne postoje rezultati za gimnasticara '" +
                    SelectedItem.ImeSrednjeImePrezimeDatumRodjenja + "'.", "Rezultati");
            }
            else
            {
                KonacanPlasmanForm form = new KonacanPlasmanForm(plasmani, SelectedItem.Gimnastika);
                form.ShowDialog();
            }
        }

        private void updatePlasmanSprava(KonacanPlasman totalPlasman, KonacanPlasman kp)
        {
            if (kp.Parter != null)
                totalPlasman.Parter = kp.Parter;
            else if (kp.Konj != null)
                totalPlasman.Konj = kp.Konj;
            else if (kp.Karike != null)
                totalPlasman.Karike = kp.Karike;
            else if (kp.Preskok != null)
                totalPlasman.Preskok = kp.Preskok;
            else if (kp.Razboj != null)
                totalPlasman.Razboj = kp.Razboj;
            else if (kp.Vratilo != null)
                totalPlasman.Vratilo = kp.Vratilo;
            else if (kp.DvovisinskiRazboj != null)
                totalPlasman.DvovisinskiRazboj = kp.DvovisinskiRazboj;
            else if (kp.Greda != null)
                totalPlasman.Greda = kp.Greda;
        }
    }
}
