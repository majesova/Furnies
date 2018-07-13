using BitEng.Security.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BitEng.Security.Helpers
{
    public static class MenuHelper
    {
        /// <summary>
        /// Crea un menú boostrap
        /// </summary>
        /// <param name="html">Para extender</param>
        /// <param name="items">Elementos del menú</param>
        /// <returns>Html</returns>
        public static HtmlString BoostrapMenu(this HtmlHelper html, ICollection<BitMenuItem> items)
        {
            var request = HttpContext.Current.Request;

            UrlHelper urlHelper = new UrlHelper(html.ViewContext.RequestContext);

            var sb = new StringBuilder();
            if (items.Count == 0) return new HtmlString(string.Empty);

            foreach (var menuItem in items)
            {
                var nodeString = CreateNode(menuItem, request, urlHelper);
                sb.Append(nodeString);
            }
            return new HtmlString(sb.ToString());
        }
        /// <summary>
        /// Crea un nodo del menú
        /// </summary>
        /// <param name="item">Item del menú</param>
        /// <param name="request">Solicitud actual</param>
        /// <param name="urlHelper">Helper para url</param>
        /// <returns>html en string</returns>
        internal static string CreateNode(BitMenuItem item, HttpRequest request, UrlHelper urlHelper)
        {

            var sb = new StringBuilder();
            if (item.Children == null)
            {
                item.Children = new List<BitMenuItem>();
            }
            item.Children = item.Children.OrderBy(x => x.Order).ToList();
            if (item.Children.Count == 0)
            {
                //Nodo simple
                var serverPath = urlHelper.Content($"~/{item.PathToResource}");
                var nodeString = $"<li><a href=\"{serverPath}\">{item.Name}</a></li>";
                sb.Append(nodeString);
            }
            else
            {
                sb.Append("<li class= \"dropdown\">");
                var serverPath = urlHelper.Content($"~/{item.PathToResource}");
                sb.Append($"<a href=\"{serverPath}\" class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">{item.Name}<span class=\"caret\"></span></a>");
                sb.Append("<ul class=\"dropdown-menu\">");
                foreach (var child in item.Children)
                {
                    serverPath = urlHelper.Content($"~/{child.PathToResource}");
                    var nodeString = CreateNode(child, request, urlHelper);
                    sb.Append(nodeString);
                }
                sb.Append("</ul>");
                sb.Append("</li>");
            }

            return sb.ToString();
        }




    }
}
