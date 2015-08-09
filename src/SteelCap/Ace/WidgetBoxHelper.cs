using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace SteelCap
{
    [TargetElement("sc-widget-box")]
    public class WidgetBoxHelper : TagHelper
    {
        public string Title { get; set; }

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes["class"] = "widget-box";

            var widgetHeaderDiv = new TagBuilder("div");
            widgetHeaderDiv.AddCssClass("widget-header");
            var h4 = new TagBuilder("h4");
            h4.AddCssClass("widget-title");
            h4.SetInnerText(Title);

            widgetHeaderDiv.InnerHtml += h4;

            var bodyDiv = new TagBuilder("div");
            bodyDiv.AddCssClass("widget-body");

            var widgetMain = new TagBuilder("div");
            widgetMain.AddCssClass("widget-main");

            var originalContent = await context.GetChildContentAsync();

            widgetMain.InnerHtml = originalContent.GetContent();
            bodyDiv.InnerHtml = widgetMain.ToHtmlString(TagRenderMode.Normal).ToString();

            var finalHtml = widgetHeaderDiv.ToHtmlString(TagRenderMode.Normal).ToString()
                            + bodyDiv.ToHtmlString(TagRenderMode.Normal).ToString();

            output.Content.SetContent(finalHtml);

            base.Process(context, output);
        }
    }
}
