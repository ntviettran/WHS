using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Response
{
    public class Response<T>
    {
        public bool success { get; set; } 
        public string message { get; set; }   
        public T? data { get; set; }         

        public Response(bool i_success, string i_message, T? i_data = default)
        {
            success = i_success;
            message = i_message;
            data = i_data;
        }

        public static Response<T> Success(T data, string message = "Success") => new Response<T>(true, message, data);

        public static Response<T> Fail(string message = "Fail") => new Response<T>(false, message);
    }
}
