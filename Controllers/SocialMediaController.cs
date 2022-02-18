using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvProject.Repositories;
using MvcCvProject.Models.Entity;

namespace MvcCvProject.Controllers
{
    public class SocialMediaController : Controller
    {
        GenericRepository<Table_SocialMedia> repository = new GenericRepository<Table_SocialMedia>();
        // GET: SocialMedia
        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocialMedia(Table_SocialMedia p)
        {
            repository.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var values = repository.Find(x => x.ID == id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(Table_SocialMedia t)
        {
            var values = repository.Find(x => x.ID == t.ID);
            values.Name = t.Name;
            values.Link = t.Link;
            values.Icon = t.Icon;
            repository.TUpdate(values);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSocialMedia(int id)
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