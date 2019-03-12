using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jant.Dal.Abstract;
using Jant.Entities;

namespace Jant.Bll
{
    public class UrunManager
    {
        private IUrunDal urunDal;

        public UrunManager(IUrunDal _urunDal) 
        {
            urunDal = _urunDal;
        }

        public List<Urun> GetAll()
        {
            return urunDal.GetAll();
        }

        public Urun GetProductById(int urunId) 
        {
            return urunDal.GetProductById(urunId);
        }

        public List<Urun>GetProductsByBrandId(int markaId) 
        {
            return urunDal.GetProductsByBrandId(markaId);
        }

        public Urun GetProductDetails(int urunId)
        {
            return urunDal.GetProductDetails(urunId);
        }

        public List<Urun> GetFilteredResults(byte type, byte size, Int16 cost1, Int16 cost2)
        {
            return urunDal.GetFilteredResults(type,size,cost1,cost2);
        }

        public List<Urun> Search(string UrunKod)
        {
            return urunDal.Search(UrunKod);
        }

        public Urun GetProductOfWeek()
        {
            return urunDal.GetProductOfWeek();
        }

        public List<Urun> GetProductsOfMonth()
        {
            return urunDal.GetProductsOfMonth();
        }
    }
}
