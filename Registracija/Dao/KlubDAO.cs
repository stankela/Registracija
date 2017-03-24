using System;
using System.Collections.Generic;
using System.Text;
using Registracija.Domain;

namespace Registracija.Dao
{
    public interface KlubDAO : GenericDAO<Klub, int>
    {
        IList<Klub> FindAll();
        Klub FindByNaziv(string naziv);
        bool existsKlubNaziv(string naziv);
    }
}
