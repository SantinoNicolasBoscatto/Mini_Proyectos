using AutoMapper;
using Castle.Core.Logging;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Streamers.Commands.AddStreamer;
using CleanArchitecture.Application.Mapping;
using CleanArchitecture.Application.UnitTests.Mocks;
using CleanArchitecture.Infrastructure.Repository;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandHandlerXUnitTests
    {
        private Mock<UnitOfWork> _unitOfWork;
        private IMapper _mapper;
        private readonly Mock<ILogger<CreateStreamerCommandHandler>> logger;

        public CreateStreamerCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfing = new MapperConfiguration(x =>
            {
                x.AddProfile<MapperProfile>();
            });
            _mapper = mapperConfing.CreateMapper();
            logger = new Mock<ILogger<CreateStreamerCommandHandler>>();

            // Agrego data a la BD en memoria
            MockStreamerRepository.AddStreamerRepository(_unitOfWork.Object.StreamerDbContext);
        }

        [Fact]
        public async Task CreateStreamer_InputCreateStreamerCommand_ReturnsNotNull()
        {
            var handle = new CreateStreamerCommandHandler(_unitOfWork.Object.StreamerRepository, logger.Object, _mapper);
            var id = await handle.Handle(new CreateStreamerCommand { Nombre = "Pepo-San", Url ="NoUrl"}, new CancellationToken());
            var entity = await _unitOfWork.Object.StreamerRepository.GetByIdAsync(id);
            Assert.NotNull(entity);
        }
    }
}
