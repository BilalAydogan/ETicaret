using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model
{
    [Table("tblYorum")]
    public class Yorum
    {
        public Yorum()
        {
            
        }
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public int UrunId { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public int Puan { get; set; }
        public int Begendim { get; set; }
        public int Begenmedim { get; set; }
        public bool Onay { get; set; }
        public DateTime OnayTarih { get; set; }
        public int OnaylayanKullaniciId { get; set; }

    }
}
