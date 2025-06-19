using Clean_Architecture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application
{
    public interface IRepository<TModel> where TModel : class
    {
        Task<TModel> GetByIdAsync(int id);
        Task<IEnumerable<TModel>> GeAllAsync();
        Task AddAsync(TModel Entity);
    }
}
