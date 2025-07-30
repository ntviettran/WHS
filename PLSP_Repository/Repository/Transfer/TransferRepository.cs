using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto.Transfer;
using WHS.Core.Enums;
using WHS.Core.ErrorHandle;
using WHS.Core.Query.Receive;
using WHS.Core.Response;
using WHS.Repository.Interfaces;

namespace WHS.Repository.Repository.Coordinate
{
    public class TransferRepository<T, D> : BaseTransferRepository, ITransferRepository<T, D>
        where T : class
        where D: class
    {
        public TransferRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Hàm dựng để lấy detail chi tiết 
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task<Response<List<T>>> GetTransferCoordinateByStatus(E_DispatchTransfer status)
        {
            throw new NotImplementedException();
        }

		/// <summary>
		/// Hàm dựng lấy ra detail transfer
		/// </summary>
		/// <returns></returns>
		public virtual Task<Response<List<D>>> GetTransferDetail(int transferId) 
        { 
            throw new NotImplementedException(); 
        }

        /// <summary>
        /// Hàm dựng lấy ra danh sách cần điều phối, và đã điều phối theo id npl cần nhận
        /// </summary>
        /// <param name="idNplReceived"></param>
        /// <returns></returns>
        public virtual Task<Response<List<T>>> GetCoordinationHistory(ReceiveHistorySearch search)
        {
            throw new NotImplementedException();
        }
    }
}
