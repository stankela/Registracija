using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Registracija.UI;
using System.IO;
using System.Threading;
using System.Globalization;

namespace Registracija
{
    static class Program
    {
        static int VERZIJA_PROGRAMA = 1;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                int verzijaBaze = DatabaseUpdater.getDatabaseVersionNumber();
                if (verzijaBaze != VERZIJA_PROGRAMA)
                {
                    if (verzijaBaze == 0)
                    {
                        string msg = "Bazu podataka je nemoguce konvertovati da radi sa trenutnom verzijom programa.";
                        MessageBox.Show(msg, "Registracija");
                        return;
                    }
                    if (verzijaBaze > VERZIJA_PROGRAMA)
                    {
                        string msg = "Greska u programu. Verzija baze je veca od verzije programa.";
                        MessageBox.Show(msg, "Registracija");
                        return;
                    }

                    bool converted = false;
                    if (verzijaBaze == 1 && VERZIJA_PROGRAMA > 1)
                    {
                        string databaseFile = "RegistracijaPodaci.sdf";
                        SqlCeUtilities.ExecuteScript(databaseFile, "", Path.GetFullPath(@"DatabaseUpdate_version2.sql"));

                        verzijaBaze = DatabaseUpdater.getDatabaseVersionNumber();
                        string msg = String.Format("Baza podataka je konvertovana u verziju {0}.", verzijaBaze);
                        MessageBox.Show(msg, "Registracija");
                        converted = true;
                    }

                    if (converted && File.Exists("NHibernateConfig"))
                    {
                        File.Delete("NHibernateConfig");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            Language.SetKeyboardLanguage(Language.acKeyboardLanguage.hklSerbianLatin);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("sr-Latn-CS");
            // ili
            // Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("sr-Cyrl-CS");
            //Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



            // Kreiranje prazne baze
            //new SqlCeUtilities().CreateDatabase(@"..\..\clanovi_podaci2.sdf", "sdv");

            //new DatabaseUpdater().updateDatabase();

            //MainForm mainForm = new MainForm();
            //Application.Run(mainForm);
            SingleInstanceApplication.Application.Run(args);
        }
    }
}
