using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Errors;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        // Next middleware in the middleware chain. Capture exceptions before they reach the next middleware
        private readonly RequestDelegate _next;
        // Register information about the exceptions captured.
        private readonly ILogger<ExceptionMiddleware> _logger;
        // Provides information about the application environment
        public readonly IHostEnvironment _env;

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger,
            IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        // this method wraps the request processing in a try-catch block 
        // to catch any exceptions that may occur during the request processing.
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                //Process the next middleware
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message); // register the error using logger
                context.Response.ContentType = "application/json"; // Set the context type response as application/json
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; // set the status code response HTTP in 500

                // Here an ApiException instance is created which is used to 
                // generate the error response. Depending on the environment 
                // in which the application is running.
                var response = _env.IsDevelopment()
                    ? new ApiException((int)HttpStatusCode.InternalServerError,
                    //production
                    ex.Message, ex.StackTrace.ToString())
                    : new ApiException((int)HttpStatusCode.InternalServerError);
                // Set naming policy in which JSON object properties are written to camelCase
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                // The JsonSerializer class is used to convert the ApiException 
                // instance to a JSON representation.
                var json = JsonSerializer.Serialize(response, options);
                // Write the JSON string on the HTTP request body, which will be sent to the client.
                await context.Response.WriteAsync(json);
            }
        }
    }
}