using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            // Creo la BD en Memoria y me aseguro de que este vacia
            Guid Id = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<StreamerDbContext>().UseInMemoryDatabase(databaseName: $"DbContext-{Guid.NewGuid()}").Options;
            var dbContextFake = new StreamerDbContext(options);

                   
            // Al tener un Mock del OBJETO UnitOfWork tendre acceso tambien a los metodos de VideoRepository y StreamerRepository
            var mockUnitOfWork = new Mock<UnitOfWork>(dbContextFake);
            return mockUnitOfWork;
        }
    }
}
