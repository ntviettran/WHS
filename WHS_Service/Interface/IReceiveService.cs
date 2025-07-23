using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto.Receive;
using WHS.Core.Dto;
using WHS.Core.Query.Base;
using WHS.Core.Query.Receive;
using WHS.Core.Response;

namespace WHS.Service.Interface
{
    public interface IReceiveService
    {
        /// <summary>
        /// Xuất file excel gồm các cột là tên trong list headers truyền vào
        /// </summary>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<Response<byte[]>> ExportExcelAsync(List<string> headers);

        /// <summary>
        /// Đọc dữ liệu từ đường dẫn excel truyền vào
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Task<Response<DataTable>> ReadExcelAsync(string filePath, Dictionary<string, string> headers);
    }

    public interface IReceiveService<T, D> : IReceiveService
    {
        /// <summary>
        /// Lấy ra danh sách group by mo
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="receiveSearch"></param>
        /// <returns></returns>
        Task<Response<PageDto<GroupReceiveDto>>> GetGroupedReceiveAsync(Paginate paginate, ReceiveSearch receiveSearch);

        /// <summary>
        /// Tạo mới phiếu NPL
        /// </summary>
        /// <param name="fabric"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        Task<Response<int>> CreateReceiveAsync(DataTable detail);

        /// <summary>
        /// Chỉnh sửa phiếu NPL
        /// </summary>
        /// <param name="fabric"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        Task<Response<int>> UpdateReceiveAsync(int id, DataTable detail);

        /// <summary>
        /// Lấy ra detail chi tiết
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Response<List<D>>> GetReceiveDetailAsync(GroupReceiveDto receiveData);
    }
}
