using MediatR;

namespace MayBlog.Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger) 
        {

            _logger = logger;
        }

        public async Task<TResponse>Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next
            )
        {
            try
            {
                Console.WriteLine($"MediatR logging: {_logger} so‘rovi boshlandi");
                return await next();
            }
            finally
            {
                Console.WriteLine($"MediatR logging: {typeof(TRequest).Name} so‘rovi yakunlandi");
            }
        }
    }
}
