using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Linq.Expressions;
using NHibernate.Event;
using NHibernate.Linq;
using NHibernate.Persister.Entity;
using NHibernate.Type;

namespace SisLar.Model.Repository
{
    public class Repositorio<T> : IRepositorio<T>
    {
        public T Retorna(int handle)
        {
            return NHibernateHelper.Session.Get<T>(handle);
        }

        public IQueryable<T> RetornaTodos()
        {
            return (from t in NHibernateHelper.Session.Query<T>()
                    select t);
        }

        public IQueryable<T> Consulta(Expression<Func<T, bool>> where)
        {
            return NHibernateHelper.Session.Query<T>().Where(where);
        }

        public bool Inclui(T entity)
        {
            using (ITransaction newTransaction = NHibernateHelper.Session.BeginTransaction())
            {
                try
                {
                    NHibernateHelper.Session.Save(entity);
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
            using (ITransaction newTransaction = NHibernateHelper.Session.BeginTransaction())
            {
                try
                {
                    NHibernateHelper.Session.Delete(entity);
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

        public bool ExcluirVarios(IQueryable<T> listEntity)
        {
            using (ITransaction newTransaction = NHibernateHelper.Session.BeginTransaction())
            {
                try
                {
                    foreach (var item in listEntity)
                        NHibernateHelper.Session.Delete(item);
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
            using (ITransaction newTransaction = NHibernateHelper.Session.BeginTransaction())
            {
                try
                {
                    NHibernateHelper.Session.Update(entity);
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
            NHibernateHelper.Session.Flush();
        }
    }
}
