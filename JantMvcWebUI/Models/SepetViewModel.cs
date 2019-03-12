using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jant.Entities;
namespace JantMvcWebUI.Models
{
    public class SepetViewModel
    {
        public SepetSession SepetSession { get; set; }

        public List<SepettekiUrunler> SepetDB { get; set; }
    }
}