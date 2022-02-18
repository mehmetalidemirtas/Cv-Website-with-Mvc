using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvProject.Models.Entity;
using MvcCvProject.Repositories;

namespace MvcCvProject.Controllers
{
    public class ExperiencesController : Controller
    {
        // GET: Experiences
        ExperienceRepository repository = new ExperienceRepository();
        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(Table_Experience p)
        {
            repository.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            Table_Experience t = repository.Find(x => x.ID == id);
            repository.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetExperience(int id)
        {
            Table_Experience t = repository.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult GetExperience(Table_Experience p)
        {
            Table_Experience t = repository.Find(x => x.ID == p.ID);
            t.Title = p.Title;
            t.Subtitle = p.Subtitle;
            t.Date = p.Date;
            t.Explanation = p.Explanation;
            repository.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}