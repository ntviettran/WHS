using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Enums;
using WHS.Core.Utils;

namespace WHS.Core.Dto.Transfer
{
    public class TransferDto
    {
        public int ID { get; set; }
        public int VehicleId { get; set; }
        public DateTime PlanExecDate { get; set; }
        public DateTime ExecDate { get; set; }
        public DateTime PlanWarehouseDate { get; set; }
        public DateTime WarehouseDate { get; set; }
        public E_TransferExec ExecStatus { get; set; } = E_TransferExec.PENDING;
        public E_TransferStatus? TransferStatus { get; set; } = null;
        public DateTime CreatedAt { get; set; }

        public string PlanExecDateVN => PlanExecDate.ToString("dd/MM/yyyy");
        public string ExecDateVN => ExecDate.ToString("dd/MM/yyyy");
        public string PlanWarehouseDateVN => PlanWarehouseDate.ToString("dd/MM/yyyy");
        public string WarehouseDateVN => WarehouseDate.ToString("dd/MM/yyyy");
        public string ExecStatusDescription => EnumHelper.GetEnumDescription(ExecStatus);
        public string? TransferStatusDescription => TransferStatus != null ? EnumHelper.GetEnumDescription(TransferStatus) : "Đang cập nhật";
        public string CreatedAtVN => CreatedAt.ToString("dd/MM/yyyy HH:mm");
    }
}
