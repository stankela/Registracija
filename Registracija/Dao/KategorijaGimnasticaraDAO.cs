using System;
using System.Collections.Generic;
using System.Text;
using Registracija.Domain;

namespace Registracija.Dao
{
    public interface KategorijaGimnasticaraDAO : GenericDAO<KategorijaGimnasticara, int>
    {
        IList<KategorijaGimnasticara> FindAll();
        IList<KategorijaGimnasticara> FindByGimnastika(Gimnastika gimnastika);
        KategorijaGimnasticara FindByNaziv(string naziv);
        bool existsKategorijaGimnasticara(string naziv, Gimnastika gimnastika);
    }
}
