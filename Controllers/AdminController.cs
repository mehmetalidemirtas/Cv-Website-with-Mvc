using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvProject.Repositories;
using MvcCvProject.Models.Entity;

namespace MvcCvProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<Table_Login> repository = new GenericRepository<Table_Login>();

        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Table_Login p)
        {
            repository.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id)
        {
            var values = repository.Find(x => x.ID == id);
            repository.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var values = repository.Find(x => x.ID == id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Table_Login t)
        {
            var values = repository.Find(x => x.ID == t.ID);
            values.Username = t.Username;
            values.Password = t.Password;
            repository.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}