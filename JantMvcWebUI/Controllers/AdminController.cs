using Jant.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jant.Dal.Concrete.EntityFramework;
using Jant.Entities;
using PagedList;
using JantMvcWebUI.Models;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
namespace JantMvcWebUI.Controllers
{
    public class AdminController : Controller
    {
        private AdminManager manager = new AdminManager(new EfAdminDal());

        private UrunManager UrunManager = new UrunManager(new EfUrunDal());
        private MarkaManager MarkaManager = new MarkaManager(new EfMarkaDal());
        Resim resim;
        List<string> resimAdlari;
        // GET: Admin
        public ActionResult Index(int page = 1)
        {
            if (Session["Admin"] != null)
            {
                List<Urun> Products = manager.GetAll();
                return View(Products.ToPagedList(page, 9));
            }
            else return View("Login");

        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string k_adi, string parola)
        {
            bool kontrol = manager.AdminLogin(k_adi, parola);

            if (kontrol == true)
            {
                Session["Admin"] = true;
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult AddProduct()
        {
            if (Session["Admin"] != null)
            {
                List<Marka> markalar = MarkaManager.GetAll();
                List<SelectListItem> items = new List<SelectListItem>();
                foreach (var item in markalar)
                {
                    items.Add(new SelectListItem { Text = item.MarkaAdi, Value = item.MarkaId.ToString() });
                }
                ViewBag.Markalar = items;
                return View();
            }
            else return View("Login");

        }

        [HttpPost]
        public ActionResult AddProduct(Urun urun, List<HttpPostedFileBase> resimler)
        {
            if (Session["Admin"] != null)
            {
                bool kontrol = false;
                for (int i = 0; i < resimler.Count; i++)
                {
                    if (resimler[i] == null)
                    {
                        continue;
                        //return View("FailedAddProduct");
                    }
                    resim = new Resim();
                    if (i == 0) resim.AnaResim = true;
                    else resim.AnaResim = false;
                    resim.ResimUrl = DateTime.Now.ToString();
                    resim.ResimUrl = resim.ResimUrl.Replace(".", "-");
                    resim.ResimUrl = resim.ResimUrl.Replace(" ", "-");
                    resim.ResimUrl = resim.ResimUrl.Replace("/", "-");
                    resim.ResimUrl = resim.ResimUrl.Replace("\\" ,"-");
                    resim.ResimUrl = resim.ResimUrl.Replace(":", "-");
                    resim.ResimUrl = resim.ResimUrl + resimler[i].FileName.ToString();
                    if (Directory.Exists(Server.MapPath("~/Content/Wheels")) == false)
                        Directory.CreateDirectory(Server.MapPath("~/Content/Wheels"));
                    resimler[i].SaveAs(Server.MapPath("~/Content/Wheels/") + resim.ResimUrl);
                    urun.Resimler.Add(resim);
                }
                kontrol = manager.AddProduct(urun, urun.Resimler);
                if (kontrol == true)
                {
                    return View("SuccessfullyAddProduct");
                }
                return View("FailedAddProduct");
            }
            else return View("Login");

        }

        public ActionResult DeleteProduct(int page = 1)
        {
            if (Session["Admin"] != null)
            {
                List<Urun> urunler = manager.GetAll();
                return View(urunler.ToPagedList(page, 9));
            }
            else return View("Login");
        }
        [HttpPost]
        public ActionResult DeleteProduct(List<int> UrunId)
        {
            if (Session["Admin"] != null)
            {
                bool kontrol = false;
                resimAdlari = manager.GetProductPhotoNames(UrunId);
                for (int i = 0; i < resimAdlari.Count; i++)
                {
                    System.IO.File.Delete(Server.MapPath("~/Content/Wheels/" + resimAdlari[i]));
                }
                kontrol = manager.DeleteProduct(UrunId);
                if (kontrol == true)
                {
                    return View("SuccessfullyDeleteProduct");
                }
                return View("FailedAddProduct");
            }
            else return View("Login");
        }
        public ActionResult AddBrand()
        {
            if (Session["Admin"] != null)
            {
                List<Marka> markalar = MarkaManager.GetAll();
                return View(markalar);
            }
            else return View("Login");
        }
        [HttpPost]
        public ActionResult AddBrand(string markaAdi)
        {
            if (Session["Admin"] != null)
            {
                bool kontrol = false;
                kontrol = manager.AddBrand(markaAdi);
                if (kontrol)
                {
                    return View("SuccessfullyAddBrand");
                }
                return View("FailedAddBrand");
            }
            else return View("Login");
        }
        public ActionResult DeleteBrands(List<int> MarkaId)
        {
            if (Session["Admin"] != null)
            {
                bool kontrol = false;
                kontrol = manager.DeleteBrands(MarkaId);
                if (kontrol == false)
                {
                    return View("FailedBrandDelete");
                }
                return View("SuccessfullyBrandDelete");
            }
            else return View("Login");
        }
        public ActionResult UpdateProduct(int productId)
        {
            if (Session["Admin"] != null)
            {
                Urun product = UrunManager.GetProductDetails(productId);
                List<Marka> markalar = MarkaManager.GetAll();
                List<SelectListItem> items = new List<SelectListItem>();
                foreach (var item in markalar)
                {
                    items.Add(new SelectListItem { Text = item.MarkaAdi, Value = item.MarkaId.ToString(), Selected = true });
                }
                ViewBag.Markalar = items;
                return View(product);
            }
            else return View("Login");
        }
        [HttpPost]
        public ActionResult UpdateProduct(Urun urun)
        {
            if (Session["Admin"] != null)
            {
                bool kontrol = false;
                kontrol = manager.UpdateProduct(urun);
                if (kontrol == false)
                {
                    return View();
                }
                List<Urun> urunler = UrunManager.GetAll();
                return View("Index", urunler.ToPagedList(1, 9));
            }
            else return View("Login");
        }

        public ActionResult Logout()
        {
            if (Session["Admin"] != null) Session["Admin"] = null;
            return View("Login");
        }

    }
}