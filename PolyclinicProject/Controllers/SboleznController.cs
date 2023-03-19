using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolyclinicProject.Controllers
{
    public class SboleznController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        // GET: Sbolezn
        public ActionResult Index()
        {
            var details = from x in dc.Справочник_диагнозов select x;
            return View(details);
        }
        [Authorize(Roles = "Admin")]
        // GET: Sbolezn/Details/5
        public ActionResult Details(int id)
        {
            var get = dc.Справочник_диагнозов.Single(x => x.Номер_записи == id);
            return View(get);
        }

        [Authorize(Roles = "Admin")]
        // GET: Sbolezn/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sbolezn/Create
        [HttpPost]
        public ActionResult Create(Справочник_диагнозов collection)
        {
            try
            {
                // TODO: Add insert logic here
                dc.Справочник_диагнозов.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]
        // GET: Sbolezn/Edit/5
        public ActionResult Edit(int id)
        {
            var get = dc.Справочник_диагнозов.Single(x => x.Номер_записи == id);
            return View(get);
        }

        // POST: Sbolezn/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Справочник_диагнозов collection)
        {
            try
            {
                // TODO: Add update logic here
                Справочник_диагнозов emp = dc.Справочник_диагнозов.Single(x => x.Номер_записи == id);
                emp.Номер_болезни = collection.Номер_болезни;
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
        // GET: Sbolezn/Delete/5
        public ActionResult Delete(int id)
        {
            var get = dc.Справочник_диагнозов.Single(x => x.Номер_записи == id);
            return View(get);
        }

        // POST: Sbolezn/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Справочник_диагнозов collection)
        {
            try
            {
                // TODO: Add delete logic here
                var empdel = dc.Справочник_диагнозов.Single(x => x.Номер_записи == id);
                dc.Справочник_диагнозов.DeleteOnSubmit(empdel);
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
