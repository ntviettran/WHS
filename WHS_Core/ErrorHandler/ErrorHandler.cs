using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Response;

namespace WHS.Core.ErrorHandle
{
    public static class ErrorHandler<T>
    {
        public static Response<T> Show(Exception ex)
        {
            return Response<T>.Fail("Có lỗi xảy ra từ hệ thống:" + ex.Message);
        }
    }
}
