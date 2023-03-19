using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolyclinicProject.Controllers
{
    public class DoctorsController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        // GET: Doctors
        public ActionResult Index()
        {
            var details = from x in dc.Врачи select x;
            return View(details);
        }
        [Authorize(Roles = "Admin")]
        // GET: Doctors/Details/5
        public ActionResult Details(int id)
        {
            var get = dc.Врачи.Single(x => x.Номер_записи == id);
            return View(get);
        }

        [Authorize(Roles = "Admin")]
        // GET: Doctors/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        // POST: Doctors/Create
        [HttpPost]
        public ActionResult Create(Врачи collection)
        {
            try
            {
                // TODO: Add insert logic here
                dc.Врачи.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Doctors/Edit/5
        public ActionResult Edit(int id)
        {
            var get = dc.Врачи.Single(x => x.Номер_записи == id);
            return View(get);
        }

        // POST: Doctors/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Врачи collection)
        {
            try
            {
                // TODO: Add update logic here
                Врачи emp = dc.Врачи.Single(x => x.Номер_записи == id);
                emp.Логин = collection.Логин;
                emp.Фио = collection.Фио;
                emp.Пароль = collection.Пароль;
                emp.Специалист = collection.Специалист;
                emp.График_работы = collection.График_работы;
                emp.Участок = collection.Участок;
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Doctors/Delete/5
        public ActionResult Delete(int id)
        {
            var get = dc.Врачи.Single(x => x.Номер_записи == id);
            return View(get);
        }

        // POST: Doctors/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Врачи collection)
        {
            try
            {
                // TODO: Add delete logic here
                var empdel = dc.Врачи.Single(x => x.Номер_записи == id);
                dc.Врачи.DeleteOnSubmit(empdel);
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
