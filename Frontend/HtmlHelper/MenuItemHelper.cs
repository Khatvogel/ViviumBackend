using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Frontend.HtmlHelper
{
    public static class MenuItemHelper
    {
        public static string IsSelected(this IHtmlHelper htmlHelper, string area, string cssClass = "active")
        {

            var currentArea = htmlHelper.ViewContext.RouteData.Values["area"] as string;

            if (currentArea == null) return string.Empty;

            IEnumerable<string> acceptedActions = (area ?? currentArea).Split(',');

            return acceptedActions.Contains(currentArea) ? cssClass : string.Empty;
        }
    }

}