using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using WHS.Core.Response;
using System.Data.Common;
using System.Drawing;
using System.Data;
using System.IO;
using WHS.Core.Dto.Fabric;
using WHS.Repository.Interfaces;
using WHS.Repository.Repository;
using WHS.Core.Dto.Receive;
using WHS.Core.Query.Base;
using WHS.Core.Query.Receive;
using WHS.Core.Dto;
using WHS.Service.Interface;
using WHS.Repository.Repository.Receive;

namespace WHS.Service.Services.Receive
{
    public class ReceiveService<T, D> : BaseReceive, IReceiveService<T, D>
    {
        protected IReceiveRepository<T, D> _repository;

        public ReceiveService(IReceiveRepository<T, D> receiveRepository) : base(receiveRepository)
        {
            _repository = receiveRepository;
        }

        /// <summary>
        /// Tạo mới phiếu NPL vải
        /// </summary>
        /// <param name="fabric"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        public async Task<Response<int>> CreateReceiveAsync(T fabric, DataTable detail)
        {
            return await _repository.CreateReceiveAsync(fabric, detail);
        }

        /// <summary>
        /// Update phiếu NPL
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<int>> UpdateReceiveAsync(int id, T data, DataTable detail)
        {
            return await _repository.UpdateReceiveAsync(id, data, detail);
        }

        /// <summary>
        /// Lấy ra detail theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Response<List<D>>> GetReceiveDetailAsync(int id)
        {
            return _repository.GetReceiveDetailAsync(id);
        }
    }
}
