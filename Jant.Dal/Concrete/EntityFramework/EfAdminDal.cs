using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jant.Dal.Abstract;
using Jant.Entities;
using System.Web;
using Jant.Dal.Concrete.EntityFramework;
using Jant.Entities;
using System.IO;

namespace Jant.Dal.Concrete.EntityFramework
{
    public class EfAdminDal : IAdminDal
    {
        public bool AdminLogin(string k_adi, string parola)
        {
            if (k_adi == "Furkan55" && parola == "1965ss")
            {
                return true;
            }
            else { return false; }

        }
        public bool AddProduct(Urun urun, List<Resim> Resimler)
        {
            using (JantDataContext context = new JantDataContext())
            {
                Marka marka = context.Markas.Where(p => p.MarkaId == urun.Marka.MarkaId).FirstOrDefault();
                urun.Marka = marka;
                urun.EklenmeTarihi = DateTime.Now;
                Urun urunVarmi = context.Uruns.FirstOrDefault(p => p.UrunKodu == urun.UrunKodu);
                if (urunVarmi != null)
                {
                    return false;
                }

                context.Uruns.Add(urun);

                for (int i = 0; i < Resimler.Count; i++)
                {
                    Resimler[i].Urun = urun;
                    context.Resims.Add(Resimler[i]);
                }
                context.SaveChanges();
                return true;
            }
        }
        
        public bool DeleteProduct(List<int> UrunId)
        {
            int id = 0; Urun urun ; List<Resim> resimler;
            using (JantDataContext contex=new JantDataContext())
            {
                for (int i = 0; i < UrunId.Count; i++)
                {
                    id = UrunId[i];
                    urun = contex.Uruns.Where(p=>p.UrunId==id).FirstOrDefault();
                    contex.Uruns.Remove(urun); 
                    resimler= contex.Resims.Where(p=>p.Urun.UrunId==id).ToList();
                    foreach (var item in resimler)
                    {
                        contex.Resims.Remove(item);
                    }
                }
                contex.SaveChanges();
            }
            return true;
        }
        public bool UpdateProduct(Urun urun)
        
        {
            Urun eskiHaftaninUrunu, eskiUrun;
            Marka marka;
            using (JantDataContext context = new JantDataContext())
            {
                if (urun.HaftaninUrunu==true)
                {
                    
                    eskiHaftaninUrunu = context.Uruns.Where(p => p.HaftaninUrunu == true).FirstOrDefault();
                    if (eskiHaftaninUrunu != null)
                    {
                        eskiHaftaninUrunu.HaftaninUrunu = false;
                        context.SaveChanges();
                    }
                }
                eskiUrun=context.Uruns.Where(p => p.UrunId == urun.UrunId).FirstOrDefault();
                marka = context.Markas.Where(p=>p.MarkaId==urun.Marka.MarkaId).FirstOrDefault();
                eskiUrun.Marka = marka;
                eskiUrun.KategoriId = urun.KategoriId;
                eskiUrun.Fiyat = urun.Fiyat;
                eskiUrun.Cap = urun.Cap;
                eskiUrun.Aciklama = urun.Aciklama;
                eskiUrun.UrunKodu = urun.UrunKodu;
                eskiUrun.HaftaninUrunu = urun.HaftaninUrunu;
                eskiUrun.AyinUrunu = urun.AyinUrunu;
                context.SaveChanges();
            }
            return true;
        }
        public List<string> GetProductPhotoNames(List<int> UrunId)
        {

            List<string> resimList = null;
            List<string> resimAdlari = new List<string>();
            using (JantDataContext context = new JantDataContext())
            {
                
                for (int i = 0; i < UrunId.Count; i++)
                {
                    int id=UrunId[i];
                    resimList = context.Resims.Where(p => p.Urun.UrunId == id).Select(p => p.ResimUrl).ToList();
                    foreach (var item in resimList)
                    {
                        resimAdlari.Add(item);
                    }
                }
            }
            return resimAdlari;
        }
        public bool AddBrand (string markaAdi)
        {
            Marka marka=null;
            using (JantDataContext contex = new JantDataContext())
            {
                Marka markaVarmi = contex.Markas.Where(p => p.MarkaAdi == markaAdi).FirstOrDefault();
                if (markaVarmi==null)
                {
                    marka = new Marka();   
                    marka.MarkaAdi = markaAdi;
                    contex.Markas.Add(marka);
                    contex.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public bool DeleteBrands(List<int> markaId)
        {
            Urun urun = null;
            int id=0;
            int sayac = 0;
            Marka marka;
            using (JantDataContext contex = new JantDataContext())
            {
                for (int i = 0; i < markaId.Count; i++)
                {
                    id= markaId[i];
                    urun = contex.Uruns.Where(p => p.Marka.MarkaId ==id).FirstOrDefault();

                    if (urun!=null)
                    {
                        sayac++;
                    }

                }
                if (sayac>0)
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < markaId.Count; i++)
                    {
                        id= markaId[i];
                        marka = contex.Markas.Where(p => p.MarkaId ==id).FirstOrDefault();
                        contex.Markas.Remove(marka);
                    }

                } 
                contex.SaveChanges();

            }
            return true;
        }
        public List<Urun> GetAll()
        {
            using (JantDataContext context = new JantDataContext())
            {
                return context.Uruns.Include("Marka").Include("Resimler").OrderByDescending(x => x.EklenmeTarihi).ToList();
            }
        }
    }
}
