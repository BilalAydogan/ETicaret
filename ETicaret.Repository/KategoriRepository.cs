using ETicaret.Model;
using ETicaret.Model.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository
{
    public class KategoriRepository : RepositoryBase<Kategori>
    {
        public KategoriRepository(RepositoryContext context) : base(context) 
        {
            
        }
        public void KategoriSil(int kategoriId)
        {
            RepositoryContext.Kategoriler.Where(k => k.Id == kategoriId).ExecuteDelete();
        }
        public List<Kategori> AnaSayfaKategorileriniGetir() {
            List<Kategori> anaSayfaKategoriler = (from k in RepositoryContext.Kategoriler
             join a in RepositoryContext.AnaSayfaKategoriler on k.Id equals a.KategoriId
             select k).ToList<Kategori>();
            return anaSayfaKategoriler;
        }
        public List<V_KategoriOzetListe> KategoriOzetListe()=>
            RepositoryContext.KategoriOzetListe.OrderBy(k=>k.Sira).ToList<V_KategoriOzetListe>();
        
        
    }
}
