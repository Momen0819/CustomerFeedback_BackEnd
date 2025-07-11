using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ServiceResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public bool Success { get; set; }

        public ServiceResponse(int statusCode, string message, T data = default, bool success = true)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
            Success = success;
        }
    }

    public enum HttpStatusCodeEnum
    {
        OK = 200,
        Unauthorized = 401,
        NotFound = 404,
        BadRequest = 400,
        InternalServerError = 500
    }
}
