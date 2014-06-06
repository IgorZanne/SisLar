using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace SisLar.Model
{
    public static class NHibernateConf
    {
        private static NHibernate.Cfg.Configuration _configuration { get; set; }

        private static ISessionFactory _sessionFactory { get; set; }

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

        public static void Initialize(string assembly)
        {
            _configuration = new NHibernate.Cfg.Configuration().Configure();
            _configuration.AddAssembly(assembly);
            _sessionFactory = _configuration.BuildSessionFactory();
        }
    }
}
