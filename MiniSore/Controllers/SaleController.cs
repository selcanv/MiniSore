using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniSore.Models;
namespace MiniSore.Controllers
{
    public class SaleController : Controller
    {
        DbMiniStoreEntities db = new DbMiniStoreEntities();
        public ActionResult Index()
        {
            var values = db.TblSale.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateSale()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSale(TblSale p)
        {
            db.TblSale.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSale(int id)
        {
            var value = db.TblSale.Find(id);
            db.TblSale.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSale(int id)
        {
            var value = db.TblSale.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSale(TblSale p)
        {
            var value = db.TblSale.Find(p);
            value.SaleID = p.SaleID;
            value.Title = p.Title;
            value.SaleCategory = p.TblCategory.CategoryID;
            return RedirectToAction("Index");
        }
    }
}