using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GenericRepository.DAL;
using GenericRepository.Domains;

namespace GenericRepository.Controllers
{
    public class ProductsController : Controller
    {
        UnitOfWork uOfWork = new UnitOfWork(new GenericRepoContext());

        // GET: Products
        [HttpGet]
        public ActionResult Index()
        {
            return View(uOfWork.ProductRepository.GetProductsWithSuppliers());
        }

        // GET: Products/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = uOfWork.ProductRepository.GetById((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Tedarikciler = uOfWork.SupplierRepository.GetAll();
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Product product)
        {
            if (ModelState.IsValid)
            {
                uOfWork.ProductRepository.Add(product);
                uOfWork.SaveOk();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = uOfWork.ProductRepository.GetById((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tedarikciler = uOfWork.SupplierRepository.GetAll();

            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UrunAdi,Sonlandi,SupplierID")] Product product)
        {
            if (ModelState.IsValid)
            {
                uOfWork.ProductRepository.Update(product);
                uOfWork.SaveOk();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = uOfWork.ProductRepository.GetById((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = uOfWork.ProductRepository.GetById((int)id);
            uOfWork.SupplierRepository.Remove(id);
            uOfWork.SaveOk();
            return RedirectToAction("Index");
        }
    }
}
