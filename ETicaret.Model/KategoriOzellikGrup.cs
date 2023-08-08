using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model
{
    [Table("tblKategoriOzellikGrup")]
    public class KategoriOzellikGrup
    {
        public KategoriOzellikGrup()
        {
            
        }
        public int Id { get; set; } 
        public int KategoriId { get; set; }
        public int GrupId { get; set; }
    }
}
