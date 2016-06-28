using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SteelCap.Extensions;
using Xunit;

namespace SteelCap.Test
{
    public class WidgetBoxHelperTest
    {

        [Fact]
        public void ToolBarHtml()
        {
            var toolbarTag = WidgetBoxHeaderHelper.GetToolbar(true);
            var html = toolbarTag.ToHtml();

            Assert.Equal("<div class=\"widget-toolbar\"><a data-action=\"collapse\" href=\"#\"><i class=\"fa-chevron-up\"></i></a></div>", html);
        }
    }
}
