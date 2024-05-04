using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniSore.Models;
namespace MiniSore.Controllers
{
    public class WatchesController : Controller
    {
        DbMiniStoreEntities db = new DbMiniStoreEntities();
        public ActionResult Index()
        {

            var values = db.TblWatches.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(TblWatches p)
        {
            db.TblWatches.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProduct(int id)
        {
            var value = db.TblWatches.Find(id);
            db.TblWatches.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var value = db.TblWatches.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProduct(TblWatches p)
        {
            var value = db.TblWatches.Find(p);
            value.WatchesID = p.WatchesID;
            value.WatchesName = p.WatchesName;
            value.WatchesPrice = p.WatchesPrice;
            value.ImageUrl = p.ImageUrl;
            return RedirectToAction("Index");
        }
    }
}