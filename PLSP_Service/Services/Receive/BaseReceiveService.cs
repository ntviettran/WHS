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
using WHS.Core.ErrorHandle;

namespace WHS.Service.Services.Receive
{
    public abstract class BaseReceiveService : IReceiveService
    {
        public BaseReceiveService()
        {

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
                        cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        cell.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                        cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
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
                try
                {
                    ExcelPackage.License.SetNonCommercialPersonal("whs");
                    using (var package = new ExcelPackage(new FileInfo(filePath)))
                    {
                        var ws = package.Workbook.Worksheets[0]; // Sheet đầu tiên
                        DataTable dt = new DataTable();

                        int colCount = ws.Dimension.End.Column;
                        int rowCount = ws.Dimension.End.Row;

                        // Lấy mapping cột Excel → index
                        var headerIndex = new Dictionary<string, int>();
                        for (int col = 1; col <= colCount; col++)
                            headerIndex[ws.Cells[1, col].Text.Trim()] = col;

                        // Tạo cột theo headers
                        foreach (var (key, def) in headers)
                            dt.Columns.Add(key);

                        // Đọc từng dòng dữ liệu
                        for (int row = 2; row <= rowCount; row++)
                        {
                            var dr = dt.NewRow();

                            foreach (var (key, def) in headers)
                            {
                                if (headerIndex.TryGetValue(def, out int colIdx))
                                {
                                    dr[key] = ws.Cells[row, colIdx].Value?.ToString()?.Trim();
                                }
                                else
                                {
                                    dr[key] = DBNull.Value;
                                }
                            }

                            dt.Rows.Add(dr);
                        }

                        return Response<DataTable>.Success(dt);
                    }
                }
                catch (Exception ex)
                {
                    return ErrorHandler<DataTable>.Show(ex);
                }
                
            });
        }
    }
}
