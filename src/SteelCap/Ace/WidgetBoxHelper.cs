using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using SteelCap.Extensions;

namespace SteelCap
{
    [TargetElement("sc-widget-box")]
    public class WidgetBoxHelper : TagHelper
    {
        public string Title { get; set; }

        public bool IsCollapsible { get; set; }

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes["class"] = "widget-box";

            var widgetHeaderDiv = GetHeader(Title, IsCollapsible);

            var bodyDiv = new TagBuilder("div");
            bodyDiv.AddCssClass("widget-body");

            var widgetMain = new TagBuilder("div");
            widgetMain.AddCssClass("widget-main");

            var originalContent = await context.GetChildContentAsync();

            widgetMain.InnerHtml = new HtmlString(originalContent.GetContent());
            bodyDiv.InnerHtml = widgetMain;

            var finalHtml = widgetHeaderDiv.ConcatToString(bodyDiv);
                            
            output.Content.SetContent(finalHtml);

            base.Process(context, output);
        }

        public static TagBuilder GetHeader(string title, bool isCollapsible = false)
        {
            var widgetHeaderDiv = new TagBuilder("div");
            widgetHeaderDiv.AddCssClass("widget-header");
            var h4 = new TagBuilder("h4");
            h4.AddCssClass("widget-title");
            
            h4.SetInnerText(title);

            widgetHeaderDiv.InnerHtml = widgetHeaderDiv.InnerHtml.ConcatToHtmlContent(h4);

            if (isCollapsible)
            {
                widgetHeaderDiv.InnerHtml = widgetHeaderDiv.InnerHtml.ConcatToHtmlContent(GetToolbar(isCollapsible));
            }

            return widgetHeaderDiv;
        }

        public static TagBuilder GetToolbar(bool isCollapsible)
        {
            var toolbar = new TagBuilder("div");
            toolbar.AddCssClass("widget-toolbar");

            if (isCollapsible)
            {
                toolbar.InnerHtml = GetCollapseLink();
            }

            return toolbar;
        }

        internal static TagBuilder GetCollapseLink()
        {
            var anchor = new TagBuilder("a");
            anchor.Attributes.Add("href", "#");
            anchor.Attributes.Add("data-action", "collapse");
            anchor.InnerHtml = IconHelper.Get("fa-chevron-up");
            return anchor;
        }

    }
}
