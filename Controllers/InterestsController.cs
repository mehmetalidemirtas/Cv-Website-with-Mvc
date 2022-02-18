using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvProject.Repositories;
using MvcCvProject.Models.Entity;

namespace MvcCvProject.Controllers
{
    public class InterestsController : Controller
    {
        // GET: Interests
        GenericRepository<Table_Interests> repository = new GenericRepository<Table_Interests>();
        [HttpGet]
        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(Table_Interests p)
        {
            var values = repository.Find(x => x.ID == 1);
            values.Explanation1 = p.Explanation1;
            values.Explanation2 = p.Explanation2;
            repository.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}