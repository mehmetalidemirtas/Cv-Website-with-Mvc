using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvProject.Models.Entity;

namespace MvcCvProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        
        DbCvEntities1 db = new DbCvEntities1();
        // GET: Default
        public ActionResult Index()
        {
            var values = db.Table_About.ToList();
            return View(values);
        }
        public PartialViewResult SocialMedia()
        {
            var values = db.Table_SocialMedia.Where(x=>x.Status==true).ToList();
            return PartialView(values);
        }
        public PartialViewResult ProgrammingLanguages()
        {
            var values = db.Table_ProgrammingLanguages.Where(x => x.Status == true).ToList();
            return PartialView(values);
        }
        public PartialViewResult Experience()
        {
            var values = db.Table_Experience.ToList();
            return PartialView(values);
        }
        public PartialViewResult Education()
        {
            var values = db.Table_Education.ToList();
            return PartialView(values);
        }
        public PartialViewResult Skills()
        {
            var values = db.Table_Skills.ToList();
            return PartialView(values);
        }
        public PartialViewResult Interest()
        {
            var values = db.Table_Interests.ToList();
            return PartialView(values);
        }
        public PartialViewResult Certificates()
        {
            var values = db.Table_Certificates.ToList();
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(Table_Contact t)
        {
            t.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Table_Contact.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}