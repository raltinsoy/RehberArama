using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RehberArama.Models;

namespace RehberArama.Controllers
{
    public class SearchController : Controller
    {
        private RehberEntities db = new RehberEntities();
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string ara)
        {
            if (!String.IsNullOrEmpty(ara))
            {
                var result = from m in db.SearchModels
                             where m.Ad.Contains(ara) ||
                                   m.Soyad.Contains(ara) ||
                                   m.Unite.Contains(ara) ||
                                   m.Fabrika.Contains(ara) ||
                                   m.Pozisyon.Contains(ara) ||
                                   m.Kurumsal_Tel.Contains(ara) ||
                                   m.Telsiz_No.Contains(ara) ||
                                   m.Is_Tel2.Contains(ara) ||
                                   m.Email.Contains(ara) ||
                                   m.Is_Tel1.Contains(ara)
                             select m;

                string birlestir = "";

                foreach (var item in result)
                {
                    if (item.Ad != null && item.Ad.ToLower().Contains(ara.ToLower()))
                        item.Ad = item.Ad.ToLower().Replace(ara.ToLower(), "<span>" + ara + "</span>");
                    if (item.Soyad != null && item.Soyad.ToLower().Contains(ara.ToLower()))
                        item.Soyad = item.Soyad.ToLower().Replace(ara.ToLower(), "<span>" + ara + "</span>");
                    if (item.Unite != null && item.Unite.ToLower().Contains(ara.ToLower()))
                        item.Unite = item.Unite.ToLower().Replace(ara.ToLower(), "<span>" + ara + "</span>");
                    if (item.Fabrika != null && item.Fabrika.ToLower().Contains(ara.ToLower()))
                        item.Fabrika = item.Fabrika.ToLower().Replace(ara.ToLower(), "<span>" + ara + "</span>");
                    if (item.Pozisyon != null && item.Pozisyon.ToLower().Contains(ara.ToLower()))
                        item.Pozisyon = item.Pozisyon.ToLower().Replace(ara.ToLower(), "<span>" + ara + "</span>");
                    if (item.Kurumsal_Tel != null && item.Kurumsal_Tel.Contains(ara))
                        item.Kurumsal_Tel = item.Kurumsal_Tel.Replace(ara, "<span>" + ara + "</span>");
                    if (item.Email != null && item.Email.ToLower().Contains(ara.ToLower()))
                        item.Email = item.Email.ToLower().Replace(ara.ToLower(), "<span>" + ara + "</span>");
                    if (item.Is_Tel1 != null && item.Is_Tel1.Contains(ara))
                        item.Is_Tel1 = item.Is_Tel1.Replace(ara, "<span>" + ara + "</span>");
                    if (item.Is_Tel2 != null && item.Is_Tel2.Contains(ara))
                        item.Is_Tel2 = item.Is_Tel2.Replace(ara, "<span>" + ara + "</span>");
                    if (item.Telsiz_No != null && item.Telsiz_No.Contains(ara))
                        item.Telsiz_No = item.Telsiz_No.Replace(ara, "<span>" + ara + "</span>");

                    birlestir += "<div class=\"araDiv\" align=\"center\"><h4>";
                    birlestir += item.Ad + " | " + item.Soyad;
                    birlestir += "</h4><h6>";
                    birlestir += item.Unite + " | " + item.Fabrika + " | " + item.Pozisyon + " | "
                                    + item.Kurumsal_Tel + " | " + item.Email + " | "
                                    + item.Is_Tel1 + " | " + item.Is_Tel2 + " | " + item.Telsiz_No;
                    birlestir += "</h6></div>";
                }

                return View("Index", "~/Views/Shared/_Layout.cshtml", birlestir);
            }
            return View();
        }

        [HttpGet]
        public ActionResult Select2Search()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Select2GetJson(string q)
        {
            if (!String.IsNullOrEmpty(q))
            {
                var result = from m in db.SearchModels
                             where m.Ad.Contains(q) ||
                                   m.Soyad.Contains(q) ||
                                   m.Unite.Contains(q) ||
                                   m.Fabrika.Contains(q) ||
                                   m.Telsiz_No.Contains(q) ||
                                   m.Is_Tel2.Contains(q) ||
                                   m.Pozisyon.Contains(q) ||
                                   m.Kurumsal_Tel.Contains(q) ||
                                   m.Email.Contains(q) ||
                                   m.Is_Tel1.Contains(q)
                             select m;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Json(JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public string EklenecekListe(string q)
        {
            string donus = "";
            if (!String.IsNullOrEmpty(q))
            {
                int _q = Convert.ToInt32(q);
                var result = from m in db.SearchModels
                             where m.ID == _q
                             select m;

                var tekKaynak = result.First();
                donus = "<tr>" +
                            "<th colspan=\"2\"><img style=\"width:100px;\" src=" + tekKaynak.resimUrl + "></th>" +
                        "</tr>" +
                        "<tr>" +
                            "<th>Ad</th>" +
                            "<td>" + tekKaynak.Ad + "</td>" +
                        "</tr>" +
                        "<tr>" +
                            "<th>Soyad</th>" +
                            "<td>" + tekKaynak.Soyad + "</td>" +
                        "</tr>";
            }
            return donus;
        }
    }
}