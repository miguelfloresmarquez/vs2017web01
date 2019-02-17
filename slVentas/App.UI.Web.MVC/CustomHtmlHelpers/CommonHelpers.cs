using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.CustomHtmlHelpers
{
    public static class CommonHelpers
    {
        public static MvcHtmlString SemaforoStock(this HtmlHelper helper, decimal stock)
        {
            string html = "", ImgUrl = "";
            if (stock > 0)
                ImgUrl = "/Content/Images/circulo-verde.png";
            else
                ImgUrl = "/Content/Images/circulo-rojo.png";

            TagBuilder tag = new TagBuilder("Img");
            tag.Attributes.Add("src", ImgUrl);

            html = tag.ToString(TagRenderMode.SelfClosing);

            return new MvcHtmlString(html);
        }
    }
}