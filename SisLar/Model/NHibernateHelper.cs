using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions.Helpers;
using NHibernate.Cfg;

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
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<SisLar.Model.Entities.Usuario>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<SisLar.Model.Entities.Funcionario>())
                .ExposeConfiguration(DropCreateSchema)
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
                    .Password( "admin1" ));
        }

        private static AutoPersistenceModel CreateMappings()
        {
            return AutoMap
                .Assembly(System.Reflection.Assembly.GetCallingAssembly())
                .Where(t => t.Namespace == "SisLar.Model.Entities")
                .Conventions.Setup(c => c.Add(DefaultCascade.SaveUpdate()));
        }

        private static void DropCreateSchema(Configuration cfg)
        {
            new SchemaExport(cfg).Create(true, true);
        }
    }
}
