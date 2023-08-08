using ETicaret.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository
{
    internal class UrunFotoRepository : RepositoryBase<UrunFoto>
    {
        public UrunFotoRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
