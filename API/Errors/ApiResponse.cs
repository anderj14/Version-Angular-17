using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

#pragma warning disable CS8603

        private string GetStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made.",
                401 => "Authorized, are you not.",
                403 => "Forbidden from doing this, you are",
                404 => "Resource found, it was not.",
                500 => "Internal Server Error: Something went wrong on our end. We're working to fix it.",
                _ => null
            };
        }
#pragma warning disable CS8603

    }
}