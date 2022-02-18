using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvProject.Repositories;
using MvcCvProject.Models.Entity;
namespace MvcCvProject.Controllers
{
    public class SkillsController : Controller
    {
        GenericRepository<Table_Skills> repository = new GenericRepository<Table_Skills>();
        // GET: Skills
        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(Table_Skills p)
        {
            repository.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSkill(int id)
        {
            var values = repository.Find(x => x.ID == id);
            repository.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var values = repository.Find(x => x.ID == id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateSkill(Table_Skills t)
        {
            var values = repository.Find(x => x.ID == t.ID);
            values.Skills = t.Skills;
            repository.TUpdate(values);
            return RedirectToAction("Index");
        }

    }
}