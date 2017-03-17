using System;
using System.Collections.Generic;
using System.Text;
using Registracija.Domain;

namespace Registracija.Dao
{
    public interface GimnasticarDAO : GenericDAO<Gimnasticar, int>
    {
        IList<Gimnasticar> FindAll();
        IList<Gimnasticar> FindByGimnastika(Gimnastika gim);
        IList<Gimnasticar> FindGimnasticariByKlub(Klub klub);
        IList<Gimnasticar> FindGimnasticariByKategorija(KategorijaGimnasticara kategorija);
        IList<Gimnasticar> FindGimnasticariByRegBroj(string regBroj);
        IList<Gimnasticar> FindGimnasticari(string ime, string prezime,
            Nullable<int> godRodj, Nullable<Gimnastika> gimnastika,
            KategorijaGimnasticara kategorija, Klub klub);
        bool existsGimnasticar(Klub klub);
        bool existsGimnasticar(KategorijaGimnasticara kategorija);
        bool existsGimnasticarImePrezimeSrednjeImeDatumRodjenja(string ime, string prezime, string srednjeIme,
            Datum datumRodj);
        bool existsGimnasticarRegBroj(string regBroj);
    }
}
