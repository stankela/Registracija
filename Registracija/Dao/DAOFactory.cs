namespace Registracija.Dao
{
    public abstract class DAOFactory
    {
        public abstract GimnasticarDAO GetGimnasticarDAO();
        public abstract KlubDAO GetKlubDAO();
        public abstract DrzavaDAO GetDrzavaDAO();
        public abstract KategorijaGimnasticaraDAO GetKategorijaGimnasticaraDAO();
        public abstract MestoDAO GetMestoDAO();
    }
}