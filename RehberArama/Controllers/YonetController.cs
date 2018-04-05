using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RehberArama.Models;

namespace Arama.Controllers
{
    public class YonetController : Controller
    {
        // Veritabanı bağlantısı
        private RehberEntities db = new RehberEntities();
        
        // GET: Yonet
        public ActionResult Index()
        {
            return View(db.SearchModels.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SearchModels rehberdb = db.SearchModels.Find(id);
            if (rehberdb == null)
            {
                return HttpNotFound();
            }
            return View(rehberdb);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ad,Soyad,Unite,Fabrika,Pozisyon,Is_Tel1,Is_Tel2,Kurumsal_Tel,Telsiz_No,Email")] SearchModels rehberdb)
        {
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(rehberdb.resimUrl))
                    rehberdb.resimUrl = "/images/user-128.png";
                db.SearchModels.Add(rehberdb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rehberdb);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SearchModels rehberdb = db.SearchModels.Find(id);
            if (rehberdb == null)
            {
                return HttpNotFound();
            }
            return View(rehberdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ad,Soyad,Unite,Fabrika"+
            ",Pozisyon,Is_Tel1,Is_Tel2,Kurumsal_Tel,Telsiz_No,Email,"+
            "resimUrl")] SearchModels rehberdb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rehberdb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rehberdb);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SearchModels rehberdb = db.SearchModels.Find(id);
            if (rehberdb == null)
            {
                return HttpNotFound();
            }
            return View(rehberdb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SearchModels rehberdb = db.SearchModels.Find(id);
            db.SearchModels.Remove(rehberdb);
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