using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model.Views
{
    [Table("V_KategoriOzetListe")]
    public class V_KategoriOzetListe
    {
        public int Id { get; set; }
        public string KategoriAd { get; set; }
        public string? UstKategoriAd { get; set; }
        public int Sira { get; set; }
        public bool Aktif { get; set; }
    }
}
