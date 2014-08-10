using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Transform;

namespace SisLar.Model.Repository
{
    public class SqlHelper
    {
        public IList<T> MontaSQLSelect<T>(ISession session, String tabela, String campo, String valor)
        {
            var sql = String.Format("SELECT * FROM {0} WHERE {1} = {2}", tabela, campo, valor);
            var query = session.CreateSQLQuery(sql);
            var result = query
                .SetResultTransformer(Transformers.DistinctRootEntity)
                .List<T>();

            return result;
        }
    }
}
