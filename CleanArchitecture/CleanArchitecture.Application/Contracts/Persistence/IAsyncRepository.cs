using CleanArchitecture.Domain.Common;
using System.Linq.Expressions;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    // Esta interfaz definira los metodos que deberan implementar mi entidades
    public interface IAsyncRepository<T> where T : BaseDomainModel
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        // GetAsync devolvera una lista, pero esta lista tendra la codicion que definamos en su parametro Expression
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        // GetAsync devolvera una lista, esta tendra varias condiciones a modificar para cambiar como devulve la lista
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, 
                                        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                        string? includeString = null, bool disableTracking = true);

        // GetAsync devolvera una lista, se le agrega una list<Expression> para agregar los cruces con entidades, mediante el Include()
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                        bool disableTracking = true, List<Expression<Func<T, object>>>? includes = null);

        Task<T> GetByIdAsync(int id);

        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);


        void AddEntity(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(T entity);
    }
}
