using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WHS.Core.Dto;
using WHS.Core.Dto.Fabric;
using WHS.Core.Dto.Receive;
using WHS.Core.Enums;
using WHS.Core.ErrorHandle;
using WHS.Core.Query.Base;
using WHS.Core.Query.Receive;
using WHS.Core.Response;
using WHS.Repository.Interfaces;

namespace WHS.Repository.Repository.Receive
{
    public class ReceiveRepository<T, D> : BaseReceive, IReceiveRepository<T, D> 
        where T : class
        where D : class
    {
        public ReceiveRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>   
        /// Tạo mới phiếu NPL, xử lí ở class con
        /// </summary>
        /// <param name="fabric"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        public virtual Task<Response<int>> CreateReceiveAsync(T data, DataTable detail)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Chỉnh sửa phiếu NPL
        /// </summary>
        /// <param name="data"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task<Response<int>> UpdateReceiveAsync(int id, T data, DataTable detail)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lấy ra detail chi tiết
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task<Response<List<D>>> GetReceiveDetailAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
