using System;
using System.Collections.Generic;
using System.Text;
using Registracija.Domain;

namespace Registracija.Dao
{
    public interface KlubDAO : GenericDAO<Klub, int>
    {
        IList<Klub> FindAllFetchMesto();
        IList<Klub> FindAll();
        bool existsKlub(Mesto m);
        bool existsKlubNaziv(string naziv);
        bool existsKlubKod(string kod);
    }
}
