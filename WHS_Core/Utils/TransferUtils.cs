using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Enums;

namespace WHS.Core.Utils
{
    public class TransferUtils
    {
        /// <summary>
        /// Get ra status của số lượng
        /// </summary>
        /// <param name="estimate"></param>
        /// <param name="received"></param>
        /// <returns></returns>
        public static E_QuantityStatus GetQuantityIntStatus(int expect, int received)
        {
            if (received == 0) return E_QuantityStatus.PENDING;
            if (received == expect) return E_QuantityStatus.SUFFICIENT;
            if (received > expect) return E_QuantityStatus.EXCESS;
            return E_QuantityStatus.LACKING;
        }

        /// <summary>
        /// Lấy ra status của so sánh số lượng ban đầu  với thực nhận
        /// </summary>
        /// <param name="init"></param>
        /// <param name="received"></param>
        /// <returns></returns>
        public static E_QuantityStatus GetQuantityFloatStatus(float? expect, float received)
        {
            if (expect == null || expect == 0) return E_QuantityStatus.PENDING;

            if (received == 0) return E_QuantityStatus.PENDING;
            if (received == expect) return E_QuantityStatus.SUFFICIENT;
            if (received > expect) return E_QuantityStatus.EXCESS;
            return E_QuantityStatus.LACKING;
        }
    }
}
