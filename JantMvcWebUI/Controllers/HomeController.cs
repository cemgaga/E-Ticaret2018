using Jant.Bll;
using Jant.Dal.Concrete.EntityFramework;
using Jant.Entities;
using JantMvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace JantMvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private UrunManager manager = new UrunManager(new EfUrunDal());

        public ActionResult Index(int page = 1)
        {
            List<Urun> Products = manager.GetAll();
            return View(Products.ToPagedList(page, 9));
            //List<Urun> Products = manager.GetAll();
            //return View(new ProductViewModel
            //                    {
            //                        Products = Products.Skip((page - 1) * 9).Take(9).ToList(),
            //                        PagingInfo = new PagingInfo() 
            //                                     {
            //                                        currentPage=page,
            //                                        itemsPerPage=9,
            //                                        totalItems=Products.Count()
            //                                     }
            //                    });
        }
        [HttpPost]
        public ActionResult FilteredResult(FormCollection collection,  int page = 1)
        {
            if (collection["tip"]==null && collection["cap"]==null&&collection["fiyat"]==null)
            {
                return RedirectToAction("Index");
            }
            byte type = 0; byte size = 0; Int16 cost1 = 0, cost2 = 0;

            if (collection["tip"] != null) 
            {
                var ftype = collection["tip"];
                if (ftype.Equals("Alm")) type = 1;
                if (ftype.Equals("Clk")) type = 2;
                if (ftype.Equals("Sac")) type = 3;
            }

            if (collection["cap"] != null) 
            {
                var fsize = collection["cap"];
                if (fsize.Equals("13")) size = 13;
                if (fsize.Equals("14")) size = 14;
                if (fsize.Equals("15")) size = 15;
                if (fsize.Equals("16")) size = 16;
                if (fsize.Equals("17")) size = 17;
                if (fsize.Equals("18")) size = 18;
                if (fsize.Equals("19")) size = 19;
                if (fsize.Equals("22")) size = 22;
            }

            if (collection["fiyat"] != null) 
            {
                var fcost = collection["fiyat"];
                if (fcost.Equals("0-400")) { cost1 = 0; cost2 = 400; }
                if (fcost.Equals("401-800")) { cost1 = 401; cost2 = 800; }
                if (fcost.Equals("801-999")) {cost1 = 801; cost2 = 999;}
                if (fcost.Equals("1000+")){ cost1 = 1000; cost2 = 20000; }
            }
            List<Urun> Products = manager.GetFilteredResults(type, size, cost1, cost2);
            return View(Products.ToPagedList(page, 25));
        }
    }
}