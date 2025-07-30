using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto;
using WHS.Core.Dto.PO;
using WHS.Core.Query.Base;
using WHS.Core.Response;

namespace WHS.Repository.Interfaces
{
    public interface IPORepository
    {
        /// <summary>
        /// Tạo mới Po
        /// </summary>
        /// <param name="po"></param>
        /// <returns></returns>
        Task<Response<int>> CreatedNewPO(POCreateDto po);

        /// <summary>
        /// Update PO
        /// </summary>
        /// <param name="id"></param>
        /// <param name="po"></param>
        /// <returns></returns>
        Task<Response<int>> UpdatePO(int id, POCreateDto po);

        /// <summary>
        /// Lấy ra PO theo phân trang
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="po"></param>
        /// <returns></returns>
        Task<Response<PageDto<PODto>>> GetPoAsync(Paginate paginate, string po);
    }
}
