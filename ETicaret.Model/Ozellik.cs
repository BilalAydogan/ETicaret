using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model
{
    [Table("tblOzellik")]
    public class Ozellik
    {
        public Ozellik()
        {
            
        }
        public int Id { get; set; }
        public string Ad { get; set; }
        public int GrupId { get; set; }
    }
}
