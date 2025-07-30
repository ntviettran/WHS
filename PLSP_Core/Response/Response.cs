using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Response
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }

        public Response(bool success, string message, T? data = default)
        {
            IsSuccess = success;
            Message = message;
            Data = data;
        }

        public static Response<T> Success(T data, string message = "Success") => new Response<T>(true, message, data);

        public static Response<T> Fail(string message = "Fail") => new Response<T>(false, message);
    }
}
