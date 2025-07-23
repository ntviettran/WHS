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
    public class ReceiveService<T, D> : BaseReceiveService, IReceiveService<T, D>
    {
        protected IReceiveRepository<T, D> _repository;

        public ReceiveService(IReceiveRepository<T, D> receiveRepository)
        {
            _repository = receiveRepository;
        }

        public Task<Response<PageDto<GroupReceiveDto>>> GetGroupedReceiveAsync(Paginate paginate, ReceiveSearch receiveSearch)
        {
            return _repository.GetGroupedReceiveAsync(paginate, receiveSearch);
        }

        public Task<Response<PageDto<D>>> GetDetailReceiveAsync(Paginate paginate, ReceiveSearch receiveSearch)
        {
            return _repository.GetDetailReceiveAsync(paginate, receiveSearch);
        }

        /// <summary>
        /// Tạo mới phiếu NPL vải
        /// </summary>
        /// <param name="fabric"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        public async Task<Response<int>> CreateReceiveAsync(DataTable detail)
        {
            // Kiểm tra trùng lặp giá trị
            var checkDuplicate = await _repository.CheckDuplicateValue(detail);
            
            if (!checkDuplicate.IsSuccess)
            {
                return Response<int>.Fail(checkDuplicate.Message);
            }

            return await _repository.CreateReceiveAsync(detail);
        }

        /// <summary>
        /// Update phiếu NPL
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<int>> UpdateReceiveAsync(int id, DataTable detail)
        {
            return await _repository.UpdateReceiveAsync(id, detail);
        }

        /// <summary>
        /// Lấy ra detail theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Response<List<D>>> GetReceiveDetailAsync(GroupReceiveDto receiveData)
        {
            return _repository.GetReceiveDetailAsync(receiveData);
        }
    }
}
