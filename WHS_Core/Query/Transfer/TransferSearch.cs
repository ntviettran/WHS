using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Enums;

namespace WHS.Core.Query.Transfer
{
    public class TransferSearch
    {
        public int? ID { get; set; }
        public DateTime? EstimateExec { get; set; }
        public DateTime? EstimateWarehouse { get; set; }
        public DateTime? ExecDate { get; set; }
        public DateTime? WarehouseDate { get; set; }
        public E_TransferExec ExecStatus { get; set; }
    }
}
