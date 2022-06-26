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
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Services.ReportServices
{
    internal class FixedAssetsGeneralReportService
    {
        internal void GenerateReport(string clientName, DateTime dateOfReference, List<FixedAssetDepreciationDisplayModel> fixedAssets)
        {
            string path = $@"C:/Users/{Environment.UserName}/Documents/RaportMijloaceFixe_{clientName.Replace(" ", "_")}_{DateTime.Now:dd.MM.yyy}.pdf";

            PdfWriter writer = new PdfWriter(path);
            PdfDocument pdfDocument = new PdfDocument(writer);

            // Create the document object
            Document document = new Document(pdfDocument);

            // Create the actual document layout

            document.Add(new Paragraph()); // blank line

            Paragraph documentTitle = new Paragraph("RAPORT INTERN MIJLOACE FIXE").SetTextAlignment(TextAlignment.CENTER);
            document.Add(documentTitle);

            Paragraph unitatea = new Paragraph($"Unitatea: {clientName}").SetTextAlignment(TextAlignment.CENTER);
            document.Add(unitatea);

            document.Add(new Paragraph()); // blank line

            float[] pointColumnWidths = { 104F, 104F, 104F, 104F, 104F };
            Table table = new Table(pointColumnWidths);

            Paragraph inventoryNumberColumn = new("Nr. de inventar");
            table.AddCell(new Cell().Add(inventoryNumberColumn));

            Paragraph descriptionColumn = new("Denumire");
            table.AddCell(new Cell().Add(descriptionColumn));

            Paragraph accoutingDepreciationColumn = new("Amortizare contabila");
            table.AddCell(new Cell().Add(accoutingDepreciationColumn));

            Paragraph fiscalDepreciationColumn = new("Amortizare fiscala");
            table.AddCell(new Cell().Add(fiscalDepreciationColumn));

            Paragraph netValueColumn = new("Valoare neta contabila");
            table.AddCell(new Cell().Add(netValueColumn));

            foreach (var asset in fixedAssets)
            {
                Paragraph inventoryNumber = new Paragraph(asset.InventoryNumber.ToString());
                table.AddCell(new Cell().Add(inventoryNumber));

                Paragraph description = new Paragraph(asset.FixedAssetDescription);
                table.AddCell(new Cell().Add(description));

                Paragraph accountingDepreciation = new Paragraph(asset.TotalAccountingDepreciation.ToString("N")).SetTextAlignment(TextAlignment.RIGHT);
                table.AddCell(new Cell().Add(accountingDepreciation));

                Paragraph fiscalDepreciation = new Paragraph(asset.TotalFiscalDepreciation.ToString("N")).SetTextAlignment(TextAlignment.RIGHT);
                table.AddCell(new Cell().Add(fiscalDepreciation));

                Paragraph netValue = new Paragraph(asset.NetAssetValue.ToString("N")).SetTextAlignment(TextAlignment.RIGHT);
                table.AddCell(new Cell().Add(netValue));
            }

            document.Add(table);

            Paragraph data = new Paragraph($"Data: {dateOfReference:dd.MM.yyy}").SetTextAlignment(TextAlignment.RIGHT);
            document.Add(data);

            document.Close();

            Process.Start("MicrosoftEdge.exe", path);
        }
    }
}
