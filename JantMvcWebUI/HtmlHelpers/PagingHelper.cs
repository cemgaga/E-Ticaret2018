using JantMvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace JantMvcWebUI.HtmlHelpers
{
    public static class PagingHelper
    {
        public static MvcHtmlString Pager(this HtmlHelper html, PagingInfo info)
        {
            StringBuilder pagerString = new StringBuilder();
            for (int i = 1; i <= (int)Math.Ceiling((decimal)info.totalItems / info.itemsPerPage); i++)
            {
                var tagBuilder = new TagBuilder("a");
                tagBuilder.MergeAttribute("href", String.Format("/Home/Index/?page={0}", i));
                tagBuilder.InnerHtml = i.ToString() + " ";
                pagerString.Append(tagBuilder);
            }
            return MvcHtmlString.Create(pagerString.ToString());

        }
    }
}