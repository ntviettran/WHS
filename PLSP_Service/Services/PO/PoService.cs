using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto;
using WHS.Core.Dto.PO;
using WHS.Core.Query.Base;
using WHS.Core.Response;
using WHS.Repository.Interfaces;
using WHS.Service.Interface;

namespace WHS.Service.Services.PO
{
    public class PoService : IPOService
    {
        private IPORepository _repository;

        public PoService(IPORepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Tạo mới Po
        /// </summary>
        /// <param name="po"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<int>> CreatedNewPO(POCreateDto po)
        {
            return await  _repository.CreatedNewPO(po);
        }
        
        /// <summary>
        /// Update PO
        /// </summary>
        /// <param name="id"></param>
        /// <param name="po"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<int>> UpdatePO(int id, POCreateDto po)
        {
            return await _repository.UpdatePO(id, po);
        }

        /// <summary>
        /// Lấy ra PO theo phân trang
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="po"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<PageDto<PODto>>> GetPoAsync(Paginate paginate, string po)
        {
            return await _repository.GetPoAsync(paginate, po);
        }
    }
}
