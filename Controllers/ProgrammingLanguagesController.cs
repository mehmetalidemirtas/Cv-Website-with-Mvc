using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvProject.Repositories;
using MvcCvProject.Models.Entity;

namespace MvcCvProject.Controllers
{
    public class ProgrammingLanguagesController : Controller
    {
        // GET: ProgrammingLanguages
        GenericRepository<Table_ProgrammingLanguages> repository = new GenericRepository<Table_ProgrammingLanguages>();
        // GET: SocialMedia
        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddPL()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPL(Table_ProgrammingLanguages p)
        {
            repository.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdatePL(int id)
        {
            var values = repository.Find(x => x.ID == id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdatePL(Table_ProgrammingLanguages t)
        {
            var values = repository.Find(x => x.ID == t.ID);
            values.Name = t.Name;
            values.Link = t.Link;            
            repository.TUpdate(values);
            return RedirectToAction("Index");
        }
        public ActionResult DeletePL(int id)
        {
            var values = repository.Find(x => x.ID == id);
            repository.TDelete(values);
            return RedirectToAction("Index");
        }
        public ActionResult Inactive(int id)
        {
            var values = repository.Find(x => x.ID == id);
            values.Status = false;
            repository.TUpdate(values);
            return RedirectToAction("Index");
        }
        public ActionResult Active(int id)
        {
            var values = repository.Find(x => x.ID == id);
            values.Status = true;
            repository.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}