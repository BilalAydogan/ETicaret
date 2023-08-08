using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model
{
    [Table("tblUrun")]
    public class Urun
    {
        public Urun()
        {
            UrunKategoriler = new HashSet<UrunKategori>();
        }
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public int Adet { get; set; }   
        public decimal Fiyat { get; set; }  
        public virtual ICollection<UrunKategori> UrunKategoriler { get; set; }
    }
}
