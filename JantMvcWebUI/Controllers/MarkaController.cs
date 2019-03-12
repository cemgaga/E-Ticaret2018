using Jant.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jant.Entities;
using Jant.Dal.Concrete.EntityFramework;

namespace JantMvcWebUI.Controllers
{
    public class MarkaController : Controller
    {
        private MarkaManager manager = new MarkaManager(new EfMarkaDal());

        public PartialViewResult GetAllMarka()
        {
            return PartialView(manager.GetAll());
        }


	}
}