using PLSP.Core.Dto.Transaction;
using PLSP.Repository.Interfaces;
using PLSP.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto.User;
using WHS.Core.Response;
using WHS.Repository.Repository.PO;

namespace PLSP.Service.Services.Transaction
{
    public class BaseTransactionService : ITransactionService
    {
        private ITransactionRepository _repository;

        public BaseTransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }


        /// <summary>
        /// Xuất kho
        /// </summary>
        /// <param name="userExport"></param>
        /// <param name="transactions"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<int>> InventoryExport(UserInfoDto userExport, List<TransactionCreateDto> transactions)
        {
            return await _repository.InventoryExport(userExport, transactions);
        }
    }
}
