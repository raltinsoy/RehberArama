using RehberArama.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Arama.Controllers
{
    public class RehberlerController : Controller
    {
        public RehberlerController()
        {
            ;
        }

        private RehberEntities db = new RehberEntities();

        [HttpGet]
        public ActionResult SorguKategori()
        {
            // Arama kısmı kategorileri
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Ad", Value = "Ad", Selected = true });
            items.Add(new SelectListItem { Text = "Soyad", Value = "Soyad" });
            items.Add(new SelectListItem { Text = "Müdürlük", Value = "Unite" });
            items.Add(new SelectListItem { Text = "Fabrika", Value = "Fabrika" });
            items.Add(new SelectListItem { Text = "Pozisyon", Value = "Pozisyon" });
            items.Add(new SelectListItem { Text = "Telefon", Value = "Kurumsal Telefon" });
            ViewBag.Kategori = items;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SorguKategori(queryModeli model)
        {
            // Arama kısmı kategorileri
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Ad", Value = "Ad", Selected = true });
            items.Add(new SelectListItem { Text = "Soyad", Value = "Soyad" });
            items.Add(new SelectListItem { Text = "Müdürlük", Value = "Unite" });
            items.Add(new SelectListItem { Text = "Fabrika", Value = "Fabrika" });
            items.Add(new SelectListItem { Text = "Pozisyon", Value = "Pozisyon" });
            items.Add(new SelectListItem { Text = "Telefon", Value = "Kurumsal Telefon" });
            ViewBag.Kategori = items;

            if (!String.IsNullOrEmpty(model.search) && !String.IsNullOrEmpty(model.kategori))
            {
                IEnumerable<SelectListItem> donen;
                if (model.kategori == "Kurumsal Telefon")
                    model.kategori = "Kurumsal_Tel";
                if (model.durum == "1")
                    donen = new SelectList(db.SearchModels, "Ad", model.kategori, "ID", db)
                        .Where // Seçilen kategori nin altında eşleştiriyor
                            (s => s.Text.ToLower().Contains(model.search.ToLower())
                            ).OrderBy(s => s.Group.Name);
                else
                    donen = new SelectList(db.SearchModels, "Ad", model.kategori, "ID", db)
                        .Where(s => s.Text.ToLower().StartsWith(model.search.ToLower()));
                

                /*if (kategori == "Ad")
                {
                    if (durum == "1")
                        kisi = kisi.Where(s => s.Ad.Contains(search));
                    else
                        kisi = kisi.Where(s => s.Ad.StartsWith(search));
                }
                else if (kategori == "Soyad")
                {
                    if (durum == "1")
                        kisi = kisi.Where(s => s.Soyad.Contains(search));
                    else
                        kisi = kisi.Where(s => s.Soyad.StartsWith(search));
                }
                else if (kategori == "Müdürlük")
                {
                    if (durum == "1")
                        kisi = kisi.Where(s => s.Unite.Contains(search));
                    else
                        kisi = kisi.Where(s => s.Unite.StartsWith(search));
                }
                else if (kategori == "Fabrika")
                {
                    if (durum == "1")
                        kisi = kisi.Where(s => s.Fabrika.Contains(search));
                    else
                        kisi = kisi.Where(s => s.Fabrika.StartsWith(search));
                }
                else if (kategori == "Pozisyon")
                {
                    if (durum == "1")
                        kisi = kisi.Where(s => s.Pozisyon.Contains(search));
                    else
                        kisi = kisi.Where(s => s.Pozisyon.StartsWith(search));
                }
                else if (kategori == "Telefon")
                {
                    if (durum == "1")
                        kisi = kisi.Where(s => s.Kurumsal_Tel.Contains(search));
                    else
                        kisi = kisi.Where(s => s.Kurumsal_Tel.StartsWith(search));
                }*/

                ViewBag.topModel = donen;
                if (donen.Count() == 1) // tek kayıt var ise gösteriyor
                {
                    dynamic ar = personelPartial(donen.First().Group.Name);
                    SearchModels modell = ar.Model;
                    return View(modell);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult soyadGetir(queryModeli model)
        {
            if (!model.NullMi()) // search ile geldiyse
            {
                IQueryable<SearchModels> kisi;
                if (model.kategori == "Ad")
                {
                    if (model.durum == "1")
                        kisi = db.SearchModels.Where(s => s.Ad.Contains(model.isim))
                            .Where(s => s.Ad.Contains(model.search));
                    else
                        kisi = db.SearchModels.Where(s => s.Ad.StartsWith(model.isim))
                            .Where(s => s.Ad.StartsWith(model.search));
                }
                else if (model.kategori == "Soyad")
                {
                    if (model.durum == "1")
                        kisi = db.SearchModels.Where(s => s.Ad.Contains(model.isim))
                            .Where(s => s.Soyad.Contains(model.search));
                    else
                        kisi = db.SearchModels.Where(s => s.Ad.StartsWith(model.isim))
                            .Where(s => s.Soyad.StartsWith(model.search));
                }
                else if (model.kategori == "Unite")
                {
                    if (model.durum == "1")
                        kisi = db.SearchModels.Where(s => s.Ad.Contains(model.isim)).Where(s => s.Unite.Contains(model.search));
                    else
                        kisi = db.SearchModels.Where(s => s.Ad.StartsWith(model.isim)).Where(s => s.Unite.StartsWith(model.search));
                }
                else if (model.kategori == "Fabrika")
                {
                    if (model.durum == "1")
                        kisi = db.SearchModels.Where(s => s.Ad.Contains(model.isim)).Where(s => s.Fabrika.Contains(model.search));
                    else
                        kisi = db.SearchModels.Where(s => s.Ad.StartsWith(model.isim)).Where(s => s.Fabrika.StartsWith(model.search));
                }
                else if (model.kategori == "Pozisyon")
                {
                    if (model.durum == "1")
                        kisi = db.SearchModels.Where(s => s.Ad.Contains(model.isim)).Where(s => s.Pozisyon.Contains(model.search));
                    else
                        kisi = db.SearchModels.Where(s => s.Ad.StartsWith(model.isim)).Where(s => s.Pozisyon.StartsWith(model.search));
                }
                else if (model.kategori == "Kurumsal Telefon")
                {
                    if (model.durum == "1")
                        kisi = db.SearchModels.Where(s => s.Ad.Contains(model.isim)).Where(s => s.Kurumsal_Tel.Contains(model.search));
                    else
                        kisi = db.SearchModels.Where(s => s.Ad.StartsWith(model.isim)).Where(s => s.Kurumsal_Tel.StartsWith(model.search));
                }
                else // Olmayan kategori seçimi
                    return PartialView();
                var sirali = kisi.OrderBy(m => m.Soyad);
                return PartialView("SoyadGetir",sirali);
            }
            return PartialView();
        }

        [HttpPost]
        public ActionResult personelPartial(string key)
        {
            if (!String.IsNullOrEmpty(key))
            {
                int _key = Convert.ToInt32(key);
                var sorgu = db.SearchModels.FirstOrDefault(s => s.ID == _key);
                if (sorgu != null)
                    return PartialView(sorgu);
            }
            return PartialView();
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
