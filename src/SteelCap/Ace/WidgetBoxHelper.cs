using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using Microsoft.AspNet.Razor.TagHelpers;

namespace SteelCap
{
    [HtmlTargetElement("sc-widget-box")]
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

            var originalContent = await output.GetChildContentAsync();
            
            widgetMain.InnerHtml.AppendHtml(originalContent.GetContent());
            bodyDiv.InnerHtml.Append(widgetMain);
            
            output.Content.Clear();
            output.Content.Append(widgetHeaderDiv);
            output.Content.Append(bodyDiv);

            base.Process(context, output);
        }

        public static TagBuilder GetHeader(string title, bool isCollapsible = false)
        {
            var widgetHeaderDiv = new TagBuilder("div");
            widgetHeaderDiv.AddCssClass("widget-header");
            var h4 = new TagBuilder("h4");
            h4.AddCssClass("widget-title");
            
            h4.InnerHtml.Append(title);

            widgetHeaderDiv.InnerHtml.Append(h4);

            if (isCollapsible)
            {
                widgetHeaderDiv.InnerHtml.Append(GetToolbar(isCollapsible));
            }

            return widgetHeaderDiv;
        }

        public static TagBuilder GetToolbar(bool isCollapsible)
        {
            var toolbar = new TagBuilder("div");
            toolbar.AddCssClass("widget-toolbar");

            if (isCollapsible)
            {
                toolbar.InnerHtml.Append(GetCollapseLink());
            }

            return toolbar;
        }

        internal static TagBuilder GetCollapseLink()
        {
            var anchor = new TagBuilder("a");
            anchor.Attributes.Add("href", "#");
            anchor.Attributes.Add("data-action", "collapse");
            anchor.InnerHtml.Append(IconHelper.Get("fa-chevron-up"));
            return anchor;
        }

    }
}
