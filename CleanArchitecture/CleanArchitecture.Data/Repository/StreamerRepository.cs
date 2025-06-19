using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repository
{
    public class StreamerRepository : RepositoryBase<Streamer>, IStreamerRepository
    {
        private readonly StreamerDbContext context;

        // Inyectamos el DbContext mediante el padre
        public StreamerRepository(StreamerDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
