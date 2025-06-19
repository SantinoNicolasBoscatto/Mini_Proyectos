using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Infrastructure.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable? _repositories;  
        private readonly StreamerDbContext _dbContext;

        private IVideoRepository? _videoRepository;
        public IVideoRepository VideoRepository => _videoRepository ??= new VideoRepository(_dbContext);

        private IStreamerRepository? _streamerRepository;
        public IStreamerRepository StreamerRepository => _streamerRepository ??= new StreamerRepository(_dbContext);

        public StreamerDbContext StreamerDbContext => _dbContext;

        public UnitOfWork(StreamerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Esta funcion se encarga de realizar el guardado de todas las transacciones
        public async Task<int> Complete()
        {
            return await _dbContext.SaveChangesAsync();
        }

        // Esta funcion se encarga de borrar y destruir la instancia del DbContext que usamos
        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if(_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {
                // Lo que hacemos en esta linea es tener el TYPE del Repositorio Base, e Instanciarlo pero como el objeto generico TEntity
                // Luego Agrego este a la list de repositories.
                var repositoryType = typeof(RepositoryBase<>);
                var instance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dbContext);
                _repositories.Add(type, instance);
            }
            return (IAsyncRepository<TEntity>)_repositories[type]!;
        }
    }
}
