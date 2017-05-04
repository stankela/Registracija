using System;
using System.Collections.Generic;
using System.Text;

namespace Registracija
{
    public static class Strings
    {
        public static readonly string DATABASE_ACCESS_ERROR_MSG =
            "Greska prilikom pristupa bazi podataka.";

        public static string getFullDatabaseAccessExceptionMessage(Exception ex)
        {
            return String.Format(
                "{0} \n\n{1}", Strings.DATABASE_ACCESS_ERROR_MSG, ex.Message);
        }
    }
}
