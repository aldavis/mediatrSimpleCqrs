using System.Threading.Tasks;
using MediatR;

namespace application.Logging
{
    public class LoggingBehavior<TRequest,TResponse>:IPipelineBehavior<TRequest,TResponse>
    {
        private readonly Logger _logger;

        public LoggingBehavior(Logger logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next)
        {
            _logger.Messages.Add("Logging before Handler");

            var response = await next();

            _logger.Messages.Add("Logging after handler");

            return response;
        }
    }
}
