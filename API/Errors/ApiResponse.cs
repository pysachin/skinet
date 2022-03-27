using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiResponse
    {


        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(int statusCode,string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStausCode(statusCode);
        }

        private string GetDefaultMessageForStausCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request",
                401 => "Unauthorized",
                404 => "Resource not found",
                500 => "Server error",
                _ => null
            };
        }

    }
}
