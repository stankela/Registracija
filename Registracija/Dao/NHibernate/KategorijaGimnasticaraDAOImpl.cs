﻿using System;
using System.Collections.Generic;
using NHibernate;
using Registracija.Exceptions;
using Registracija.Domain;

namespace Registracija.Dao.NHibernate
{
    public class KategorijaGimnasticaraDAOImpl : GenericNHibernateDAO<KategorijaGimnasticara, int>, KategorijaGimnasticaraDAO
    {
        #region KategorijaGimnasticaraDAO Members

        public IList<KategorijaGimnasticara> FindAll()
        {
            try
            {
                IQuery q = Session.CreateQuery(@"from KategorijaGimnasticara k
                    order by k.Naziv asc");
                return q.List<KategorijaGimnasticara>();
            }
            catch (HibernateException ex)
            {
                throw new InfrastructureException(Strings.getFullDatabaseAccessExceptionMessage(ex), ex);
            }
        }

        public IList<KategorijaGimnasticara> FindByGimnastika(Gimnastika gimnastika)
        {
            try
            {
                IQuery q = Session.CreateQuery(@"from KategorijaGimnasticara k
                    where k.Gimnastika = :gimnastika
                    order by k.Naziv asc");
                q.SetByte("gimnastika", (byte)gimnastika);
                return q.List<KategorijaGimnasticara>();
            }
            catch (HibernateException ex)
            {
                throw new InfrastructureException(Strings.getFullDatabaseAccessExceptionMessage(ex), ex);
            }
        }

        public KategorijaGimnasticara FindByNaziv(string naziv)
        {
            try
            {
                IQuery q = Session.CreateQuery(@"from KategorijaGimnasticara k
                    where k.Naziv = :naziv");
                q.SetString("naziv", naziv);
                IList<KategorijaGimnasticara> result = q.List<KategorijaGimnasticara>();
                if (result.Count > 0)
                    return result[0];
                return null;
            }
            catch (HibernateException ex)
            {
                throw new InfrastructureException(Strings.getFullDatabaseAccessExceptionMessage(ex), ex);
            }
        }
        
        public bool existsKategorijaGimnasticara(string naziv, Gimnastika gimnastika)
        {
            try
            {
                IQuery q = Session.CreateQuery(@"select count(*) from KategorijaGimnasticara k
                    where k.Naziv = :naziv
                    and k.Gimnastika = :gimnastika");
                q.SetString("naziv", naziv);
                q.SetByte("gimnastika", (byte)gimnastika);
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