using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using WHS.Core.Enums;
using WHS.Core.ErrorHandle;
using WHS.Core.Response;
using WHS.Repository.Interfaces;

namespace WHS.Repository.Repository.Coordinate
{
    public class TransferRepository<T, D> : BaseTransferRepository, ITransferRepository<T, D>
        where T : class
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
    }
}
