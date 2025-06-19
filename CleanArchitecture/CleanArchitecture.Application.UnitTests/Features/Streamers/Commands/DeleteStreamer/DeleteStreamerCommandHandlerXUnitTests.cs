using CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer;
using CleanArchitecture.Application.UnitTests.Mocks;
using CleanArchitecture.Infrastructure.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandHandlerXUnitTests
    {
        private Mock<UnitOfWork> _unitOfWork;

        public DeleteStreamerCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            MockStreamerRepository.AddStreamerRepository(_unitOfWork.Object.StreamerDbContext);
        }

        [Fact]
        public async Task DeleteStreamer_InputDeleteStreamerCommand_ReturnsNull()
        {
            var handler = new DeleteStreamerCommandHandler(_unitOfWork.Object.StreamerRepository);
            var result = await handler.Handle(new DeleteStreamerCommand { Id = 8001}, CancellationToken.None);
            await Assert.ThrowsAsync<Exception>(async () => await _unitOfWork.Object.StreamerRepository.GetByIdAsync(8001));
        }
    }
}
