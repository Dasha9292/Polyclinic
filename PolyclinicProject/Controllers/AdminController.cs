using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolyclinicProject.Controllers
{
    public class AdminController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        // GET: Admin
        public ActionResult Index()
        {
           var details = from x in dc.Администратор select x;
            return View(details);
        }
        [Authorize(Roles = "Admin")]
        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            var get = dc.Администратор.Single(x => x.Номер_записи == id);
            return View(get);
        }
        [Authorize(Roles = "Admin")]

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Администратор collection)
        {
            try
            {
                // TODO: Add insert logic here
                dc.Администратор.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index");
     
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            var get = dc.Администратор.Single(x => x.Номер_записи == id);
            return View(get);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Администратор collection)
        {
            try
            {
                // TODO: Add update logic here
                Администратор emp = dc.Администратор.Single(x => x.Номер_записи == id);
                emp.Логин = collection.Логин;
                emp.Фио = collection.Фио;
                emp.Пароль = collection.Пароль;
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            var get = dc.Администратор.Single(x => x.Номер_записи == id);
            return View(get);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Администратор collection)
        {
            try
            {
                // TODO: Add delete logic here
                var empdel = dc.Администратор.Single(x => x.Номер_записи == id);
                dc.Администратор.DeleteOnSubmit(empdel);
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
