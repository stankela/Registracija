using System;
using System.Collections.Generic;
using System.Text;
using Registracija.Domain;

namespace Registracija.Dao
{
    public interface KlubDAO : GenericDAO<Klub, int>
    {
        IList<Klub> FindAll();
        bool existsKlubNaziv(string naziv);
        bool existsKlubKod(string kod);
    }
}
