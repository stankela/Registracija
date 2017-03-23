using System;
using System.Collections.Generic;
using System.Text;
using Registracija.Domain;

namespace Registracija.Dao
{
    public interface TrenerDAO : GenericDAO<Trener, int>
    {
        IList<Trener> FindAll();
        bool existsTrener(string ime, string prezime);
    }
}