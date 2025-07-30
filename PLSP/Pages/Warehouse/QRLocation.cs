using OfficeOpenXml;
using PdfiumViewer;
using QRCoder;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHS.Pages;

namespace PLSP.Pages.Warehouse
{
    public partial class QRLocation : UserControl
    {
        private List<string> _locations = new List<string>();

        public QRLocation()
        {
            InitializeComponent();
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            _locations = new List<string>();

            ExcelPackage.License.SetNonCommercialPersonal("whs");

            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var fileInfo = new FileInfo(ofd.FileName);

                        using (var package = new ExcelPackage(fileInfo))
                        {
                            var worksheet = package.Workbook.Worksheets[0]; // Sheet đầu tiên

                            int rowCount = worksheet.Dimension.Rows;
                            int colCount = worksheet.Dimension.Columns;

                            for (int col = 1; col <= colCount; col++)
                            {
                                for (int row = 1; row <= rowCount; row++)
                                {
                                    var cellValue = worksheet.Cells[row, col].Text;

                                    if (string.IsNullOrEmpty(cellValue)) continue;
                                    _locations.Add(cellValue);
                                }
                            }
                        }

                        MessageBox.Show("Thêm thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(columnTxb.Text, out var cols))
            {
                MessageBox.Show("Số cột không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(rowTxb.Text, out var rows))
            {
                MessageBox.Show("Số dòng không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string timestamp = DateTime.Now.ToString("ddMMyyyyHHmmss");
            string fileName = $"qrcode_{timestamp}.pdf";

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "PDF File|*.pdf",
                FileName = fileName,
                Title = "Chọn nơi lưu file QR PDF"
            })
            {
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                var locations = _locations;
                int perPage = cols * rows;
                int totalPages = (int)Math.Ceiling((double)locations.Count / perPage);

                QuestPDF.Settings.License = LicenseType.Community;

                Document.Create(container =>
                {
                    for (int page = 0; page < totalPages; page++)
                    {
                        int startIndex = page * perPage;
                        int endIndex = Math.Min(startIndex + perPage, locations.Count);

                        var currentPageItems = locations.GetRange(startIndex, endIndex - startIndex);

                        container.Page(pageDescriptor =>
                        {
                            pageDescriptor.Margin(5, Unit.Millimetre);
                            pageDescriptor.Size(PageSizes.A4);
                            pageDescriptor.DefaultTextStyle(x => x.FontSize(10));

                            pageDescriptor.Content()
                                .Grid(grid =>
                                {
                                    grid.Columns(cols); // chia đều thành số cột
                                    foreach (var item in currentPageItems)
                                    {
                                        grid.Item().Padding(5).Border(1).AlignCenter().AlignMiddle().Row(row =>
                                        {
                                            row.RelativeItem(2).Image(GetQrCodeImage(item), ImageScaling.FitWidth);

                                            row.RelativeItem()
                                                .AlignMiddle()
                                                .PaddingLeft(2)
                                                .Text(item)
                                                .WrapAnywhere();
                                        });
                                    }
                                });
                        });
                    }
                }).GeneratePdf(sfd.FileName);

                DialogResult result = MessageBox.Show("Xuất file PDF thành công! Bạn có muốn mở file không?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                    else
                    {
                        MessageBox.Show("File không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private byte[] GetQrCodeImage(string data)
        {
            using (var qrGenerator = new QRCodeGenerator())
            {
                var qrData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
                using (var qrCode = new QRCode(qrData))
                using (var bitmap = qrCode.GetGraphic(20))
                using (var ms = new MemoryStream())
                {
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
        }
    }
}
