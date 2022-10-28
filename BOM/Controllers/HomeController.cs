using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOM.Models;

namespace BOM.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        BOMEntities1 db = new BOMEntities1();
        public ActionResult Index(string productId="A0001")
        {
            ViewBag.ProductName = db.Product.Where(m => m.ProductId == productId).FirstOrDefault().ProductName;
            ViewModel vm = new ViewModel()
            {
                Products = db.Product.ToList(),
                Materials = db.Material.Where(m => m.ProductId == productId).ToList(),
            };
            return View(vm);
        }
        public ActionResult Create()
        {
            return View(db.Product.ToList());
        }
        [HttpPost]
        public ActionResult Create(Material material)
        {
            db.Material.Add(material);
            db.SaveChanges();
            return RedirectToAction("Index", new {productId=material.ProductId});
        }
        public ActionResult Delete(string materialId)
        {
            var material=db.Material.Where(m=>m.MaterialId==materialId).FirstOrDefault();
            db.Material.Remove(material);
            db.SaveChanges();
            return RedirectToAction("Index", new { productId = material.ProductId});
        }
        public ActionResult Edit(string materialId)
        {
            var material = db.Material.Where(m => m.MaterialId == materialId).FirstOrDefault();
            var productId = db.Product.Select(m =>m);
            var selectList = new List<SelectListItem>();//建立SelectListItem類型的List，存放供DropDownList使用的清單
            foreach(var item in productId)
            {
                selectList.Add(new SelectListItem {Text=item.ProductId,Value=item.ProductId});//將ProductId放入List
            }
            selectList.Where(q=>q.Value==material.ProductId).First().Selected = true;//比對物料編號所對應的ProductId，將此ProductId設為DropDownList的預設值
            ViewBag.SelectList = selectList;//將List存入ViewBag傳送到前端
            return View(material);
        }
        [HttpPost]
        public ActionResult Edit(Material material)
        {
            var materialEdit = db.Material.Where(m => m.MaterialId == material.MaterialId).FirstOrDefault();
            materialEdit.MaterialName = material.MaterialName;
            materialEdit.MaterialDescription = material.MaterialDescription;
            materialEdit.MaterialModel = material.MaterialModel;
            materialEdit.ProductId = material.ProductId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            db.Product.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}