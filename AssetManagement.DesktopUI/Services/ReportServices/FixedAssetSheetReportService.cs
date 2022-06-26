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
    internal class FixedAssetSheetReportService
    {
        internal void GenerateReport(string clientName, DateTime dateOfReference, FixedAssetDepreciationDisplayModel fixedAsset)
        {
            string path = $@"C:/Users/{Environment.UserName}/Documents/FisaMijloculuiFix_{clientName.Replace(" ", "_")}_{DateTime.Now:dd.MM.yyy.hh.m.s}.pdf";

            PdfWriter writer = new PdfWriter(path);
            PdfDocument pdfDocument = new PdfDocument(writer);

            // Create the document object
            Document document = new Document(pdfDocument);


            // Create the actual document layout

            document.Add(new Paragraph()); // blank line

            Paragraph documentTitle = new Paragraph("FISA MIJLOCULUI FIX").SetTextAlignment(TextAlignment.CENTER);
            document.Add(documentTitle);

            Paragraph unitatea = new Paragraph($"Unitatea: {clientName}").SetTextAlignment(TextAlignment.CENTER);
            document.Add(unitatea);

            document.Add(new Paragraph()); // blank line

            float[] identificationTableColumnWidths = { 300f, 220F };
            Table identificationTable = new Table(identificationTableColumnWidths);

            Paragraph inventoryNumberColumn = new(
                $"Numarul de inventar {fixedAsset.InventoryNumber} {"\n"} " +
                $"Documentul de provenienta {fixedAsset.AssignedDocument.DocumentNumber} {"\n"}" +
                $"Valoare de inventar {fixedAsset.AssetValue} {"\n"}" +
                $"Amortizare lunara {fixedAsset.AssetValue / fixedAsset.MonthsOfAccountingDepreciation} {"\n"}" +
                $"{"\n"}" +
                $"Denumirea mijlocului fix si caracteristicile tehnice {"\n"}" +
                $"{fixedAsset.FixedAssetDescription}");

            identificationTable.AddCell(new Cell().Add(inventoryNumberColumn));


            Paragraph fixedAssetDescriptionColumn = new(
                $"Grupa {"\n"} {fixedAsset.ClasificationCode.ClasificationCodeDescription} {"\n"}{"\n"}" +
                $"Codul de clasificare {"\n"} {fixedAsset.ClasificationCode.ClasificationCode} {"\n"}{"\n"}" +
                $"Data darii in folosinta {"\n"} " +
                $"Anul {fixedAsset.EntryDate.Year} {"\n"}" +
                $"Luna {fixedAsset.EntryDate.Month} {"\n"}{"\n"}" +
                $"Data amortizarii complete {"\n"} " +
                $"Anul {fixedAsset.EntryDate.AddMonths(fixedAsset.MonthsOfAccountingDepreciation).Year} {"\n"}" +
                $"Luna {fixedAsset.EntryDate.AddMonths(fixedAsset.MonthsOfAccountingDepreciation).Month} {"\n"}{"\n"}" +
                $"Durata normala de functionare {"\n"}" +
                $"{fixedAsset.MonthsOfAccountingDepreciation / 12} {"\n"}{"\n"}" +
                $"Cota de amortizare {"\n"}" +
                $"{fixedAsset.MonthsOfAccountingDepreciation * 12 / 100 }%");
            identificationTable.AddCell(new Cell().Add(fixedAssetDescriptionColumn));
            document.Add(identificationTable);            

            // Second table with fixed asset valuations
            if (fixedAsset.Operations.All(x => x.OperationValue != 0))
            {
                document.Add(new Paragraph()); // blank line
                float[] detailsTableColumnWidths = { 130F, 130F, 130F, 130F };
                Table detailsTable = new Table(detailsTableColumnWidths);

                Paragraph entryDate = new("Data");
                detailsTable.AddCell(new Cell().Add(entryDate));

                Paragraph details = new("Explicatii");
                detailsTable.AddCell(new Cell().Add(details));

                Paragraph value = new("Valoare");
                detailsTable.AddCell(new Cell().Add(value));

                Paragraph balance = new("Sold final");
                detailsTable.AddCell(new Cell().Add(balance));

                decimal assetBalance = fixedAsset.AssetValue;

                foreach (var operation in fixedAsset.Operations)
                {
                    Paragraph operationDate = new(operation.OperationDate.ToString());
                    detailsTable.AddCell(new Cell().Add(operationDate));

                    Paragraph operationDetails = new(operation.OperationType.OperationDescription);
                    detailsTable.AddCell(new Cell().Add(operationDetails));

                    Paragraph operationValue = new(operation.OperationValue.ToString());
                    detailsTable.AddCell(new Cell().Add(operationValue));

                    assetBalance = assetBalance + operation.OperationValue;

                    Paragraph finalbalance = new(assetBalance.ToString());
                    detailsTable.AddCell(new Cell().Add(finalbalance));
                }

                document.Add(detailsTable);
            }

            Paragraph data = new Paragraph($"Data: {DateTime.Now.ToString("dd.MM.yyy")}").SetTextAlignment(TextAlignment.RIGHT);
            document.Add(data);
            
            document.Close();

            Process.Start("MicrosoftEdge.exe", path);
        }
    }
}
