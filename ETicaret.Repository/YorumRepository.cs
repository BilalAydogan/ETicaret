using ETicaret.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository
{
    internal class YorumRepository : RepositoryBase<Yorum>
    {
        public YorumRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
