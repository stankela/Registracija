using System;
using System.Collections.Generic;
using System.Text;
using Registracija.Domain;

namespace Registracija.Dao
{
    public interface MestoDAO : GenericDAO<Mesto, int>
    {
        IList<Mesto> FindAll(bool sorted = false);
        bool existsMestoNaziv(string naziv);
    }
}
