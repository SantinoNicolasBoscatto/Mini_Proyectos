using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application
{
    // Creo un metodo que recibira una expresion que servira como filtrado dinamico
    public interface IRepositorySearch<TModel, TEntity>
    {
        Task<IEnumerable<TEntity>> GetFiltrado(Expression<Func<TModel, bool>> predicate);
    }
}
