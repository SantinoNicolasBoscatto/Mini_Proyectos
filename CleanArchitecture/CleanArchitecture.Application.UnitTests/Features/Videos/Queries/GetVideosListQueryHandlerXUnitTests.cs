using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Videos.Queries;
using CleanArchitecture.Application.Mapping;
using CleanArchitecture.Application.UnitTests.Mocks;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Features.Videos.Queries
{
    // Testearemos la Clase GetVideosListQueryHandler
    public class GetVideosListQueryHandlerXUnitTests
    {
        private readonly IMapper mapper;
        private readonly Mock<UnitOfWork> unitOfWork;

        public GetVideosListQueryHandlerXUnitTests()
        {
            unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfing = new MapperConfiguration(x =>
            {
                x.AddProfile<MapperProfile>();
            });
            mapper = mapperConfing.CreateMapper();

            // Agrego data a la BD en memoria
            MockVideoRepository.AddVideoRepository(unitOfWork.Object.StreamerDbContext);
        }

        [Fact]
        public async Task GetVideoListTest_ReturnsNotNull()
        {
            var handler = new GetVideosListQueryHandler(unitOfWork.Object.VideoRepository);
            var list = await handler.Handle(new GetVideosListQuery("Username"), new CancellationToken());
            Assert.NotNull(list);
            Assert.IsType<List<Video>>(list);
        }
    }
}
