using DashboardWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DashboardData.Library.BusinessLogic;
using System.Net;
using DashboardData.Library.Models;

namespace DashboardWebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult ViewStockWatchList()
        {
            ViewBag.Message = "Stocks in Watch List";

            var data = StockSymbolProcessor.LoadSymbols();
            List<StockSymbolModel> stocks = new List<StockSymbolModel>();

            foreach (var symbol in data)
            {
                stocks.Add(new StockSymbolModel
                {
                    Symbol = symbol.StockSymbol
                });
            }

            return View(stocks);
        }
        public ActionResult AddStockToWatch()
        {
            ViewBag.Message = "Add Stock To Watch List";

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStockToWatch(Models.StockSymbolModel stock)
        {
            if (ModelState.IsValid)
            {
                StockSymbolProcessor.SaveStockSymbol(stock.Symbol.Trim().ToUpper());
                return RedirectToAction("ViewStockWatchList");
            }

            return View();
        }

        public ActionResult AddLoanDrawPurchase()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLoanDrawPurchase(PurchaseDiplayModel purchase)
        {
            if (ModelState.IsValid)
            {
                LoanDrawPurchaseDataModel purchaseToSave = mapPurchaseInputToDataModel(purchase);
                LoanDrawPurchaseProcessor.SavePurchase(purchaseToSave);
                return RedirectToAction("ViewPurchaseDetails");
            }

            return View();
        }

        private LoanDrawPurchaseDataModel mapPurchaseInputToDataModel(PurchaseDiplayModel p)
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

        public ActionResult ViewPurchaseDetails()
        {
            List<LoanDrawPurchaseDataModel> loadedPurchaseData = LoanDrawPurchaseProcessor.GetPurchases();
            List<PurchaseDiplayModel> purchasesToDisplay = MapPurchaseDataToDisplayData(loadedPurchaseData);

            purchasesToDisplay.Sort((p1, p2) => p1.PurchaseDate.CompareTo(p2.PurchaseDate));

            return View(purchasesToDisplay);
        }

        private List<PurchaseDiplayModel> MapPurchaseDataToDisplayData(List<LoanDrawPurchaseDataModel> loadedPurchaseData)
        {
            List<PurchaseDiplayModel> output = new List<PurchaseDiplayModel>();

            foreach (var source in loadedPurchaseData)
            {
                PurchaseDiplayModel dest= new PurchaseDiplayModel();
                dest.PurchaseDate = source.PurchaseDate;
                dest.Vendor = source.Vendor;
                dest.Description = source.Description;
                dest.Paid = source.Paid;
                dest.PartyToReimburse = source.PartyToReimburse;
                dest.PurchaseTotal = source.PurchaseTotal;
                dest.DrawNumber = source.DrawNumber;
                dest.ReceiptLink = source.ReceiptLink;

                output.Add(dest);
            }

            return output;
        }

        public ActionResult ViewStockListDetails()
        {
            ViewBag.Message = "Stock Watch List Details";

            var stockSymbols = StockSymbolProcessor.LoadSymbols();
            List<string> stockSymbolStr = new List<string>();

            foreach (var stock in stockSymbols)
            {
                stockSymbolStr.Add(stock.StockSymbol.Trim().ToUpper());
            }

            //Return a list of StockModel from DashboardData.Library.Models
            var stockDetailList = StockDetailProcessor.GetStockDetails(stockSymbolStr).Result;

            //Map returned list to StockDetailModel
            List<StockDetailModel> stockDetailResults = new List<StockDetailModel>();
            foreach (var stock in stockDetailList)
            {
                stockDetailResults.Add(new StockDetailModel
                {
                    Symbol = stock.Symbol,
                    DisplayName = stock.DisplayName,
                    RegularMarketPrice = stock.RegularMarketPrice,
                    FiftyDayAverage = stock.FiftyDayAverage,
                    TwoHundredDayAverage = stock.TwoHundredDayAverage,
                    MarketCap = stock.MarketCap,
                    FullExchangeName = stock.FullExchangeName,
                    FiftyTwoWeekLow = stock.FiftyTwoWeekLow,
                    FiftyTwoWeekHigh = stock.FiftyTwoWeekHigh
                });
            }

            //Sort list by market cap (descending)
            stockDetailResults.Sort((s1, s2) => s2.MarketCap.CompareTo(s1.MarketCap) );
            
            return View(stockDetailResults);
        }

        public ActionResult RemoveStockFromList(string symbol="test", bool saveChangesError=false)
        {
            ViewBag.Message = "Remove Stock From Watch List";

            var stockSymbols = StockSymbolProcessor.LoadSymbols();
            bool stockExists = stockSymbols.Exists(x => x.StockSymbol.Trim().ToUpper() == symbol.Trim().ToUpper());

            if (stockExists == false)
            {
                return RedirectToAction("HttpNotFound");
            }
            if (saveChangesError)
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            var stock = stockSymbols.Find(x => x.StockSymbol.Trim().ToUpper() == symbol.Trim().ToUpper());
            DashboardData.Library.Models.StockSymbolDataModel stockToDelete = new DashboardData.Library.Models.StockSymbolDataModel
            {
                StockSymbol = stock.StockSymbol
            };

            return View(stockToDelete);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveStockFromList(Models.StockSymbolModel stock)
        {
            if (ModelState.IsValid)
            {
                StockSymbolProcessor.RemoveStockFromList(stock.Symbol);
                return RedirectToAction("ViewStockWatchList");
            }

            return View();
        }
    }
}