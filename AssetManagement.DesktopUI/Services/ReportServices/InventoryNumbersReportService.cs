using AssetManagement.DesktopUI.Models;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Services.ReportServices
{
    internal class InventoryNumbersReportService
    {
        internal void GenerateReport(string clientName, DateTime dateOfReference, List<FixedAssetDepreciationDisplayModel> fixedAssets)
        {
            string path = $@"C:/Users/{Environment.UserName}/Documents/RegistrulNumerelorDeInventar_{clientName.Replace(" ","_")}_{DateTime.Now:dd.MM.yyy}.pdf";

            PdfWriter writer = new PdfWriter(path);
            PdfDocument pdfDocument = new PdfDocument(writer);

            // Create the document object
            Document document = new Document(pdfDocument);

            // Create the actual document layout

            document.Add(new Paragraph()); // blank line

            Paragraph documentTitle = new Paragraph("REGISTRUL NUMERELOR DE INVENTAR").SetTextAlignment(TextAlignment.CENTER);
            document.Add(documentTitle);

            Paragraph unitatea = new Paragraph($"Unitatea: {clientName}").SetTextAlignment(TextAlignment.CENTER);
            document.Add(unitatea);

            document.Add(new Paragraph()); // blank line

            float[] pointColumnWidths = { 150F, 150F, 220F };
            Table table = new Table(pointColumnWidths);

            Paragraph inventoryNumberColumn = new("Numarul de inventar");
            table.AddCell(new Cell().Add(inventoryNumberColumn));

            Paragraph clasificationCodeColumn = new("Codul de clasificare");
            table.AddCell(new Cell().Add(clasificationCodeColumn));

            Paragraph fixedAssetDescriptionColumn = new("Denumirea mijlocului fix");
            table.AddCell(new Cell().Add(fixedAssetDescriptionColumn));

            foreach (var asset in fixedAssets)
            {
                Paragraph inventoryNumber = new Paragraph(asset.InventoryNumber.ToString());
                table.AddCell(new Cell().Add(inventoryNumber));

                Paragraph clasificationCode = new Paragraph(asset.ClasificationCode.ClasificationCode);
                table.AddCell(new Cell().Add(clasificationCode));

                Paragraph fixedAssetDescription = new Paragraph(asset.FixedAssetDescription);
                table.AddCell(new Cell().Add(fixedAssetDescription));
            }
            
            document.Add(table);

            Paragraph data = new Paragraph($"Data: {dateOfReference:dd.MM.yyy}").SetTextAlignment(TextAlignment.RIGHT);
            document.Add(data);

            document.Close();

            Process.Start("MicrosoftEdge.exe", path);
        }
    }
}
