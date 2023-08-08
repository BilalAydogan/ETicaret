using ETicaret.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository
{
    public class UrunRepository : RepositoryBase<Urun>
    {
        public UrunRepository(RepositoryContext context) : base(context)
        {
        }
        public List<Urun> UrunleriGetir(int kategoriId)
        {
            List<Urun> UrunKategori = (from k in RepositoryContext.Urunler
                                                  join a in RepositoryContext.UrunKategorileri on k.Id equals a.UrunId
                                                  where a.KategoriId == kategoriId
                                                  select k ).ToList<Urun>();
            return UrunKategori;
        }
        public void Sil(int urunId)
        {
            RepositoryContext.UrunKategorileri.Where(u => u.UrunId == urunId).ExecuteDelete();
            RepositoryContext.Urunler.Where(u=>u.Id == urunId).ExecuteDelete();
        }
    }
}
