using Jant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jant.Dal.Abstract
{
    public interface IAdminDal
    {
        bool AdminLogin(string k_adi, string parola);
        bool AddProduct(Urun urun, List<Resim> Resimler);
        bool DeleteProduct(List<int> UrunId);
        bool UpdateProduct(Urun urun);
        bool AddBrand(string markaAdi);
        bool DeleteBrands(List<int> markaId);
        List<string> GetProductPhotoNames(List<int> UrunId);
        List<Urun> GetAll();
    }
}
