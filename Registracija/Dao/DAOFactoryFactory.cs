using System;
using System.Collections.Generic;
using System.Text;
using Registracija.Dao.NHibernate;

namespace Registracija.Dao
{
    class DAOFactoryFactory
    {
        public static readonly DAOFactory DAOFactory;

        static DAOFactoryFactory()
        {
            DAOFactory = new NHibernateDAOFactory();
        }
    }
}
