using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Xunit;

namespace SteelCap.Test.Bootstrap
{
    public class DropdownTagHelperTest : TestBase
    {
        [Fact]
        public void Process()
        {
            var context = GetSimpleTagHelperContext();
            var output = GetSimpleTagHelperOutput();

            var items = new List<SelectListItem>();
            items.Add(new SelectListItem {Text="Red", Value = "1"});
            items.Add(new SelectListItem { Text = "Green", Value = "2" });
            items.Add(new SelectListItem { Text = "Blue", Value = "3" });
            

            var dropdown = new Dropdown();
            dropdown.Items = items;

            dropdown.Process(context, output);

            Assert.True(output.Content.GetContent().Contains("option"));
        }
    }
}
