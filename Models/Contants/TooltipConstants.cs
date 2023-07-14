using System;
using System.Collections.Generic;
using System.Text;

namespace XperienceCommunity.CustomSourceFormComponents.Models.Contants
{
    internal class TooltipConstants
    {
        public const string DATA_SOURCE_TIP = @"
            Selects which type of data source is used to generate the options displayed in the list control. When ""Options"" is selected, each item must be specified in the text area, one per line in format ""1;One"". When ""SQL Query"" is specified, then an SQL query must be entered. The SQL query must return a value and text column to dynamically generate the items. When a ""Macro"" source is selected, a macro expression (without macro brackets) is expected. The result of the expression should be an enumerable object whose items will fill the list control.
        ";

        public const string ALLOW_SORT_TIP = @"
            If true, the items in the list are sorted alphabetically.
        ";  

        public const string ITEM_FORMAT_TIP = @"
            Text pattern containing macro, e.g. ""{%FullName%} ({%Email%})"". Valid when the data source is query or macro.
        ";

        public const string VALUE_FORMAT_TIP = @"
            Value pattern containing a macro, e.g. ""{%UserName%}"". Valid when the data source is a query or macro.
        ";
    }
}
