using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace SisLar.Model.Repository
{
    public class Repositorio<T> : IRepositorio<T>
    {
        public T Retorna(int handle)
        {
            return (T)NHibernateConf.Session.Get(typeof(T), handle);
        }

        public IList<T> RetornaTodos()
        {
            return NHibernateConf.Session.CreateCriteria(typeof(T)).List<T>();
        }

        public bool Inclui(T entity)
        {
            using (ITransaction newTransaction = NHibernateConf.Session.BeginTransaction())
            {
                try
                {
                    NHibernateConf.Session.SaveOrUpdate(entity);
                    newTransaction.Commit();
                }
                catch (Exception e)
                {
                    newTransaction.Rollback();
                    throw e;
                }
            }
            return true;
        }

        public bool Excluir(T entity)
        {
            using (ITransaction newTransaction = NHibernateConf.Session.BeginTransaction())
            {
                try
                {
                    NHibernateConf.Session.Delete(entity);
                    newTransaction.Commit();
                }
                catch (Exception e)
                {
                    newTransaction.Rollback();
                    throw e;
                }
            }
            return true;
        }

        public bool Altera(T entity)
        {
            using (ITransaction newTransaction = NHibernateConf.Session.BeginTransaction())
            {
                try
                {
                    NHibernateConf.Session.Save(entity);
                    newTransaction.Commit();
                }
                catch (Exception e)
                {
                    newTransaction.Rollback();
                    throw e;
                }
            }
            return true;
        }

        public void Atualiza()
        {
            NHibernateConf.Session.Flush();
        }
    }
}
