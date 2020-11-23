using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cards.Models;
using Cards.Tests.Models;

namespace Cards.Tests.Controllers
{   
    public class CardsController : Controller
    {
        private CardsTestsContext context = new CardsTestsContext();

        //
        // GET: /Cards/

        public ViewResult Index()
        {
            return View(context.Cards.ToList());
        }

        //
        // GET: /Cards/Details/5

        public ViewResult Details(int id)
        {
            Card card = context.Cards.Single(x => x.CardId == id);
            return View(card);
        }

        //
        // GET: /Cards/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Cards/Create

        [HttpPost]
        public ActionResult Create(Card card)
        {
            if (ModelState.IsValid)
            {
                context.Cards.Add(card);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(card);
        }
        
        //
        // GET: /Cards/Edit/5
 
        public ActionResult Edit(int id)
        {
            Card card = context.Cards.Single(x => x.CardId == id);
            return View(card);
        }

        //
        // POST: /Cards/Edit/5

        [HttpPost]
        public ActionResult Edit(Card card)
        {
            if (ModelState.IsValid)
            {
                context.Entry(card).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(card);
        }

        //
        // GET: /Cards/Delete/5
 
        public ActionResult Delete(int id)
        {
            Card card = context.Cards.Single(x => x.CardId == id);
            return View(card);
        }

        //
        // POST: /Cards/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Card card = context.Cards.Single(x => x.CardId == id);
            context.Cards.Remove(card);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}