using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolyclinicProject.Controllers
{
    public class PatientController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        // GET: Patient
        public ActionResult Index()
        {
            var details = from x in dc.Пациент select x;
            return View(details);
        }
        [Authorize(Roles = "Admin")]
        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            var get = dc.Пациент.Single(x => x.Номер_записи == id);
            return View(get);
        }
        [Authorize(Roles = "Admin")]
        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        [HttpPost]
        public ActionResult Create(Пациент collection)
        {
            try
            {
                // TODO: Add insert logic here
                dc.Пациент.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]
        // GET: Patient/Edit/5
        public ActionResult Edit(int id)
        {
            var get = dc.Пациент.Single(x => x.Номер_записи == id);
            return View(get);
        }

        // POST: Patient/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Пациент collection)
        {
            try
            {
                // TODO: Add update logic here
                Пациент emp = dc.Пациент.Single(x => x.Номер_записи == id);
                emp.Номер_полиса = collection.Номер_полиса;
                emp.Фио = collection.Фио;
                emp.Пароль = collection.Пароль;
                emp.Номер_участка = collection.Номер_участка;
                emp.Логин = collection.Логин;
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]
        // GET: Patient/Delete/5
        public ActionResult Delete(int id)
        {
            var get = dc.Пациент.Single(x => x.Номер_записи == id);
            return View(get);
        }

        // POST: Patient/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,Пациент collection)
        {
            try
            {
                // TODO: Add delete logic here
                var empdel = dc.Пациент.Single(x => x.Номер_записи == id);
                dc.Пациент.DeleteOnSubmit(empdel);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
