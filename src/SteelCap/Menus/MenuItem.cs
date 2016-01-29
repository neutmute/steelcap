using System;
using System.Collections.Generic;

namespace SteelCap
{
    public class MenuItem
    {
        #region Fields

        public const string SpecialTextDivider  = "__divider__";

        #endregion
        
        #region Properties

        public string Text {get;set;}
        public CssIcon IconCss { get; set; }
        public string AnchorTarget { get; set; }
        
        public string AnchorHref { get; set; }
        
        public List<MenuItem> Children { get; set; }

        public bool HasChildren => Children != null && Children.Count > 0;

        #endregion
        
        #region Ctor

        public MenuItem()
        {
            Children = new List<MenuItem>();
        }

        #endregion
    }
}