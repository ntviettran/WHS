using PLSP.Core.Dto.Transaction;
using PLSP.Core.Query.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto;
using WHS.Core.Dto.User;
using WHS.Core.Query.Base;
using WHS.Core.Response;

namespace PLSP.Service.Interface
{
    public interface ITransactionService
    {
        /// <summary>
        /// Xuất kho
        /// </summary>
        /// <param name="block"></param>
        /// <param name="transactions"></param>
        /// <returns></returns>
        Task<Response<int>> InventoryExport(UserInfoDto userExport, List<TransactionCreateDto> transactions);
    }
    

    public interface ITransactionService<T> where T : class
    {
        /// <summary>
        /// Lấy ra danh sách xuất kho
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<Response<PageDto<T>>> GetHistoryTransactionInventory(Paginate paginate, HistorySearch search);
    }
}
