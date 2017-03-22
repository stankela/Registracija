using System;
using System.Collections.Generic;
using System.Text;
using Registracija.Domain;

namespace Registracija.Dao
{
    public interface SudijaDAO : GenericDAO<Sudija, int>
    {
        IList<Sudija> FindAll();
        bool existsSudija(string ime, string prezime);
    }
}
