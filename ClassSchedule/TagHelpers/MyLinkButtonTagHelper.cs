using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using System;

namespace ClassSchedule.TagHelpers
{
    public class MyLinkButtonTagHelper : TagHelper
    {
        private readonly LinkGenerator linkBuilder;

        public MyLinkButtonTagHelper(LinkGenerator linkGenerator)
        {
            linkBuilder = linkGenerator;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewCxt { get; set; }

        public string Action { get; set; }
        public string Controller { get; set; }
        public string Id { get; set; }
        public bool IsActive { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string actionName = Action ?? ViewCxt.RouteData.Values["action"]?.ToString();
            string controllerName = Controller ?? ViewCxt.RouteData.Values["controller"]?.ToString();

            var route = Id != null ? new { id = Id } : null;

            string url = linkBuilder.GetPathByAction(actionName, controllerName, route);

            string cssClass = IsActive ? "btn btn-dark" : "btn btn-outline-dark";

        }

    }
}
