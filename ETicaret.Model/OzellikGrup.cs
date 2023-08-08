using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model
{
    [Table("tblOzellikGrup")]
    public class OzellikGrup
    {
        public OzellikGrup()
        {
            
        }
        public int Id { get; set; } 
        public string Ad { get; set; }
    }
}
