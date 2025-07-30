using PLSP.Core.Query.Transaction;
using PLSP.Repository.Interfaces;
using PLSP.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto;
using WHS.Core.Query.Base;
using WHS.Core.Response;

namespace PLSP.Service.Services.Transaction
{
    public class TransactionService<T> : BaseTransactionService, ITransactionService<T> where T : class
    {

        private ITransactionRepository<T> _repository;

        public TransactionService(ITransactionRepository<T> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<Response<PageDto<T>>> GetHistoryTransactionInventory(Paginate paginate, HistorySearch search)
        {
            return await _repository.GetHistoryTransactionInventory(paginate, search);
        }
    }
}
