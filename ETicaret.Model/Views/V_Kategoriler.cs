using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model.Views
{
    [Table("V_Kategoriler")]
    public class V_Kategoriler
    {
        public V_Kategoriler()
        {
            
        }
        public int Id { get; set; }

        public string Ad { get; set; }
        public int? UstKategoriId { get; set; }
        public string? UstKategori { get; set; }
        public int Sira { get; set; }
        public bool Aktif { get; set; }

    }
}
