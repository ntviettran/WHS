using PLSP.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Enums;

namespace PLSP.Core.Dto.Transaction
{
    public class TransactionCreateDto
    {
        public int LocationId { get; set; }
        public int NplId { get; set; }
        public E_NPLType NplType { get; set; }
        public int ExportQuantity { get; set; }
    }
}
