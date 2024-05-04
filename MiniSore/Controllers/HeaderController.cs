using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniSore.Models;
namespace MiniSore.Controllers
{
    public class HeaderController : Controller
    {
        DbMiniStoreEntities db = new DbMiniStoreEntities();
        public ActionResult Index()
        {
            var values = db.TblHome.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateHeader()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateHeader(TblHome p)
        {
            db.TblHome.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeader(int id)
        {
            var value = db.TblHome.Find(id);
            db.TblHome.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateHeader(int id)
        {
            var value = db.TblHome.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateHeader(TblHome p)
        {
            var value = db.TblHome.Find(p);
            value.HomeID = p.HomeID;
            value.HeaderTitle = p.HeaderTitle;
            value.ImageUrl = p.ImageUrl;
            return RedirectToAction("Index");
        }
    }
}