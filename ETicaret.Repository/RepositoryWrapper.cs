using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository
{
    public class RepositoryWrapper
    {
        private RepositoryContext context;
        private KategoriRepository kategoriRepository;
        private RolRepository rolRepository;
        private KullaniciRepository kullaniciRepository;
        private UrunRepository urunRepository;
        public RepositoryWrapper(RepositoryContext context)
        {
            this.context = context;
        }

        public KategoriRepository KategoriRepository
        {
            get
            {
                if (kategoriRepository == null)
                    kategoriRepository = new KategoriRepository(context);
                return kategoriRepository;
            }
        }
        public RolRepository RolRepository
        {
            get
            {
                if (rolRepository == null)
                    rolRepository = new RolRepository(context);
                return rolRepository;
            }
        }
        public KullaniciRepository KullaniciRepository
        {
            get{
            if(kullaniciRepository == null)
                    kullaniciRepository = new KullaniciRepository(context);
             return kullaniciRepository;

            } 
        }
        public UrunRepository UrunRepository
        {
            get
            {
                if (urunRepository == null)
                    urunRepository = new UrunRepository(context);
                return urunRepository;

            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
    
}
