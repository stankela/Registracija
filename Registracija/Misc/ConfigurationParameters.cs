using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Registracija
{
    static class ConfigurationParameters
    {
        public static int ItemsPerPage
        {
            get
            {
                try
                {
                    return int.Parse(ConfigurationManager.AppSettings["ItemsPerPage"]);
                }
                catch
                {
                    return 20;
                }
            }
        }

        public static string DatabaseFile
        {
            get { return "RegistracijaPodaci.sdf"; }
        }

        public static string ConnectionString
        {
            get { return String.Format("Data Source={0}", DatabaseFile); }
        }

        public static string FotografijeFolder
        {
            get { return @"Dokumenti\Fotografije"; }
        }

        public static string IzvodiMKRFolder
        {
            get { return @"Dokumenti\IzvodiMKR"; }
        }
    }
}