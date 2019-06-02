using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sektion1;

namespace Sektion1.Controllers
{
    public class PeopleController : Controller
    {
        private FamiljDatabasenEntities db = new FamiljDatabasenEntities();

        // GET: People
        public ActionResult Index()  // VISAR LISTAN
        {
            try{
            var person = db.Person.Include(p => p.Familj);
            return View(person.ToList());
            }

            catch
            {
                return RedirectToAction("Home", "Index"); // gå till main
            }
            
        }

        // GET: People/Details/5
        public ActionResult Details(int? id) // TRYCKER DU PÅ DETAILS I LISTAN LEDER DEN DIG HIT
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Person.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create() // skapa en person
        {

            try
            {
            ViewBag.familjId = new SelectList(db.Familj, "familjId", "familjnamn");
            return View();
            }

            catch
            {
              
                return RedirectToAction("Home", "Index"); // gå till main
               
            }
        }

        // POST: People/Create
     
        [HttpPost]
        [ValidateAntiForgeryToken] // postar en person och hämtar främmande nyckel ifrån familj
        public ActionResult Create([Bind(Include = "personId,familjId,fornamn,efternamn,alder,tel,Utbildning")] Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Person.Add(person);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

               
            }

            catch(DataException) // ger error vid fältet
            {
                 ModelState.AddModelError("", "Obs. Alla fält måste vara inmatade!");
            }

            ViewBag.familjId = new SelectList(db.Familj, "familjId", "familjnamn", person.familjId);
            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id) 
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Person person = db.Person.Find(id);
                if (person == null)
                {
                    return HttpNotFound();
                }
                ViewBag.familjId = new SelectList(db.Familj, "familjId", "familjnamn", person.familjId);
                return View(person);
            }


            catch
            {
                return RedirectToAction("Home", "Index"); // gå till main
            }

           
        }

        // POST: People/Edit/5
  
        [HttpPost]
        [ValidateAntiForgeryToken] // ändra person
        public ActionResult Edit([Bind(Include = "personId,familjId,fornamn,efternamn,alder,tel,Utbildning")] Person person)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(person).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
               
            }

            catch (DataException)
            {
                ModelState.AddModelError("", "OBS inga fält får vara tomma vid en redigering");
            }

            ViewBag.familjId = new SelectList(db.Familj, "familjId", "familjnamn", person.familjId);
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id,  bool? saveChangesError = false) //radera en person
        {
            try
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                if (saveChangesError.GetValueOrDefault())
                {
                    ViewBag.ErrorMessage = "Misslyckades att radera film. Försök igen!";
                }

                Person person = db.Person.Find(id);
                if (person == null)
                {
                    return HttpNotFound();
                }
                return View(person);
            }

            catch
            {
                return RedirectToAction("Home", "Index"); // gå till main
            }
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Person person = db.Person.Find(id);
                db.Person.Remove(person);
                db.SaveChanges();
                
            }


            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
