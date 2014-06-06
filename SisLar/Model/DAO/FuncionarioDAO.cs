using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisLar.Model.Entities;
using System.Collections;
using NHibernate;

namespace SisLar.Model.DAO
{
    public class FuncionarioDAO
    {
        public Funcionario GetByID(int id)
        {
            return (Funcionario)NHibernateConf.Session.Get("Funcionario", id);
        }

        public IList GetAll()
        {
            return NHibernateConf.Session.CreateCriteria(typeof(Funcionario)).List();
        }

        public bool SaveOrUpdate(Funcionario entity)
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

        public bool Delete(Funcionario entity)
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
    }
}
