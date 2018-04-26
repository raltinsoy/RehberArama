using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RehberArama.Models
{
    public class AramaSecenekleriSingletonPattern
    {
        private static List<SelectListItem> aramaSecenekleri = null;
        private static readonly object padlock = new object();

        public static List<SelectListItem> AramaSecenekleri
        {
            get
            {
                lock (padlock)
                {
                    if (aramaSecenekleri == null)
                    {
                        aramaSecenekleri = new List<SelectListItem>();
                        AramaSecenekleri.Add(new SelectListItem { Text = "Ad", Value = "Ad", Selected = true });
                        AramaSecenekleri.Add(new SelectListItem { Text = "Soyad", Value = "Soyad" });
                        AramaSecenekleri.Add(new SelectListItem { Text = "Müdürlük", Value = "Unite" });
                        AramaSecenekleri.Add(new SelectListItem { Text = "Fabrika", Value = "Fabrika" });
                        AramaSecenekleri.Add(new SelectListItem { Text = "Pozisyon", Value = "Pozisyon" });
                        AramaSecenekleri.Add(new SelectListItem { Text = "Telefon", Value = "Kurumsal Telefon" });
                    }
                    return aramaSecenekleri;
                }
            }
        }
    }
}