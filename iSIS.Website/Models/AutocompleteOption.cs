using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web;

namespace iSIS.Website.Models
{
    public class AutocompleteOption
    {
        public AutocompleteOption()
        {
            AllowCustomTokens = true;
            ShowDropDownOnFocus = DevExpress.Web.ShowDropDownOnFocusMode.Auto;
            IncrementalFilteringMode = DevExpress.Web.IncrementalFilteringMode.Contains;
        }

        public bool AllowCustomTokens { get; set; }
        public ShowDropDownOnFocusMode ShowDropDownOnFocus { get; set; }
        public IncrementalFilteringMode IncrementalFilteringMode { get; set; }
    }
}