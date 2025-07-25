using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto;
using WHS.Core.Dto.Fabric;
using WHS.Core.Dto.Receive;
using WHS.Core.Enums;
using WHS.Core.Query.Base;
using WHS.Core.Query.Receive;
using WHS.Core.Response;
using WHS.Repository.Interfaces;
using WHS.Repository.Repository;
using WHS.Repository.Repository.Receive;
using WHS.Service.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WHS.Service.Services.Receive
{
    public class ReceiveService<T, D> : BaseReceiveService, IReceiveService<T, D>
    {
        protected IReceiveRepository<T, D> _repository;

        public ReceiveService(IReceiveRepository<T, D> receiveRepository)
        {
            _repository = receiveRepository;
        }

        public Task<Response<PageDto<GroupReceiveDto>>> GetGroupedReceiveAsync(Paginate paginate, ReceiveSearch receiveSearch)
        {
            return _repository.GetGroupedReceiveAsync(paginate, receiveSearch);
        }

        public Task<Response<PageDto<D>>> GetDetailReceiveAsync(Paginate paginate, ReceiveSearch receiveSearch)
        {
            return _repository.GetDetailReceiveAsync(paginate, receiveSearch);
        }

        /// <summary>
        /// Tạo mới phiếu NPL vải
        /// </summary>
        /// <param name="fabric"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        public async Task<Response<int>> CreateReceiveAsync(DataTable detail)
        {
            // Kiểm tra trùng lặp giá trị
            var checkDuplicate = await _repository.CheckDuplicateValue(detail);
            
            if (!checkDuplicate.IsSuccess)
            {
                return Response<int>.Fail(checkDuplicate.Message);
            }

            return await _repository.CreateReceiveAsync(detail);
        }

        /// <summary>
        /// Lấy ra detail theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Response<List<D>>> GetReceiveDetailAsync(GroupReceiveDto receiveData)
        {
            return _repository.GetReceiveDetailAsync(receiveData);
        }

        /// <summary>
        /// Convert dữ liệu để xuất excel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        private List<Dictionary<string, object?>> ConvertToRawData<V>(List<V> data, IEnumerable<string> keys)
        {
            return data.Select(item =>
            {
                var dict = new Dictionary<string, object?>();
                foreach (var key in keys)
                {
                    var prop = typeof(T).GetProperty(key);
                    if (prop != null)
                    {
                        var value = prop.GetValue(item);
                        dict[key] = value;
                    }
                    else
                    {
                        dict[key] = null;
                    }
                }
                return dict;
            }).ToList();
        }

        /// <summary>
        /// Xuất ta dữ liệu byte[] từ danh sách dữ liệu và headers
        /// </summary>
        /// <param name="data"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public byte[] ExportToExcel(List<Dictionary<string, object?>> data, Dictionary<string, string> headers)
        {
            ExcelPackage.License.SetNonCommercialPersonal("whs");

            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Sheet1");

            int colIndex = 1;
            foreach (var header in headers)
            {
                var cell = worksheet.Cells[1, colIndex];
                cell.Value = header.Value;
                cell.Style.Font.Bold = true;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                cell.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                colIndex++;
            }

            for (int i = 0; i < data.Count; i++)
            {
                int col = 1;
                foreach (var key in headers.Keys)
                {
                    data[i].TryGetValue(key, out object? value);
                    var cell = worksheet.Cells[i + 2, col];

                    if (value is DateTime dt)
                    {
                        cell.Value = dt.Date;
                        cell.Style.Numberformat.Format = "dd/MM/yyyy";
                    }
                    else
                    {
                        cell.Value = value;
                    }
                    col++;
                }
            }

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
            return package.GetAsByteArray();
        }

        /// <summary>
        /// Xuất dữ liệu excel cho danh sách chưa điều phối
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<Response<byte[]>> ExportExcelDetailNotDispatch(E_NPLType type, Dictionary<string, string> headers)
        {
            try
            {
                List<Dictionary<string, object?>> rawData = new();

                switch (type)
                {
                    case E_NPLType.FABRIC:
                        var fabricRes = await _repository.GetListReceiveAsync();
                        if (!fabricRes.IsSuccess) return Response<byte[]>.Fail(fabricRes.Message);

                        rawData = ConvertToRawData(fabricRes.Data!, headers.Keys);
                        break;

                    case E_NPLType.PLSP:
                        var plspRes = await _repository.GetListReceiveAsync();
                        if (!plspRes.IsSuccess) return Response<byte[]>.Fail(plspRes.Message);

                        rawData = ConvertToRawData(plspRes.Data!, headers.Keys);
                        break;

                    case E_NPLType.PLDG:
                        var pldgRes = await _repository.GetListReceiveAsync();
                        if (!pldgRes.IsSuccess) return Response<byte[]>.Fail(pldgRes.Message);

                        rawData = ConvertToRawData(pldgRes.Data!, headers.Keys);
                        break;

                    default:
                        return Response<byte[]>.Fail("Loại NPL không hợp lệ.");
                }

                byte[] fileBytes = ExportToExcel(rawData, headers);
                return Response<byte[]>.Success(fileBytes);
            }
            catch (Exception ex)
            {
                return Response<byte[]>.Fail("Lỗi xuất Excel: " + ex.Message);
            }
        }

        /// <summary>
        /// Update phụ liệu chưa điều phối
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<Response<int>> UpdateReceivedDetail(List<T> data)
        {
            List<int> ids = data.Select(x => (int)x?.GetType().GetProperty("ID")!.GetValue(x)!).ToList();

            Response<bool> checkHasDispatch = await _repository.CheckHasDispatch(ids);
            if (!checkHasDispatch.IsSuccess)
            {
                return Response<int>.Fail(checkHasDispatch.Message);
            }

            return await _repository.UpdateReceivedDetail(data);
        }
    }
}
