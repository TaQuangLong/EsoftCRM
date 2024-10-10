using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace Common.Config;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
            where TRequest: notnull
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, 
                                        CancellationToken cancellationToken)
    {
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        using (LogContext.PushProperty("Enviroment", env))
        using (LogContext.PushProperty("Service", "CrmApi"))
        using (LogContext.PushProperty("Enviroment", env))
        {
            var sw = new Stopwatch();
            sw.Start();

            try
            {
                _logger.LogInformation("Started request {@Request}: {@RequestContent}.",
                    typeof(TRequest).Name, request );

                var res = await next();
                
                sw.Stop();
                
                _logger.LogInformation("Finished request {@Request}. Elapsed: {@Elapsed}." +
                                       " Request: {@RequestContent} - Response: {@Response}.",
                    typeof(TRequest).Name, sw.ElapsedMilliseconds, request, res);

                return res;
            }
            catch (Exception ex)
            {
                sw.Stop();
                var errorResponse = ex.Message;

                _logger.LogError(ex, "Error {@ErrorResponse}. Elapsed: {@Elapsed} ms. Request: {@Request}: {@RequestContent}", 
                    errorResponse, sw.ElapsedMilliseconds, typeof(TRequest).Name, request);
                throw;
            }
            
            
        }
    }
}