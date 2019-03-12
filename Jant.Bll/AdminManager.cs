using Jant.Dal.Abstract;
using Jant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jant.Bll
{
    public class AdminManager
    {
        private IAdminDal adminDal;
        public AdminManager(IAdminDal _adminDal)
        {
            adminDal = _adminDal;
        }
        public bool AdminLogin(string k_adi, string parola)
        {
            return adminDal.AdminLogin(k_adi,parola);
        }
        public bool AddProduct(Urun urun, List<Resim> Resimler)
        {
            return adminDal.AddProduct(urun,Resimler);
        }
        public bool DeleteProduct(List<int> UrunId)
        {
            return adminDal.DeleteProduct(UrunId);
        }
        public bool UpdateProduct(Urun urun)
        {
            return adminDal.UpdateProduct(urun);
        }

        public List<string> GetProductPhotoNames(List<int> UrunId)
        {
            return adminDal.GetProductPhotoNames(UrunId);
        }
        public bool AddBrand(string markaAdi) 
        {
            return adminDal.AddBrand(markaAdi);
        }
        public bool DeleteBrands(List<int> markaId)
        {
            return adminDal.DeleteBrands(markaId);
        }
        public List<Urun> GetAll() 
        {
            return adminDal.GetAll();
        }

    }
}
