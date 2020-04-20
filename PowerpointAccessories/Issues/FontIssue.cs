using System;
using System.Collections.Generic;
using System.Text;

namespace PowerpointAccessories.Issues
{
    public class FontIssue : IssueItem
    {
        public string FontName { get; set; }
        public string FontSupplier { get; set; }
        public FontIssue(string fontSupplier, string fontName, string Description = "empty", bool IsFixable = false, bool IsChecked = false) : base(Description, IsFixable, IsChecked)
        {
            FontName = fontName;
            FontSupplier = fontSupplier;

        }
    }
}
