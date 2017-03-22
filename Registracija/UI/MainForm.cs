using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Registracija.Exceptions;

namespace Registracija.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void mnGimnasticari_Click(object sender, EventArgs e)
        {
            try
            {
                GimnasticariForm form = new GimnasticariForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                // NOTE: Izuzetak moze da potice samo iz konstruktora. Kada se form
                // uspesno kreira i prikaze pozivom ShowDialog (ili Show), tada se
                // izuzetci unutar forma ne propagiraju do koda koji je pozvao
                // ShowDialog.
                MessageDialogs.showError(ex.Message, this.Text);
            }
        }

        private void mnKlubovi_Click(object sender, EventArgs e)
        {
            try
            {
                KluboviForm form = new KluboviForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageDialogs.showError(ex.Message, this.Text);
            }
        }

        private void mnKategorijeGimnasticara_Click(object sender, EventArgs e)
        {
            try
            {
                KategorijeGimnasticaraForm form = new KategorijeGimnasticaraForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageDialogs.showError(ex.Message, this.Text);
            }
        }

        private void mnSudije_Click(object sender, EventArgs e)
        {
            try
            {
                SudijeForm form = new SudijeForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageDialogs.showError(ex.Message, this.Text);
            }
        }
    }
}
