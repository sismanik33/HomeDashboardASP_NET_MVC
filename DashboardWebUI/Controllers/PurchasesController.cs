using DashboardData.Library.BusinessLogic;
using DashboardData.Library.Models;
using DashboardWebUI.Helpers;
using DashboardWebUI.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DashboardWebUI.Controllers
{
    public class PurchasesController : Controller
    {
        // GET: Purchases
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(PurchaseDiplayModel purchase)
        {
            if (ModelState.IsValid)
            {
                Mapper mapper = new Mapper();
                LoanDrawPurchaseDataModel purchaseToSave = mapper.MapPurchaseInputToDataModel(purchase);
                LoanDrawPurchaseProcessor.SavePurchase(purchaseToSave);
                return RedirectToAction("List");
            }

            return View();
        }

        public ActionResult List()
        {
            Mapper mapper = new Mapper();
            List<LoanDrawPurchaseDataModel> loadedPurchaseData = LoanDrawPurchaseProcessor.GetPurchases();
            List<PurchaseDiplayModel> purchasesToDisplay = mapper.MapPurchaseDataToDisplayData(loadedPurchaseData);

            double purchasesTotal = loadedPurchaseData.Sum(p => p.PurchaseTotal);
            ViewData["PurchaseTotalSum"] = purchasesTotal.ToString("C", CultureInfo.CurrentCulture);

            purchasesToDisplay.Sort((p1, p2) => p1.PurchaseDate.CompareTo(p2.PurchaseDate));

            return View(purchasesToDisplay);
        }

        public ActionResult Update(int id)
        {
            Mapper mapper = new Mapper();
            List<LoanDrawPurchaseDataModel> loadedPurchaseData = LoanDrawPurchaseProcessor.GetPurchases();
            var purchaseData = loadedPurchaseData.Find(x => x.Id == id);
            var purchaseToUpdate = mapper.MapDataItemToDisplayItem(purchaseData);

            return View(purchaseToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(PurchaseDiplayModel purchase)
        {
            if (ModelState.IsValid)
            {
                Mapper mapper = new Mapper();
                LoanDrawPurchaseDataModel purchaseToUpdate = mapper.MapPurchaseInputToDataModel(purchase);
                LoanDrawPurchaseProcessor.UpdatePurchase(purchaseToUpdate);
                return RedirectToAction("List");
            }

            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List");
            }
            Mapper mapper = new Mapper();
            List<LoanDrawPurchaseDataModel> loadedPurchaseData = LoanDrawPurchaseProcessor.GetPurchases();
            var purchaseData = loadedPurchaseData.Find(x => x.Id == id);
            if (purchaseData == null)
            {
                return RedirectToAction("List");
            }
            var purchaseToDelete = mapper.MapDataItemToDisplayItem(purchaseData);

            return View(purchaseToDelete);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoanDrawPurchaseProcessor.DeletePurchase(id);
            return RedirectToAction("List");
        }
    }
}