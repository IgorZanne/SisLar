using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Event;
using NHibernate.Exceptions;
using NHibernate.Hql;
using NHibernate.Linq;
using NHibernate.Mapping.ByCode;
using NHibernate.Persister.Entity;
using FluentNHibernate.Automapping;
using NHibernate.Tool.hbm2ddl;

namespace SisLar.Model
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)

                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }

        private static ISession _session = null;
        public static ISession Session
        {
            get
            {
                if (_session == null || !_session.IsOpen)
                    _session = _sessionFactory.OpenSession();

                return _session;
            }
        }

        public static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(CreateDbConfig())
                .Mappings(m => m.AutoMappings.Add(CreateMappings()))
                .ExposeConfiguration(config => new SchemaExport(config).Execute(true, false, true))
                //.ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, true))
                .ExposeConfiguration(x => x.SetProperty("connection.release_mode", "on_close"))
                .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private static MsSqlConfiguration CreateDbConfig()
        {
            return MsSqlConfiguration
                .MsSql2008
                .ConnectionString( c => c
                    .Server( "ZANNE-PC\\SQLEXPRESS" )
                    .Database( "BD_SISLAR" )
                    .Username( "sa" )
                    .Password( "admin1" ))
                .DefaultSchema("dbo")
                .ShowSql();
        }

        private static AutoPersistenceModel CreateMappings()
        {
            return AutoMap
                .Assembly(System.Reflection.Assembly.GetCallingAssembly())
                .Where(t => t.Namespace == "SisLar.Model.Entities");
        }
    }
}
