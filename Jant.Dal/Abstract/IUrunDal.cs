using Jant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jant.Dal.Abstract
{
    public interface IUrunDal
    {
        List<Urun> GetAll();

        List<Urun> GetProductsByBrandId(int markaId);

        Urun GetProductById(int urunId);

        Urun GetProductDetails(int urunId);

        List<Urun> GetFilteredResults(byte type, byte size, Int16 cost1, Int16 cost2);

        List<Urun> Search(string UrunKod);

        Urun GetProductOfWeek();

        List<Urun> GetProductsOfMonth();

    }
}
