using AutoMapper;
using CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer;
using CleanArchitecture.Application.Mapping;
using CleanArchitecture.Application.UnitTests.Mocks;
using CleanArchitecture.Infrastructure.Repository;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandHandlerXUnitTests
    {
        private Mock<UnitOfWork> _unitOfWork;
        private IMapper _mapper;

        public UpdateStreamerCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfing = new MapperConfiguration(x =>
            {
                x.AddProfile<MapperProfile>();
            });
            _mapper = mapperConfing.CreateMapper();
            MockStreamerRepository.AddStreamerRepository(_unitOfWork.Object.StreamerDbContext);
        }

        [Fact]
        public async Task UpdateStreamer_InputUpdateStreamerCommand_ReturnsUnit()
        {
            var handle = new UpdateStreamerCommandHandler(_unitOfWork.Object.StreamerRepository, _mapper);
            var result = await handle.Handle(new UpdateStreamerCommand { Id = 8001, Nombre = "Santino", Url = "Nothng" }, new CancellationToken());
            var entity = await _unitOfWork.Object.StreamerRepository.GetByIdAsync(8001);
            Assert.Equivalent("Santino", entity.Nombre);
        }
    }
}
