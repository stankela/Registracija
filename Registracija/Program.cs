﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Registracija.UI;
using System.IO;
using System.Threading;
using System.Globalization;
using Registracija.Dao;

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
                int verzijaBaze = SqlCeUtilities.getDatabaseVersionNumber();
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
                        SqlCeUtilities.ExecuteScript(ConfigurationParameters.DatabaseFile, "",
                            "Registracija.Update.DatabaseUpdate_version2.sql", true);
                        verzijaBaze = 2;
                        converted = true;
                    }

                    if (converted)
                    {
                        string msg = String.Format("Baza podataka je konvertovana u verziju {0}.", verzijaBaze);
                        MessageBox.Show(msg, "Bilten");

                        if (File.Exists("NHibernateConfig"))
                        {
                            File.Delete("NHibernateConfig");
                        }
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
