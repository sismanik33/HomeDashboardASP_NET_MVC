using DashboardData.Library.Models;
using DashboardWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DashboardWebUI.Helpers
{
    public class Mapper
    {
        public List<PurchaseDiplayModel> MapPurchaseDataToDisplayData(List<LoanDrawPurchaseDataModel> loadedPurchaseData)
        {
            List<PurchaseDiplayModel> mappedPurchase = new List<PurchaseDiplayModel>();

            foreach (var source in loadedPurchaseData)
            {
                PurchaseDiplayModel dest = new PurchaseDiplayModel();
                dest.Id = source.Id;
                dest.PurchaseDate = source.PurchaseDate;
                dest.Vendor = source.Vendor;
                dest.Description = source.Description;
                dest.Paid = source.Paid;
                dest.PartyToReimburse = source.PartyToReimburse;
                dest.PurchaseTotal = source.PurchaseTotal;
                dest.DrawNumber = source.DrawNumber;
                dest.ReceiptLink = source.ReceiptLink;
                dest.PartialPayment = source.PartialPayment;

                mappedPurchase.Add(dest);
            }

            return mappedPurchase;
        }

        public PurchaseDiplayModel MapDataItemToDisplayItem(LoanDrawPurchaseDataModel dataItem)
        {
            PurchaseDiplayModel output = new PurchaseDiplayModel()
            {
                Id = dataItem.Id,
                PurchaseDate = dataItem.PurchaseDate,
                Vendor = dataItem.Vendor,
                Description = dataItem.Description,
                Paid = dataItem.Paid,
                PartyToReimburse = dataItem.PartyToReimburse,
                PurchaseTotal = dataItem.PurchaseTotal,
                DrawNumber = dataItem.DrawNumber,
                ReceiptLink = dataItem.ReceiptLink,
                PartialPayment = dataItem.PartialPayment
                
            };

            return output;
        }

        public LoanDrawPurchaseDataModel MapPurchaseInputToDataModel(PurchaseDiplayModel p)
        {
            LoanDrawPurchaseDataModel mappedPurchase = new LoanDrawPurchaseDataModel()
            {
                Id = p.Id,
                PurchaseDate = p.PurchaseDate,
                Vendor = p.Vendor,
                Description = p.Description,
                Paid = p.Paid,
                PartyToReimburse = p.PartyToReimburse,
                PurchaseTotal = p.PurchaseTotal,
                DrawNumber = p.DrawNumber,
                ReceiptLink = p.ReceiptLink,
                PartialPayment = p.PartialPayment
            };

            return mappedPurchase;
        }


    }
}