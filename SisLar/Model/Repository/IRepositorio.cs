using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SisLar.Model.Repository
{
    public interface IRepositorio<T>
    {
        T Retorna(int handle);

        IList<T> RetornaTodos();

        bool Inclui(T entity);

        bool Excluir(T entity);

        bool Altera(T entity);
    }
}
