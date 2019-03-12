using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jant.Entities;
using Jant.Bll;
using Jant.Dal.Concrete.EntityFramework;
using JantMvcWebUI.Models;

namespace JantMvcWebUI.Controllers
{
    public class SepetController : Controller
    {
        //
        // GET: /Sepet/

        private UrunManager manager = new UrunManager(new EfUrunDal());
        private SepetManager SepetManager = new SepetManager(new EfSepetDal());

        public ActionResult Index()
        {
            if (Session["UyeGirdi"] != null)
            {
                var sepet = new SepetSession();
                MemberLoginModel uye = (MemberLoginModel)Session["UyeGirdi"];
                List<SepettekiUrunler> sepettekiler = SepetManager.GetItemsOnBasketByMemberId(uye.UyeId);

                sepet = SepetManager.Sepettekiler(sepettekiler);
                return View(sepet);

            }
            else
            {
                var sepet = (SepetSession)Session["cart"];
                if (sepet == null)
                {
                    sepet = new SepetSession();
                    Session["cart"] = sepet;
                }
                return View(sepet);
            }
            
        }




        public ActionResult AddToCart(int productId)
        {
            var sepet = new SepetSession();

            Urun urun = manager.GetProductById(productId);

            if (Session["UyeGirdi"] != null)
            {
                MemberLoginModel uye = (MemberLoginModel)Session["UyeGirdi"];
                
                SepettekiUrunler s = new SepettekiUrunler();
                
                s.UrunId = productId;
                s.Miktar=1;
                SepetManager.AddBasket(s,uye.UyeId);

                List<SepettekiUrunler> sepettekiler = SepetManager.GetItemsOnBasketByMemberId(uye.UyeId);

                sepet = SepetManager.Sepettekiler(sepettekiler);
                return View("Index", sepet);
            }
            else 
            {
                sepet = (SepetSession)Session["cart"];
                if (sepet == null)
                {
                    sepet = new SepetSession();
                    Session["cart"] = sepet;
                }
                sepet.AddToCart(urun, 1);
            }
            
            return View("Index",sepet);
        }

        public ActionResult RemoveItem(int productId)
        {
            var sepet = (SepetSession)Session["cart"];
            if (Session["UyeGirdi"] != null)
            { 
                MemberLoginModel uye = (MemberLoginModel)Session["UyeGirdi"];
                SepetManager.RemoveItem(uye.UyeId, productId);

                List<SepettekiUrunler> sepettekiler = SepetManager.GetItemsOnBasketByMemberId(uye.UyeId);
                sepet = SepetManager.Sepettekiler(sepettekiler);
            }
            else
            {
                sepet.RemoveItem(productId);
            }
            return View("Index", sepet);
        }

        [HttpPost]
        public ActionResult Payment(decimal geneltoplam)
        {
            if (Session["UyeGirdi"] != null)
            {
                ViewBag.geneltoplam = geneltoplam;
                return View();
            }
            else
            {
                return Redirect("/Uyelik/Login");
            }

        }

        public ActionResult DoPayment()
        {
            if (Session["UyeGirdi"] != null)
            {
                MemberLoginModel uye = (MemberLoginModel)Session["UyeGirdi"];
                SepetManager.ClearBasket(uye.UyeId);
                return View();
            }
            else return Redirect("/Uyelik/Login");
            
            
        }



	}
}