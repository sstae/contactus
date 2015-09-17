using ContactUs.Models;
using ContactUs.Services;
using ContactUs.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactUs.Web.Controllers
{
    public class ContactUsController : Controller
    {
        private App app = new App();

        protected override void Dispose(bool disposing)
        {
            if (disposing) { app.Dispose(); }
            base.Dispose(disposing);
        }
        public ActionResult Index()
        {
            ViewBag.Count = app.Tickets.All().Count();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitTicket(ContactUsIndexVM item) {
            if (ModelState.IsValid) {
                var t = new Ticket();
                t.Title = item.Title;
                t.Body = item.Body;

                app.Tickets.Add(t);
                app.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpPost]
        public ActionResult AddSampleTicket() {
            var t = new Ticket();
            t.Title = "Test Ticket";
            t.Body = "Blah blah";
            t.LastActivityDate = DateTime.Now;
            app.Tickets.Add(t);
            app.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}