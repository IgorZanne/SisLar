using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace SisLar.Model.Repository
{
    public interface IRepositorio<T>
    {
        T Retorna(int handle);

        IQueryable<T> RetornaTodos();

        IQueryable<T> Consulta(Expression<Func<T, bool>> where);

        bool Inclui(T entity);

        bool Excluir(T entity);

        bool ExcluirVarios(IQueryable<T> listEntity);

        bool Altera(T entity);
    }
}
