﻿using System;
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
        [HttpPost]
        public ActionResult CreateProduct(TblProduct p)
        {
            db.TblProduct.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProduct(int id)
        {
            var value = db.TblProduct.Find(id);
            db.TblProduct.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var value = db.TblProduct.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProduct(TblProduct p)
        {
            var value = db.TblProduct.Find(p);
            value.ProductID = p.ProductID;
            value.ProductName = p.ProductName;
            value.ProductPrice = p.ProductPrice;
            value.ImageUrl = p.ImageUrl;
            return RedirectToAction("Index");
        }
    }
}