using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ClassLibraryDelta.Database;
using ClassLibraryDelta.Entities;

namespace DeltaCode.Controllers
{
    public class CommandsController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: Commands
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> Index()
        {
            return View(await db.Commands.Include(x => x.Seller).Include(x => x.Client).ToListAsync());
        }

        // GET: Commands/Details/5
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Command command = await db.Commands.Include(x => x.Seller).Include(x => x.Client).FirstOrDefaultAsync(x => x.CommandID == id);
            ViewBag.SellerName = String.Format(command.Seller.FirstName + ' ' + command.Seller.LastName);
            ViewBag.ClientName = String.Format(command.Client.FirstName + ' ' + command.Client.LastName);
            if (command == null)
            {
                return HttpNotFound();
            }
            return View(command);
        }

        // GET: Commands/Create
        [Authorize(Roles = "User, Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Commands/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommandID,DateCommand")] Command command)
        {
            if (ModelState.IsValid)
            {
                db.Commands.Add(command);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(command);
        }

        // GET: Commands/Edit/5
        [Authorize(Roles = "User, Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Command command = db.Commands.Find(id);
            if (command == null)
            {
                return HttpNotFound();
            }
            return View(command);
        }

        // POST: Commands/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommandID,DateCommand")] Command command)
        {
            if (ModelState.IsValid)
            {
                db.Entry(command).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(command);
        }

        // GET: Commands/Delete/5
        [Authorize(Roles = "User, Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Command command = db.Commands.Find(id);
            if (command == null)
            {
                return HttpNotFound();
            }
            return View(command);
        }

        // POST: Commands/Delete/5
        [Authorize(Roles = "User, Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Command command = db.Commands.Find(id);
            db.Commands.Remove(command);
            db.SaveChanges();
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
