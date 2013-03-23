using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        private BlogiDBContext db = new BlogiDBContext();

        //
        // GET: /Blog/

        public ActionResult Index()
        {
            return View(db.Blogit.ToList());
        }

        //
        // GET: /Blog/Details/5

        public ActionResult Details(int id = 0)
        {
            Blogi blogi = db.Blogit.Find(id);
            if (blogi == null)
            {
                return HttpNotFound();
            }
            return View(blogi);
        }

        //
        // GET: /Blog/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Blog/Create

        [HttpPost]
        public ActionResult Create(Blogi blogi)
        {
            blogi.Nimi = User.Identity.Name;
            if (ModelState.IsValid)
            {
                db.Blogit.Add(blogi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogi);
        }

        //
        // GET: /Blog/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Blogi blogi = db.Blogit.Find(id);
            if (blogi.Nimi != User.Identity.Name)
            {
                return RedirectToAction("Error");
            }

            if (blogi == null)
            {
                return HttpNotFound();
            }
            return View(blogi);
        }

        public string Error()
        {
            return "HITTOAKOS TOISEN BLOGAUSTA YRITÄT SOTKEA?! SOTKE OMA!!";
        }
        //
        // POST: /Blog/Edit/5

        [HttpPost]
        public ActionResult Edit(Blogi blogi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogi);
        }

        //
        // GET: /Blog/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Blogi blogi = db.Blogit.Find(id);

            if (blogi.Nimi != User.Identity.Name)
            {
                return RedirectToAction("Error");
            }

            if (blogi == null)
            {
                return HttpNotFound();
            }
            return View(blogi);
        }

        //
        // POST: /Blog/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Blogi blogi = db.Blogit.Find(id);
            db.Blogit.Remove(blogi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}