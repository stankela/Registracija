namespace Registracija.Dao
{
    public abstract class DAOFactory
    {
        public abstract GimnasticarDAO GetGimnasticarDAO();
        public abstract KlubDAO GetKlubDAO();
        public abstract KategorijaGimnasticaraDAO GetKategorijaGimnasticaraDAO();
        public abstract SudijaDAO GetSudijaDAO();
    }
}