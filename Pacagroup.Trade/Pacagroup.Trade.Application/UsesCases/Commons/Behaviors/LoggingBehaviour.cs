using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Pacagroup.Trade.Application.UsesCases.Commons.Behaviors
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse> // Aca definimos que el Request debe implementar la interfaz IRequest
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;
        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var correlationId = Guid.NewGuid();
            _logger.LogInformation("Handling: {correlationId} {name} {@request}", correlationId,typeof(TRequest).Name, JsonSerializer.Serialize(request));
            var response = await next();
            _logger.LogInformation("Handling: {correlationId} {name} {@response}", correlationId, typeof(TRequest).Name, JsonSerializer.Serialize(response));
            return response;
        }
    }
}
