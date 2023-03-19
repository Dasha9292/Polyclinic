using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolyclinicProject.Controllers
{
    public class ZapisController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        // GET: Zapis
        public ActionResult Index()
        {
            var details = from x in dc.Запись_на_прием select x;
            return View(details);
        }
        [Authorize(Roles = "Admin")]
        // GET: Zapis/Details/5
        public ActionResult Details(int id)
        {
            var get = dc.Запись_на_прием.Single(x => x.Номер_записи == id);
            return View(get);
        }
        [Authorize(Roles = "Patient")]
        public ActionResult IndexId(int idych,string spec)
        {
            List<Запись_на_прием> Spisok = new List<Запись_на_прием>();
            Spisok = dc.Запись_на_прием.Where(x => x.Участок == idych).Where(x => x.Специалист == spec).Where(x => x.Дата_приема >= DateTime.Today).Where(x => x.Статус_заявки == "Свободно").ToList();
            return View(Spisok);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult IndexAd()
        {
            List<Запись_на_прием> Spisok = new List<Запись_на_прием>();
            Spisok = dc.Запись_на_прием.Where(x => x.Статус_заявки == "Обрабатывается").ToList();
            return View(Spisok);
        }
        [Authorize(Roles = "Patient")]
        public ActionResult IndexP(int idp)
        {
            List<Запись_на_прием> Spisok = new List<Запись_на_прием>();
            Spisok = dc.Запись_на_прием.Where(x => x._Номер_пациента == idp).ToList();
            return View(Spisok);
        }

        [Authorize(Roles = "Patient")]
        public ActionResult Index2()
        {
            
            return View();
        }
        [Authorize(Roles = "Doctor")]
        public ActionResult IndexIdoctor(int idoc)
        {
            List<Запись_на_прием> Spisok = new List<Запись_на_прием>();
            Spisok = dc.Запись_на_прием.Where(x => x.Номер_врача == idoc).Where(x => x.Дата_приема == DateTime.Today).ToList();
            return View(Spisok);
        }
        [Authorize(Roles = "Admin")]
        // GET: Zapis/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        // POST: Zapis/Create
        [HttpPost]
        public ActionResult Create(Запись_на_прием collection)
        {
            try
            {
                // TODO: Add insert logic here
                dc.Запись_на_прием.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Patient")]
        public ActionResult Статус (int id, string userId,Запись_на_прием collection)
        {
            
            // TODO: Add insert logic here

            Запись_на_прием statement = dc.Запись_на_прием.Single(x => x.Номер_записи == id);
            statement.Статус_заявки = "Обрабатывается";
            statement._Номер_пациента = int.Parse(userId);
            dc.SubmitChanges();
            return RedirectToAction("Index");

        }
        [Authorize(Roles = "Admin")]
        public ActionResult metod1(int id, Запись_на_прием collection)
        {

            // TODO: Add insert logic here

            Запись_на_прием statement = dc.Запись_на_прием.Single(x => x.Номер_записи == id);
            statement.Статус_заявки = "Одобрено";
            dc.SubmitChanges();
            return RedirectToAction("Index");



        }
        [Authorize(Roles = "Admin")]
        public ActionResult metod2(int id, Запись_на_прием collection)
        {

            // TODO: Add insert logic here

            Запись_на_прием statement = dc.Запись_на_прием.Single(x => x.Номер_записи == id);
            statement.Статус_заявки = "Отказано";
            dc.SubmitChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        // GET: Zapis/Edit/5
        public ActionResult Edit(int id)
            {
                var get = dc.Запись_на_прием.Single(x => x.Номер_записи == id);
                return View(get);
            }
        
        // POST: Zapis/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Запись_на_прием collection)
        {
            try
            {
                // TODO: Add update logic here
                Запись_на_прием emp = dc.Запись_на_прием.Single(x => x.Номер_записи == id);
                emp.Дата_обращения = collection.Дата_обращения;
                emp.Специалист = collection.Специалист;
                emp.Участок = collection.Участок;
                emp._Номер_пациента = collection._Номер_пациента;
                emp.Дата_приема = collection.Дата_приема;
                emp.Причина_обращения = collection.Причина_обращения;
                emp.Дата_обращения = collection.Дата_обращения;
                emp.Время = collection.Время;
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]
        // GET: Zapis/Delete/5
        public ActionResult Delete(int id)
        {
            var get = dc.Запись_на_прием.Single(x => x.Номер_записи == id);
            return View(get);
        }

        // POST: Zapis/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Запись_на_прием collection)
        {
            try
            {
                // TODO: Add delete logic here
                var empdel = dc.Запись_на_прием.Single(x => x.Номер_записи == id);
                dc.Запись_на_прием.DeleteOnSubmit(empdel);
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
