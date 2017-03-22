using Registracija.Dao;
using Registracija.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registracija.UI
{
    public partial class SelectGimnasticarBiltenForm : Form
    {
        private readonly string SVI_KLUBOVI = "Svi klubovi";
        private readonly string SVI = "Svi";
        private readonly string MSG = "MSG";
        private readonly string ZSG = "ZSG";

        private IList<GimnasticarBilten> sviGimnasticari;
        private List<string> klubovi;
        public List<GimnasticarBilten> SelektovaniGimnasticari = new List<GimnasticarBilten>();
        
        public SelectGimnasticarBiltenForm()
        {
            InitializeComponent();
            Text = "Izaberite gimnasticare";

            GimnasticarBiltenDAO dao = new GimnasticarBiltenDAO();
            dao.ConnectionString = Opcije.Instance.BiltenConnectionString;
            sviGimnasticari = dao.findGimnasticariBilten(null, null, null, null);

            Iesi.Collections.Generic.ISet<string> kluboviSet = new Iesi.Collections.Generic.HashedSet<string>();
            foreach (GimnasticarBilten g in sviGimnasticari)
            {
                if (!String.IsNullOrEmpty(g.NazivKluba))
                    kluboviSet.Add(g.NazivKluba);
            }
            klubovi = new List<string>(kluboviSet);

            cmbGimnastika.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGimnastika.Items.AddRange(new string[] { SVI, MSG, ZSG });

            cmbKlub.DropDownStyle = ComboBoxStyle.DropDown;
            cmbKlub.Items.Add(SVI_KLUBOVI);
            cmbKlub.Items.AddRange(klubovi.ToArray());
            cmbKlub.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbKlub.AutoCompleteSource = AutoCompleteSource.ListItems;

            resetFilter();
            
            initializeGridColumns();

            dataGridViewUserControl1.GridColumnHeaderMouseClick += new EventHandler<GridColumnHeaderMouseClickEventArgs>(
                DataGridViewUserControl_GridColumnHeaderMouseClick);

            showAll();
        }

        public void resetFilter()
        {
            txtIme.Text = String.Empty;
            txtPrezime.Text = String.Empty;
            cmbGimnastika.SelectedIndex = cmbGimnastika.Items.IndexOf(SVI);
            cmbKlub.SelectedIndex = cmbKlub.Items.IndexOf(SVI_KLUBOVI);
        }

        void DataGridViewUserControl_GridColumnHeaderMouseClick(object sender, GridColumnHeaderMouseClickEventArgs e)
        {
            DataGridViewUserControl dgwuc = sender as DataGridViewUserControl;
            if (dgwuc != null)
                dgwuc.onColumnHeaderMouseClick<GimnasticarBilten>(e.DataGridViewCellMouseEventArgs);
        }

        private void initializeGridColumns()
        {
            dataGridViewUserControl1.AddColumn("Ime", "Ime", 100);
            dataGridViewUserControl1.AddColumn("Prezime", "Prezime", 100);
            dataGridViewUserControl1.AddColumn("Datum rodjenja", "DatumRodjenja", 100, "{0:d}");
            dataGridViewUserControl1.AddColumn("Gimnastika", "Gimnastika", 70);
            dataGridViewUserControl1.AddColumn("Kategorija", "NazivKategorije", 150);
            dataGridViewUserControl1.AddColumn("Klub", "NazivKluba", 200);
        }

        private void showAll()
        {
            dataGridViewUserControl1.setItems<GimnasticarBilten>(sviGimnasticari);
            dataGridViewUserControl1.sort<GimnasticarBilten>(
                new string[] { "Prezime", "Ime" },
                new ListSortDirection[] { ListSortDirection.Ascending, ListSortDirection.Ascending });
        }

        private void btnFiltriraj_Click(object sender, EventArgs e)
        {
            Nullable<Gimnastika> gimnastika = null;
            if (cmbGimnastika.SelectedIndex == cmbGimnastika.Items.IndexOf(MSG))
                gimnastika = Gimnastika.MSG;
            else if (cmbGimnastika.SelectedIndex == cmbGimnastika.Items.IndexOf(ZSG))
                gimnastika = Gimnastika.ZSG;
            string klub = cmbKlub.SelectedItem as string;
            if (klub == SVI_KLUBOVI)
                klub = String.Empty;

            GimnasticarBiltenDAO dao = new GimnasticarBiltenDAO();
            dao.ConnectionString = Opcije.Instance.BiltenConnectionString;
            IList<GimnasticarBilten> gimnasticari = dao.findGimnasticariBilten(txtIme.Text.Trim(), txtPrezime.Text.Trim(),
                gimnastika, klub);

            dataGridViewUserControl1.setItems<GimnasticarBilten>(gimnasticari);
            if (gimnasticari.Count == 0)
                MessageDialogs.showMessage("Ne postoje gimnasticari koji zadovoljavaju date kriterijume", this.Text);
            dataGridViewUserControl1.clearSelection();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dataGridViewUserControl1.DataGridView.SelectedRows.Count == 0)
            {
                MessageDialogs.showMessage("Selektujte gimnasticare", this.Text);
                DialogResult = DialogResult.None;
                return;
            }

            SelektovaniGimnasticari.Clear();
            foreach (DataGridViewRow row in dataGridViewUserControl1.DataGridView.SelectedRows)
            {
                SelektovaniGimnasticari.Add(row.DataBoundItem as GimnasticarBilten);
            }
        }

        private void SelectGimnasticarBiltenForm_Shown(object sender, EventArgs e)
        {
            dataGridViewUserControl1.clearSelection();
        }
    }
}
