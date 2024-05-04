using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniSore.Models;
namespace MiniSore.Controllers
{
    public class ProductController : Controller
    {
        DbMiniStoreEntities db = new DbMiniStoreEntities();
        public ActionResult Index()
        {
            var values = db.TblProduct.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }
    }
}