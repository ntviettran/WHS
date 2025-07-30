using PLSP.Core.Dto.PLSP;
using QRCoder;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Windows.Compatibility;

namespace PLSP.Utils
{
    public class QRCodeUtils
    {
        public static byte[] BitmapToBytes(Bitmap bitmap)
        {
            using var ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        public static byte[] GenerateQRCodeBitmap(string text)
        {
            using (var qrGenerator = new QRCodeGenerator())
            {
                var qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
                var qrCode = new QRCode(qrCodeData);
                return BitmapToBytes(qrCode.GetGraphic(5));
            }
        }

        public static byte[] GenerateBarcode(string data)
        {
            var writer = new ZXing.BarcodeWriter<Bitmap>
            {
                Format = ZXing.BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 500,
                    Width = 2500,
                    PureBarcode = true
                },
                Renderer = new BitmapRenderer()
            };

            // Tạo bitmap barcode (chưa có text)
            Bitmap barcodeBitmap = writer.Write(data);

            return BitmapToBytes(barcodeBitmap);
        }

        public static void DrawPlsp(IDocumentContainer container, PlspInventoryLocationDto item)
        {
            StringBuilder qrString = new StringBuilder();
            qrString.Append(item.ID).Append("-");
            qrString.Append(item.MO).Append("-");
            qrString.Append(item.PlspType).Append("-");
            qrString.Append(item.PlspCode).Append("-");
            qrString.Append(item.NplColor).Append("-");
            qrString.Append(item.Size);

            container.Page(page =>
            {
                page.Margin(2);
                page.Size(170, 110, Unit.Millimetre); // 60mm x 40mm = ~170x110pt

                page.Content()
                    .Row(row =>
                    {
                        row.RelativeItem(6) // tỷ lệ lớn hơn
                            .PaddingLeft(30)
                            .Column(col =>
                            {
                                col.Spacing(5);
                                col.Item().Text($"ID: {item.ID}").FontSize(20);
                                col.Item().Text($"MO: {item.MO}").FontSize(20);
                                col.Item().Text($"Loại: {item.PlspType}").FontSize(20);
                                col.Item().Text($"Màu: {item.NplColor}").FontSize(20);
                                col.Item().Text($"Màu SP: {item.PlspColor}").FontSize(20);
                                col.Item().Text($"Size: {item.Size}").FontSize(20);
                                col.Item().Text($"Vị trí: {item.Location}").FontSize(20);
                            });

                        // QR code chiếm phần còn lại và fill chiều cao
                        row.RelativeItem(4)
                            .PaddingRight(20)
                            .PaddingBottom(30)
                            .AlignCenter()
                            .AlignMiddle()
                            .Image(GenerateQRCodeBitmap(qrString.ToString()));
                    });

                page.Footer().AlignCenter().Image(GenerateBarcode(qrString.ToString()));
            });
        }

        public static string GeneratePdfLabels(List<PlspInventoryLocationDto> items)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            string outputFile = Path.Combine(Path.GetTempPath(), $"labels_{Guid.NewGuid()}.pdf");

            var document = Document.Create(container =>
            {
                foreach (var item in items)
                {
                    DrawPlsp(container, item);
                }
            });

            document.GeneratePdf(outputFile);
            return outputFile;
        }

        public static void PrintPdf(string printerName, string pdfFilePath)
        {
            using (var document = PdfiumViewer.PdfDocument.Load(pdfFilePath))
            {
                using (var printDocument = document.CreatePrintDocument())
                {
                    printDocument.PrinterSettings = new PrinterSettings()
                    {
                        PrinterName = printerName,
                        Copies = 1
                    };

                    printDocument.DefaultPageSettings.Landscape = false;
                    printDocument.PrintController = new System.Drawing.Printing.StandardPrintController();
                    printDocument.Print();
                }
            }
        }
    }
}
