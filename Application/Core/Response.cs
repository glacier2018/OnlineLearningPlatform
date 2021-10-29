using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Core
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public static Response<T> Succeed(T data)
        {
            return new Response<T> { Success = true, Data = data };
        }
        public static Response<T> Fail(string message, string code)
        {
            return new Response<T> { Success = false, ErrorCode = code, ErrorMessage = message };
        }
    }
}