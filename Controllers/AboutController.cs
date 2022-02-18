using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvProject.Repositories;
using MvcCvProject.Models.Entity;


namespace MvcCvProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        GenericRepository<Table_About> repository = new GenericRepository<Table_About>();
        [HttpGet]
        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(Table_About p)
        {
            var values = repository.Find(x => x.ID == 1);
            values.Name = p.Name;
            values.Surname = p.Surname;
            values.Address = p.Address;
            values.Telephone = p.Telephone;
            values.Mail = p.Mail;
            values.Explanation = p.Explanation;
            values.Photo = p.Photo;
            repository.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}