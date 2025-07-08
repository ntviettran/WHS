using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using WHS.Core.Response;
using WHS.Repository.Interfaces;
using WHS.Repository.Repository.Receive;
using WHS.Core.Dto.Receive;
using WHS.Core.Dto;
using WHS.Core.Query.Base;
using WHS.Core.Query.Receive;
using WHS.Service.Interface;

namespace WHS.Service.Services.Receive
{
    public abstract class BaseReceiveService : IReceiveService
    {
        protected IReceiveRepository _receiveRepository;

        public BaseReceiveService(IReceiveRepository receiveRepository)
        {
            _receiveRepository = receiveRepository;
        }
        /// <summary>
        /// Xuất file excel gồm các cột là tên trong list headers truyền vào
        /// </summary>
        /// <param name="headers"></param>
        /// <returns></returns>
        public async Task<Response<byte[]>> ExportExcelAsync(List<string> headers)
        {
            return await Task.Run(() =>
            {
                ExcelPackage.License.SetNonCommercialPersonal("whs");

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                    for (int i = 0; i < headers.Count; i++)
                    {
                        var cell = worksheet.Cells[1, i + 1];
                        cell.Value = headers[i];
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        // Tô nền xanh dương
                        cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        cell.Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                    }

                    if (headers.Count > 0)
                        worksheet.Cells[1, 1, 1, headers.Count].AutoFitColumns();

                    var data = package.GetAsByteArray();
                    return Response<byte[]>.Success(data);
                }
            });
        }

        /// <summary>
        /// Đọc dữ liệu từ đường dẫn excel truyền vào
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public async Task<Response<DataTable>> ReadExcelAsync(string filePath, Dictionary<string, string> headers)
        {
            return await Task.Run(() =>
            {
                ExcelPackage.License.SetNonCommercialPersonal("whs");
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0]; // Sheet đầu tiên
                    DataTable dt = new DataTable();

                    int colCount = worksheet.Dimension.End.Column;
                    int rowCount = worksheet.Dimension.End.Row;

                    // Tạo cột từ dòng đầu tiên (header)
                    for (int col = 1; col <= colCount; col++)
                    {
                        string excelHeader = worksheet.Cells[1, col].Text.Trim();
                        var match = headers.FirstOrDefault(h => h.Value == excelHeader);
                        if (!string.IsNullOrEmpty(match.Key))
                        {
                            dt.Columns.Add(match.Key); // Thêm tên cột theo KEY
                        }
                    }

                    // Đọc dữ liệu từ dòng 2 trở đi
                    for (int row = 2; row <= rowCount; row++)
                    {
                        DataRow dr = dt.NewRow();
                        for (int col = 1; col <= colCount; col++)
                        {
                            dr[col - 1] = worksheet.Cells[row, col].Text;
                        }
                        dt.Rows.Add(dr);
                    }

                    return Response<DataTable>.Success(dt);
                }
            });
        }

        /// <summary>
        /// Lấy ra danh sách nhận NPL
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="receiveSearch"></param>
        /// <returns></returns>
        public async Task<Response<PageDto<ReceiveDto>>> GetReceiveAsync(Paginate paginate, ReceiveSearch receiveSearch)
        {
            return await _receiveRepository.GetReceiveAsync(paginate, receiveSearch);
        }
    }
}
