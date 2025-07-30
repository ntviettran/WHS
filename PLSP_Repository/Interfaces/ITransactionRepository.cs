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

namespace PLSP.Repository.Interfaces
{
    public interface ITransactionRepository
    {
        /// <summary>
        /// Xuất kho
        /// </summary>
        /// <param name="userExport"></param>
        /// <param name="transactions"></param>
        /// <returns></returns>
        Task<Response<int>> InventoryExport(UserInfoDto userExport, List<TransactionCreateDto> transactions);

        /// <summary>
        /// Check limit mỗi ngày, nếu không lỗi gì thì trả về số lượng đã xuất
        /// </summary>
        /// <param name="quantityLimit"></param>
        /// <param name="ssid"></param>
        /// <returns></returns>
        Task<Response<int>> CheckLimitQuantity(int quantityLimit, int ssid);
    }

    public interface ITransactionRepository<T> : ITransactionRepository
    {
        /// <summary>
        /// Lấy ra lịch sử giao dịch kho
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<Response<PageDto<T>>> GetHistoryTransactionInventory(Paginate paginate, HistorySearch search);
    }
}
