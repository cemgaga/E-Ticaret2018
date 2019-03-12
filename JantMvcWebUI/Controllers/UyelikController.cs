using System;
using System.Web;
using System.Web.Mvc;
using Jant.Bll;
using Jant.Dal.Concrete.EntityFramework;
using Jant.Entities;
using JantMvcWebUI.Models;
using System.IO;

namespace JantMvcWebUI.Controllers
{
    public class UyelikController : Controller
    {
        UyeManager manager = new UyeManager(new EfUyeDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(MemberLoginModel Uye)
        {
            Uye kontrol = manager.MemberLogin(Uye.Email, Uye.Parola);

            if (kontrol != null)
            {
                Uye.Ad = kontrol.Ad;
                Uye.Soyad = kontrol.Soyad;
                Uye.UyeId=kontrol.UyeId;
                Session["UyeGirdi"] = Uye;
                return View("SuccessfullyLogin");
            }
            return View("FailedLogin");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Uye yeniuye, HttpPostedFileBase Resim)
        {
            if (Resim != null)
            {
                string resimAd = DateTime.Now.ToString();
                resimAd = resimAd.Replace(".", "-");
                resimAd = resimAd.Replace(" ", "-");
                resimAd = resimAd.Replace(":", "-");
                resimAd = resimAd + "_" + Resim.FileName;
                
                Directory.CreateDirectory(Server.MapPath("~/Content/Users/" + yeniuye.Mail + ""));
                Resim.SaveAs(Server.MapPath("~/Content/Users/" + yeniuye.Mail + "/") + yeniuye.Mail + ".jpg");
                string kaynakDosya = Server.MapPath("~/Content/jantdene.swf");
                string hedef = Server.MapPath("~/Content/Users/" + yeniuye.Mail + "/");
                string pathyol = Path.Combine(hedef, Path.GetFileName(kaynakDosya));
                System.IO.File.Copy(kaynakDosya, pathyol, true);
                yeniuye.AracResim = resimAd;
            }
            bool kontrol = manager.MemberRegister(yeniuye);

            if (kontrol == true)
            {
                return View("SuccessfullyRegister");
            }
            return View("FailedRegister");
        }

        public ActionResult LogOut() 
        {
            Session["UyeGirdi"] = null;
            return View();
        }
        
    }
}



