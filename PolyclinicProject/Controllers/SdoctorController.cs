using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolyclinicProject.Controllers
{
    public class SdoctorController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        // GET: Sdoctor
        public ActionResult Index()
        {
            var details = from x in dc.Справочник_врачей select x;
            return View(details);
        }
        [Authorize(Roles = "Admin")]
        // GET: Sdoctor/Details/5
        public ActionResult Details(int id)
        {
            var get = dc.Справочник_врачей.Single(x => x.Номер_записи == id);
            return View(get);
        }

        [Authorize(Roles = "Admin")]
        // GET: Sdoctor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sdoctor/Create
        [HttpPost]
        public ActionResult Create(Справочник_врачей collection)
        {
            try
            {
                // TODO: Add insert logic here
                dc.Справочник_врачей.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]
        // GET: Sdoctor/Edit/5
        public ActionResult Edit(int id)
        {
            var get = dc.Справочник_врачей.Single(x => x.Номер_записи == id);
            return View(get);
        }

        // POST: Sdoctor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Справочник_врачей collection)
        {
            try
            {
                // TODO: Add update logic here
                Справочник_врачей emp = dc.Справочник_врачей.Single(x => x.Номер_записи == id);
                emp.Название = collection.Название;
                emp.Описание = collection.Описание;
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]
        // GET: Sdoctor/Delete/5
        public ActionResult Delete(int id)
        {
            var get = dc.Справочник_врачей.Single(x => x.Номер_записи == id);
            return View(get);
        }

        // POST: Sdoctor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Справочник_врачей collection)
        {
            try
            {
                // TODO: Add delete logic here
                var empdel = dc.Справочник_врачей.Single(x => x.Номер_записи == id);
                dc.Справочник_врачей.DeleteOnSubmit(empdel);
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
