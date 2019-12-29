using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassLibraryDelta.Database;
using ClassLibraryDelta.Entities;
using DeltaCode.Models.Security;
using DeltaCode.Utils.IdentityUtils;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DeltaCode.Controllers
{
    public class SellersController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: Sellers
        public ActionResult Index()
        {
            return View(db.Sellers.ToList());
        }

        // GET: Sellers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seller seller = db.Sellers.Find(id);
            if (seller == null)
            {
                return HttpNotFound();
            }
            return View(seller);
        }

        // GET: Sellers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sellers/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LastName,FirstName,Phone,Email,SellerAccount,Login,Password")] Seller seller)
        {
            if (ModelState.IsValid)
            {
                // Creation du vendeur dans le SecurityContext du projet ASP.NET
                using (var secudb = new SecurityDbContext())
                {
                    IdentityRole userRole = RoleUtils.CreateOrGetRole("Seller");
                    UserManager<MyIdentityUser> userManager = new MyIdentityUserManager(new UserStore<MyIdentityUser>(secudb));
                    MyIdentityUser sellerUser = new MyIdentityUser() { UserName = seller.Login, Email = seller.Email, Login = seller.Login }; ;
                    var result = userManager.Create(sellerUser, seller.Password);
                    if (!result.Succeeded)
                    {
                        throw new System.Exception("database insert fail");
                    }
                    RoleUtils.AssignRoleToUser(userRole, sellerUser);
                }

                // Creation du vendeur dans le ProductContext du projet librairie
                db.Sellers.Add(seller);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(seller);
        }


        // GET: Sellers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seller seller = db.Sellers.Find(id);
            if (seller == null)
            {
                return HttpNotFound();
            }
            return View(seller);
        }

        // POST: Sellers/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstName,Phone,Email,SellerAccount,Login,Password")] Seller seller)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seller).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seller);
        }

        // GET: Sellers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seller seller = db.Sellers.Find(id);
            if (seller == null)
            {
                return HttpNotFound();
            }
            return View(seller);
        }

        // POST: Sellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seller seller = db.Sellers.Find(id);
            db.Persons.Remove(seller);
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
