using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvProject.Repositories;
using MvcCvProject.Models.Entity;

namespace MvcCvProject.Controllers
{
    public class ContactController : Controller
    {
        GenericRepository<Table_Contact> repository = new GenericRepository<Table_Contact>();
        // GET: Contact
        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }
        public ActionResult DeleteComment(int id)
        {
            var values = repository.Find(x => x.ID == id);
            repository.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}