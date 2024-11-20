using EventReminder.SharedKernel.Primitives;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventReminder.Usecase.Core.Abstractions.Behaviors
{
    /// <summary>
    /// Represents RequestLoggingBehavior
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="logger"></param>
    internal sealed class RequestLoggingBehavior<TRequest, TResponse> 
        (ILogger<RequestLoggingBehavior<TRequest, TResponse>> logger) 
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TResponse : Response
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            string requestName = typeof(TRequest).Name;
            try
            {
                logger.LogInformation($"Process on request {request}");

                TResponse response = await next();

                if (response.IsSuccess)
                {
                    logger.LogInformation($"Completed request {request}");
                }
                else
                {
                    logger.LogError($"Completed request {request} with errors {response}");
                }
                return response;
            }
            catch (Exception exception)
            {
                logger.LogError(exception, $"Request {request} ended with unhandle exception", exception);
                throw;
            }
        }
    }
}
