using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.ValidationRules.BusinessValidationRules
{
    internal class FixedAssetBusinessValidationRule
    {
        internal void FixedAssetBusinessLogicValidation(FixedAssetModel fixedAsset, List<DocumentModel> assignedDocuments)
        {
            if (fixedAsset.MonthsOfAccountingDepreciation < 12 || fixedAsset.MonthsOfFiscalDepreciation < 12)
            {
                throw new ArgumentException("Nu se poate adauga un mijloc fix cu o durata mai mica de un an! Verifica lunile de amortizare.");
            }

            if (fixedAsset.MonthsOfFiscalDepreciation < fixedAsset.ClasificationCode.MinimumLifetime * 12 ||
                fixedAsset.MonthsOfFiscalDepreciation > fixedAsset.ClasificationCode.MaximumLifetime * 12)
            {
                throw new ArgumentException("Numarul lunilor de amortizare fiscala trebuie sa fie cuprins intre perioda de functionare minima " +
                    "si perioda de functionare maxima conform codului de clasificare selectat!");
            }

            if (assignedDocuments.Where(x => x.DocumentType.DocumentOperationType != "Intrare").Any())
            {
                if (assignedDocuments.First(x => x.DocumentType.DocumentOperationType == "Intrare").DocumentDate >=
                    assignedDocuments.Where(x => x.DocumentType.DocumentOperationType != "Intrare").OrderBy(x => x.DocumentDate).FirstOrDefault().DocumentDate)
                {
                    throw new ArgumentException("Nu se pot adauga documente a caror data este inainte de data documentului de intrare!");
                }
            }

            if (fixedAsset.AssetValue < 2500)
            {
                throw new ArgumentException("Nu se poate adauga un mijloc fix cu o valoare mai mica de 2500 lei!");
            }
        }
    }
}
