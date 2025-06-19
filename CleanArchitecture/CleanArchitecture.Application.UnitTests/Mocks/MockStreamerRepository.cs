using AutoFixture;
using CleanArchitecture.Domain;
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
    public static class MockStreamerRepository
    {
        public static void AddStreamerRepository(StreamerDbContext context)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var streamers = fixture.CreateMany<Streamer>().ToList();
            
            // Crearemos un record Streamers pero con su propiedad hija null
            streamers.Add(fixture.Build<Streamer>().With(x => x.Id, 8001).Without(x => x.ListaVideos).Create());

            context.AddRange(streamers);
            context.SaveChanges();
        }
    }
}
