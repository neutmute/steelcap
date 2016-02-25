using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using Microsoft.AspNet.Razor.TagHelpers;
using SteelCap.Extensions;

namespace SteelCap
{
    /// <summary>
    /// Allow more control over how the header renders
    /// </summary>
    [HtmlTargetElement(WidgetBoxHelperElement)]
    public class WidgetBoxHeaderHelper : TagHelper
    {
        const string WidgetBoxHelperElement = "sc-widget-box-header";
        public const string HeaderCss = "widget-header";

        internal bool IsCollapsible { get; set; }

        internal string Title { get; set; }
        
        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.SuppressOutput();
            
            var originalContent = await output.GetChildContentAsync();

            var headerDiv = GetHeader();
            headerDiv.InnerHtml.AppendHtml(originalContent.GetContent());

            output.Content.Clear();
            output.Content.Append(headerDiv);

            base.Process(context, output);
        }

        private static TagBuilder GetHeader()
        {
            var widgetHeaderDiv = new TagBuilder("div");
            widgetHeaderDiv.AddCssClass(HeaderCss);
            return widgetHeaderDiv;
        }
        
        /// <summary>
        /// When not explictly created by nested taghelper, create the whole thing
        /// </summary>
        internal static TagBuilder GetFullHeader(string title, bool isCollapsible = false)
        {
            var widgetHeaderDiv = GetHeader();

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

        private static TagBuilder GetToolbar(bool isCollapsible)
        {
            var toolbar = new TagBuilder("div");
            toolbar.AddCssClass("widget-toolbar");

            if (isCollapsible)
            {
                toolbar.InnerHtml.Append(GetCollapseLink());
            }

            return toolbar;
        }

        private static TagBuilder GetCollapseLink()
        {
            var anchor = new TagBuilder("a");
            anchor.Attributes.Add("href", "#");
            anchor.Attributes.Add("data-action", "collapse");
            anchor.InnerHtml.Append(IconHelper.Get("fa-chevron-up"));
            return anchor;
        }

    }
}
