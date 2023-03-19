using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolyclinicProject.Controllers
{
    public class RecheptController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        // GET: Rechept
        public ActionResult Index()
        {
            var details = from x in dc.Рецепт select x;
            return View(details);
        }
        [Authorize(Roles = "Doctor")]
        // GET: Rechept/Details/5
        public ActionResult Details(int id)
        {
            var get = dc.Рецепт.Single(x => x.Номер_записи == id);
            return View(get);
        }
        [Authorize(Roles = "Doctor")]
        // GET: Rechept/Create
        public ActionResult Create( )
        {

            return View();
        }

        // POST: Rechept/Create
        [HttpPost]
        public ActionResult Create(Рецепт collection)
        {
            try
            {

                collection.Номер_врача = int.Parse(User.Identity.GetUserId());
                collection.Дата = DateTime.Today;
                // TODO: Add insert logic here
                dc.Рецепт.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index");
               
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Doctor")]
        // GET: Rechept/Edit/5
        public ActionResult Edit(int id)
        {
            var get = dc.Рецепт.Single(x => x.Номер_записи == id);
            return View(get);
        }

        public ActionResult IndexR(int idr)
        {
            List<Рецепт> Spisok = new List<Рецепт>();
            Spisok = dc.Рецепт.Where(x => x._Номер_пациента == idr).ToList();
            return View(Spisok);
        }
        [Authorize(Roles = "Doctor")]
        // POST: Rechept/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Рецепт collection)
        {
            try
            {
                // TODO: Add update logic here
                Рецепт emp = dc.Рецепт.Single(x => x.Номер_записи == id);
                emp.Дата = collection.Дата;
                emp.Название = collection.Название;
                emp._Номер_пациента = collection._Номер_пациента;
                emp.Номер_врача = collection.Номер_врача;
                emp.Назначенное_лечение = collection.Назначенное_лечение;
                emp.Документ_выписки = collection.Документ_выписки;
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Doctor")]
        // GET: Rechept/Delete/5
        public ActionResult Delete(int id)
        {
            var get = dc.Рецепт.Single(x => x.Номер_записи == id);
            return View(get);
        }

        // POST: Rechept/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Рецепт collection)
        {
            try
            {
                // TODO: Add delete logic here
                var empdel = dc.Рецепт.Single(x => x.Номер_записи == id);
                dc.Рецепт.DeleteOnSubmit(empdel);
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
