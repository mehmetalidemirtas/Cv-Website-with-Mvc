using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvProject.Repositories;
using MvcCvProject.Models.Entity;

namespace MvcCvProject.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        GenericRepository<Table_Education> repository = new GenericRepository<Table_Education>();
        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(Table_Education p)
        {
            repository.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEducation(int id)
        {
            var values = repository.Find(x => x.ID == id);
            repository.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var values = repository.Find(x => x.ID == id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateEducation(Table_Education t)
        {
            var values = repository.Find(x => x.ID == t.ID);
            values.Title = t.Title;
            values.Subtitle = t.Subtitle;
            values.Subtitle2 = t.Subtitle2;
            values.GradePointAverage = t.GradePointAverage;
            values.Date = t.Date;
            repository.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}