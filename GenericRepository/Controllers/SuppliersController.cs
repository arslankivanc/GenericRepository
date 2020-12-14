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
    public class SuppliersController : Controller
    {
        UnitOfWork uOfWork = new UnitOfWork(new GenericRepoContext());

        // GET: Suppliers
        public ActionResult Index()
        {
            return View(uOfWork.SupplierRepository.GetAll());
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = uOfWork.SupplierRepository.GetById((int)id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SirketAdi")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                uOfWork.SupplierRepository.Add(supplier);
                uOfWork.SaveOk();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = uOfWork.SupplierRepository.GetById((int)id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SirketAdi")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                uOfWork.SupplierRepository.Update(supplier);
                uOfWork.SaveOk();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = uOfWork.SupplierRepository.GetById((int)id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = uOfWork.SupplierRepository.GetById((int)id);
            uOfWork.SupplierRepository.Remove(id);
            uOfWork.SaveOk();
            return RedirectToAction("Index");
        }
    }
}
