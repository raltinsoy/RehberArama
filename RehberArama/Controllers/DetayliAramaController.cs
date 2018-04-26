using RehberArama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Arama.Controllers
{
    public class DetayliAramaController : Controller
    {
        private RehberEntities db = new RehberEntities();

        // GET: DetayliArama
        public ActionResult Index()
        {
            ViewBag.Kategori = AramaSecenekleriSingletonPattern.AramaSecenekleri;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(queryModeli model)
        {
            ViewBag.Kategori = AramaSecenekleriSingletonPattern.AramaSecenekleri;

            if (!String.IsNullOrEmpty(model.search) && !String.IsNullOrEmpty(model.kategori))
            {
                var kisi = from d in db.SearchModels
                           select d;

                if (model.kategori == "Ad")
                {
                    if (model.durum == "1")
                        kisi = kisi.Where(s => s.Ad.Contains(model.search));
                    else
                        kisi = kisi.Where(s => s.Ad.StartsWith(model.search));
                }
                else if (model.kategori == "Soyad")
                {
                    if (model.durum == "1")
                        kisi = kisi.Where(s => s.Soyad.Contains(model.search));
                    else
                        kisi = kisi.Where(s => s.Soyad.StartsWith(model.search));
                }
                else if (model.kategori == "Unite")
                {
                    if (model.durum == "1")
                        kisi = kisi.Where(s => s.Unite.Contains(model.search));
                    else
                        kisi = kisi.Where(s => s.Unite.StartsWith(model.search));
                }
                else if (model.kategori == "Fabrika")
                {
                    if (model.durum == "1")
                        kisi = kisi.Where(s => s.Fabrika.Contains(model.search));
                    else
                        kisi = kisi.Where(s => s.Fabrika.StartsWith(model.search));
                }
                else if (model.kategori == "Pozisyon")
                {
                    if (model.durum == "1")
                        kisi = kisi.Where(s => s.Pozisyon.Contains(model.search));
                    else
                        kisi = kisi.Where(s => s.Pozisyon.StartsWith(model.search));
                }
                else if (model.kategori == "Kurumsal Telefon")
                {
                    if (model.durum == "1")
                        kisi = kisi.Where(s => s.Kurumsal_Tel.Contains(model.search));
                    else
                        kisi = kisi.Where(s => s.Kurumsal_Tel.StartsWith(model.search));
                }

                List<DetayliAramaModel> liste = new List<DetayliAramaModel>(); ;
                foreach (var i in kisi)
                {
                    liste.Add(new DetayliAramaModel { kisi = i.Ad + " " + i.Soyad, kisiID = i.ID });
                }

                return View(liste);
            }

            return View();
        }

        public ActionResult SonucGetir(int? id)
        {
            if (id == null)
                return new HttpNotFoundResult();

            var sonuc = db.SearchModels.Where(s => s.ID == id).FirstOrDefault();
            if (sonuc == null)
                return new HttpNotFoundResult();

            return PartialView("_SonucGetir", sonuc);

        }
    }
}
