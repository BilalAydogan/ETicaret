using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model
{
    [Table("tblUrunFoto")]
    public class UrunFoto
    {
        public UrunFoto()
        {
            
        }
        public int Id { get; set; }
        public int UrunId { get; set; }
        public string Foto { get; set; }
        public bool? IlkFotoMu { get; set; }
    }
}
