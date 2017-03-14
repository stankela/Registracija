using System;

namespace Registracija.Dao.NHibernate
{
    /**
	 * Returns NHibernate-specific instances of DAOs.
	 */

    public class NHibernateDAOFactory : DAOFactory
    {
        public override GimnasticarDAO GetGimnasticarDAO()
        {
            return new GimnasticarDAOImpl();
        }
        
        public override KlubDAO GetKlubDAO()
        {
            return new KlubDAOImpl();
        }

        public override DrzavaDAO GetDrzavaDAO()
        {
            return new DrzavaDAOImpl();
        }

        public override KategorijaGimnasticaraDAO GetKategorijaGimnasticaraDAO()
        {
            return new KategorijaGimnasticaraDAOImpl();
        }

        public override MestoDAO GetMestoDAO()
        {
            return new MestoDAOImpl();
        }
    }
}