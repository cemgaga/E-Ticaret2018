using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jant.Entities;

namespace JantMvcWebUI.Models
{
    public class ProductViewModel
    {
        public List<Urun> Products { get; set; }

        public PagingInfo PagingInfo { get; set; }

    }

    public class PagingInfo 
    {
        public int totalItems;
        public int currentPage;
        public int itemsPerPage;

    }
}