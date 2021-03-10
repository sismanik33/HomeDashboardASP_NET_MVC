﻿using DashboardData.Library.Models;
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
                dest.PurchaseDate = source.PurchaseDate;
                dest.Vendor = source.Vendor;
                dest.Description = source.Description;
                dest.Paid = source.Paid;
                dest.PartyToReimburse = source.PartyToReimburse;
                dest.PurchaseTotal = source.PurchaseTotal;
                dest.DrawNumber = source.DrawNumber;
                dest.ReceiptLink = source.ReceiptLink;

                mappedPurchase.Add(dest);
            }

            return mappedPurchase;
        }

        public LoanDrawPurchaseDataModel MapPurchaseInputToDataModel(PurchaseDiplayModel p)
        {
            LoanDrawPurchaseDataModel mappedPurchase = new LoanDrawPurchaseDataModel()
            {
                PurchaseDate = p.PurchaseDate,
                Vendor = p.Vendor,
                Description = p.Description,
                Paid = p.Paid,
                PartyToReimburse = p.PartyToReimburse,
                PurchaseTotal = p.PurchaseTotal,
                DrawNumber = p.DrawNumber,
                ReceiptLink = p.ReceiptLink
            };

            return mappedPurchase;
        }
    }
}