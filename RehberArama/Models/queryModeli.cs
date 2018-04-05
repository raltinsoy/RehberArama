using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RehberArama.Models
{
    public class queryModeli
    {
        public string durum { get; set; }
        public string kategori { get; set; }
        public string search { get; set; }
        public string isim { get; set; }

        public bool NullMi()
        {
            if (String.IsNullOrEmpty(durum) ||
                String.IsNullOrEmpty(kategori) ||
                String.IsNullOrEmpty(search) ||
                String.IsNullOrEmpty(isim))
                return true;
            return false;
        }
    }

    [MetadataType(typeof(SearchModels_Metadata))]
    public partial class SearchModels { }

    public class SearchModels_Metadata
    {
        [Required]
        public string Ad { get; set; }
        [Required]
        public string Soyad { get; set; }
        [Required]
        public string Unite { get; set; }
        [Required]
        public string Fabrika { get; set; }
        [Required]
        public string Pozisyon { get; set; }
    }

}