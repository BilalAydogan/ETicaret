using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
namespace ETicaret.Model
{
    [Table("tblKategori")]
    public class Kategori
    {
        public Kategori()
        {
            AltKategoriler = new HashSet<Kategori>();
        }
        public int Id { get; set; }
        public string Ad { get; set; }
        public int? UstKategoriId { get; set; }
        public int? Sira { get; set; }
        public string? Foto { get; set; }
        public bool? Aktif { get; set; }

        public virtual Kategori? UstKategori { get; set; }
        public virtual ICollection<Kategori>  AltKategoriler { get; set; } 
        

    }
}