using System;
using System.Collections.Generic;
using NHibernate;
using Registracija.Exceptions;
using Registracija.Domain;

namespace Registracija.Dao.NHibernate
{
    public class KlubDAOImpl : GenericNHibernateDAO<Klub, int>, KlubDAO
    {
        #region KlubDAO Members

        public IList<Klub> FindAll()
        {
            try
            {
                IQuery q = Session.CreateQuery(@"from Klub k order by k.Naziv asc");
                return q.List<Klub>();
            }
            catch (HibernateException ex)
            {
                throw new InfrastructureException(Strings.getFullDatabaseAccessExceptionMessage(ex), ex);
            }
        }

        public Klub FindByNaziv(string naziv)
        {
            try
            {
                IQuery q = Session.CreateQuery(@"from Klub k
                    where k.Naziv like :naziv");
                q.SetString("naziv", naziv);
                IList<Klub> result = q.List<Klub>();
                if (result.Count > 0)
                    return result[0];
                return null;
            }
            catch (HibernateException ex)
            {
                throw new InfrastructureException(Strings.getFullDatabaseAccessExceptionMessage(ex), ex);
            }
        }

        public bool existsKlubNaziv(string naziv)
        {
            try
            {
                IQuery q = Session.CreateQuery(@"select count(*) from Klub k where k.Naziv like :naziv");
                q.SetString("naziv", naziv);
                return (long)q.UniqueResult() > 0;
            }
            catch (HibernateException ex)
            {
                throw new InfrastructureException(Strings.getFullDatabaseAccessExceptionMessage(ex), ex);
            }
        }

        public bool existsKlubKod(string kod)
        {
            try
            {
                IQuery q = Session.CreateQuery(@"select count(*) from Klub k where k.Kod like :kod");
                q.SetString("kod", kod);
                return (long)q.UniqueResult() > 0;
            }
            catch (HibernateException ex)
            {
                throw new InfrastructureException(Strings.getFullDatabaseAccessExceptionMessage(ex), ex);
            }
        }

        #endregion
    }
}