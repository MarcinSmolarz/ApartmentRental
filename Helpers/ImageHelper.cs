using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;


namespace ApartmentRental.Helpers
{
    public static class ImageHelper
    {
            public static IHtmlContent Image(this IHtmlHelper helper, byte[] image) //MvcHtmlString
        {
                var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(image));
                return new HtmlString("<img src='" + img + "' />"); //MvcHtmlString
        }

            //public static string Label(byte[] image)
            //{
            //    var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(image));
            //    return String.Format("<img src='" + img + "' />");
            //}
    }
}
