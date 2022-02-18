using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvProject.Repositories;
using MvcCvProject.Models.Entity;

namespace MvcCvProject.Controllers
{
    public class CertificationController : Controller
    {
        GenericRepository<Table_Certificates> repository = new GenericRepository<Table_Certificates>();

        // GET: Certification
        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdateCertification(int id)
        {
            var values = repository.Find(x => x.ID == id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateCertification(Table_Certificates t)
        {
            var values = repository.Find(x => x.ID == t.ID);
            values.Explanation = t.Explanation;
            values.Date = t.Date;
            values.Link = t.Link;
            repository.TUpdate(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddCertification()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCertification(Table_Certificates p)
        {
            repository.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCertification(int id)
        {
            var values = repository.Find(x => x.ID == id);
            repository.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}