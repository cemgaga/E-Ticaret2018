using Jant.Dal.Abstract;
using Jant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jant.Dal.Concrete.EntityFramework
{
    public class EfUrunDal : IUrunDal
    {
        public List<Urun> GetAll()
        {
            using (JantDataContext context = new JantDataContext())
            {
                return context.Uruns.Include("Marka").Include("Resimler").Where(x=>x.HaftaninUrunu==false &&x.AyinUrunu==false). ToList();
            }
        }

        public Urun GetProductById(int urunId)
        {
            using (JantDataContext context = new JantDataContext())
            {
                return context.Uruns.Include("Marka").Include("Resimler").Where(p => p.UrunId == urunId).SingleOrDefault();
            }
        }

        public List<Urun> GetProductsByBrandId(int markaId)
        {
            JantDataContext context = new JantDataContext();
            
                return context.Uruns.Include("Marka").Where(p=>p.Marka.MarkaId==markaId).ToList();
            
        }
        public Urun GetProductDetails(int urunId)
        {
            using (JantDataContext context = new JantDataContext()) 
            {
                return context.Uruns.Include("Marka").Include("Resimler").Where(p => p.UrunId == urunId).FirstOrDefault();
            }
        }


        public List<Urun> GetFilteredResults(byte type, byte size, Int16 cost1, Int16 cost2)
        {
            JantDataContext context = new JantDataContext();
            
                if (type == 0 && size == 0) return context.Uruns.Include("Marka").Where(p => (p.Fiyat >= cost1 && p.Fiyat <= cost2)).ToList();

                if (type == 0 && cost2 == 0) return context.Uruns.Include("Marka").Where(p => p.Cap == size).ToList();

                if (size == 0 && cost2 == 0) return context.Uruns.Include("Marka").Where(p => p.KategoriId == type).ToList();

                if (type == 0) return context.Uruns.Include("Marka").Where(p => p.Cap == size  && (p.Fiyat >= cost1 && p.Fiyat <= cost2)).ToList();

                if (size == 0) return context.Uruns.Include("Marka").Where(p =>p.KategoriId == type && (p.Fiyat >= cost1 && p.Fiyat <= cost2)).ToList();

                if (cost2 == 0) return context.Uruns.Include("Marka").Where(p => p.KategoriId == type &&p.Cap==size).ToList();

                return context.Uruns.Include("Marka").Where(p => p.Cap == size && p.KategoriId == type && (p.Fiyat >= cost1 && p.Fiyat <= cost2)).ToList();

            
        }

        public List<Urun> Search(string UrunKod)
        {
            using(JantDataContext context = new JantDataContext())
	        {
                return context.Uruns.Include("Marka").Include("Resimler").Where(x => x.UrunKodu.Contains(UrunKod)).ToList();
	        }
            
        }

        public Urun GetProductOfWeek()
        {
            using (JantDataContext context = new JantDataContext())
            {
                return context.Uruns.Include("Marka").Include("Resimler").Where(x => x.HaftaninUrunu==true).FirstOrDefault();
            }
        }

        public List<Urun> GetProductsOfMonth()
        {
            using (JantDataContext context = new JantDataContext())
            {
                return context.Uruns.Include("Marka").Include("Resimler").Where(x => x.AyinUrunu == true).ToList();
            }
        }
    }

}
