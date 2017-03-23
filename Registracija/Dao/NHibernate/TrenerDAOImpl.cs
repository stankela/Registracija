using System;
using System.Collections.Generic;
using NHibernate;
using Registracija.Exceptions;
using Registracija.Domain;

namespace Registracija.Dao.NHibernate
{
    public class TrenerDAOImpl : GenericNHibernateDAO<Trener, int>, TrenerDAO
    {
        #region TrenerDAO Members

        public IList<Trener> FindAll()
        {
            try
            {
                IQuery q = Session.CreateQuery(@"from Trener t
                    left join fetch t.Klub
                    order by t.Prezime asc, t.Ime asc");
                return q.List<Trener>();
            }
            catch (HibernateException ex)
            {
                throw new InfrastructureException(Strings.getFullDatabaseAccessExceptionMessage(ex), ex);
            }
        }

        public bool existsTrener(string ime, string prezime)
        {
            try
            {
                IQuery q = Session.CreateQuery(@"select count(*) from Trener t
                    where t.Ime like :ime
                    and t.Prezime like :prezime");
                q.SetString("ime", ime);
                q.SetString("prezime", prezime);
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