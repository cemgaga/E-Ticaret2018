using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jant.Bll;
using Jant.Dal.Concrete.EntityFramework;
using PagedList;
using System.IO;
using System.Xml;

namespace JantMvcWebUI.Controllers
{
    public class UrunController : Controller
    {

        private UrunManager manager = new UrunManager(new EfUrunDal());

        public ActionResult GetProductsByBrandId(int markaId, int page = 1)
        {
            return View(manager.GetProductsByBrandId(markaId).ToPagedList(page, 25));
        }
        public ActionResult GetProductDetails(int UrunId)
        {
            return View(manager.GetProductDetails(UrunId));
        }

        public ActionResult Search(string UrunKod)
        {
            return View(manager.Search(UrunKod));
        }

        public PartialViewResult GetProductsOfMonth()
        {
            return PartialView(manager.GetProductsOfMonth());
        }

        public PartialViewResult GetProductOfWeek()
        {
            return PartialView(manager.GetProductOfWeek());
        }

        public ActionResult GetProductsOfMonthPage()
        {
            return View(manager.GetProductsOfMonth());
        }

        public ActionResult GetProductOfWeekPage()
        {
            return View(manager.GetProductOfWeek());
        }

        public ActionResult TryWheel(string mail, string jantResimAdi)
        {
            string a = mail;
            string url="http://localhost:54133/";
            ViewBag.mail = mail;
            if (System.IO.File.Exists(Server.MapPath("~/Content/Users/" + a + "/resimcek.xml")))
            {
                System.IO.File.Delete(Server.MapPath("~/Content/Users/" + a + "/resimcek.xml"));
            }
            try
            {
                
                XmlTextWriter xmlolustur = new XmlTextWriter(Server.MapPath("~/Content/Users/" + a + "/resimcek.xml"),null);//ilk parametre dosyanın oluşturulacağı yol, ikinci parametre encoding dil kodlama
                xmlolustur.WriteStartDocument();//xml içinde element oluşturma işlemine başlandı
                xmlolustur.WriteComment("Seçilen jant ve araç resmi");//dosya içine bir açıklama satırı eklendi
                xmlolustur.WriteStartElement("data");//bir etiket oluşturduk
                xmlolustur.WriteEndDocument();//element oluşturma işlemi bitti
                xmlolustur.Close();//dosya oluşturuldu ve işlemler tamamlandı
            }
            catch
            {
            }
            if (System.IO.File.Exists(Server.MapPath("~/Content/Users/" + a + "/resimcek.xml")))
            {
                XmlDocument belge = new XmlDocument();
                belge.Load(Server.MapPath("~/Content/Users/" + a + "/resimcek.xml"));
                XmlElement UserElement = belge.CreateElement("gun");//element ekledik
                UserElement.SetAttribute("name", "1");//elemente bir attribute atadık
                XmlElement kullaniciadi = belge.CreateElement("resim");//Kullanicilar elementi içine bir kayıt ekledik
                kullaniciadi.InnerText =""+url+"Content/Users/"+ a + "/"+a+".jpg";//kayıt için değer atadık
                UserElement.AppendChild(kullaniciadi);//kayıt için parent atadık (UserElemet parenti)
                belge.DocumentElement.AppendChild(UserElement);//xml dosyamıza element ve kayıtları ekledik
                XmlTextWriter xmleEkle = new XmlTextWriter(Server.MapPath("~/Content/Users/" + a + "/resimcek.xml"), null);//xml dosyamıza fiziksel olarak kayıtları yazıyoruz
                xmleEkle.Formatting = Formatting.Indented;
                belge.WriteContentTo(xmleEkle);//kayıtlar eklendi
                xmleEkle.Close();//dosya kapatıldı
            }
            else
            { }
            //---------------------------------------------------
            if (System.IO.File.Exists(Server.MapPath("~/Content/Users/" + a + "/resimcek.xml")))
            {
                XmlDocument belge = new XmlDocument();
                belge.Load(Server.MapPath("~/Content/Users/" + a + "/resimcek.xml"));
                XmlElement UserElement = belge.CreateElement("gun");//element ekledik
                UserElement.SetAttribute("name", "2");//elemente bir attribute atadık
                XmlElement kullaniciadi = belge.CreateElement("resim");//Kullanicilar elementi içine bir kayıt ekledik
                UserElement.AppendChild(kullaniciadi);//kayıt için parent atadık (UserElemet parenti)
                kullaniciadi.InnerText = ""+url+"Content/Wheels/" + jantResimAdi + "";//kayıt için değer atadık
                belge.DocumentElement.AppendChild(UserElement);//xml dosyamıza element ve kayıtları ekledik
                XmlTextWriter xmleEkle = new XmlTextWriter(Server.MapPath("~/Content/Users/" + a + "/resimcek.xml"), null);//xml dosyamıza fiziksel olarak kayıtları yazıyoruz
                xmleEkle.Formatting = Formatting.Indented;
                belge.WriteContentTo(xmleEkle);//kayıtlar eklendi
                xmleEkle.Close();//dosya kapatıldı
            }
            else
            { }
            //---------------------------------------------------------
            if (System.IO.File.Exists(Server.MapPath("~/Content/Users/" + a + "/resimcek.xml")))
            {
                XmlDocument belge = new XmlDocument();
                belge.Load(Server.MapPath("~/Content/Users/" + a + "/resimcek.xml"));
                XmlElement UserElement = belge.CreateElement("gun");//element ekledik
                UserElement.SetAttribute("name", "3");//elemente bir attribute atadık
                XmlElement kullaniciadi = belge.CreateElement("resim");//Kullanicilar elementi içine bir kayıt ekledik
                UserElement.AppendChild(kullaniciadi);//kayıt için parent atadık (UserElemet parenti)
                kullaniciadi.InnerText = ""+url+"Content/Wheels/" + jantResimAdi + "";//kayıt için değer atadık
                belge.DocumentElement.AppendChild(UserElement);//xml dosyamıza element ve kayıtları ekledik
                XmlTextWriter xmleEkle = new XmlTextWriter(Server.MapPath("~/Content/Users/" + a + "/resimcek.xml"), null);//xml dosyamıza fiziksel olarak kayıtları yazıyoruz
                xmleEkle.Formatting = Formatting.Indented;
                belge.WriteContentTo(xmleEkle);//kayıtlar eklendi
                xmleEkle.Close();//dosya kapatıldı
            }
            else
            { }

            return View();
        }
    }
}