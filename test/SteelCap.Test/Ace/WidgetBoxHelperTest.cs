using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Rendering;
using Xunit;

namespace SteelCap.Test
{
    public class WidgetBoxHelperTest
    {
        [Fact]
        public void ToolBarHtml()
        {
            var toolbarTag = WidgetBoxHelper.GetToolbar(true);
            var html = toolbarTag.ToString(TagRenderMode.Normal);

            
        }
    }
}
