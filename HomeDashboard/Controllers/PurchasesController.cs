﻿using DashboardData.Library.BusinessLogic;
using DashboardData.Library.Models;
using DashboardWebUI.Helpers;
using DashboardWebUI.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DashboardWebUI.Controllers
{
    public class PurchasesController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            Mapper mapper = new Mapper();
            List<LoanDrawPurchaseDataModel> loadedPurchaseData = await LoanDrawPurchaseProcessor.GetPurchases();
            List<PurchaseDiplayModel> purchasesToDisplay = mapper.MapPurchaseDataToDisplayData(loadedPurchaseData);

            double purchasesTotal = loadedPurchaseData.Sum(p => p.PurchaseTotal);
            ViewData["PurchaseTotalSum"] = purchasesTotal.ToString("C", CultureInfo.CurrentCulture);

            purchasesToDisplay.Sort((p1, p2) => p1.PurchaseDate.CompareTo(p2.PurchaseDate));

            return View(purchasesToDisplay);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(PurchaseDiplayModel purchase)
        {
            if (ModelState.IsValid)
            {
                Mapper mapper = new Mapper();
                LoanDrawPurchaseDataModel purchaseToSave = mapper.MapPurchaseInputToDataModel(purchase);
                await LoanDrawPurchaseProcessor.SavePurchase(purchaseToSave);
                return RedirectToAction("Index");
            }

            return View();
        }

        [Route("/Purchases/DrawDetails/{id:int}")]
        public async Task<ActionResult> DrawDetails(int id = 0)
        {
            
            if(id == 0)
            {
                return RedirectToAction("Index", "Purchases");
            }

            Mapper mapper = new Mapper();
            List<LoanDrawPurchaseDataModel> loadedPurchaseData = await LoanDrawPurchaseProcessor.GetPurchases();
            var maxDraw = loadedPurchaseData.Max(x => x.DrawNumber);
            if(id > maxDraw)
            {
                return RedirectToAction("Index", "Purchases");
            }
            List<PurchaseDiplayModel> purchasesToDisplay = mapper.MapPurchaseDataToDisplayData(loadedPurchaseData).Where(x => x.DrawNumber == id).ToList();

            double purchasesTotal = purchasesToDisplay.Sum(p => p.PurchaseTotal);

            return View(purchasesToDisplay);

        }

        public async Task<ActionResult> Update(int id)
        {
            Mapper mapper = new Mapper();
            List<LoanDrawPurchaseDataModel> loadedPurchaseData = await LoanDrawPurchaseProcessor.GetPurchases();
            var purchaseData = loadedPurchaseData.Find(x => x.Id == id);
            var purchaseToUpdate = mapper.MapDataItemToDisplayItem(purchaseData);

            return View(purchaseToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(PurchaseDiplayModel purchase)
        {
            if (ModelState.IsValid)
            {
                Mapper mapper = new Mapper();
                LoanDrawPurchaseDataModel purchaseToUpdate = mapper.MapPurchaseInputToDataModel(purchase);
                await LoanDrawPurchaseProcessor.UpdatePurchase(purchaseToUpdate);
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Mapper mapper = new Mapper();
            List<LoanDrawPurchaseDataModel> loadedPurchaseData = await LoanDrawPurchaseProcessor.GetPurchases();
            var purchaseData = loadedPurchaseData.Find(x => x.Id == id);
            if (purchaseData == null)
            {
                return RedirectToAction("Index");
            }
            var purchaseToDelete = mapper.MapDataItemToDisplayItem(purchaseData);

            return View(purchaseToDelete);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await LoanDrawPurchaseProcessor.DeletePurchase(id);
            return RedirectToAction("Index");
        }
    }
}