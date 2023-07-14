using System;
using System.Collections.Generic;
using System.Linq;
using Kentico.Content.Web.Mvc;
using Kentico.Web.Mvc;

namespace XperienceCommunity.DataSourceFormComponents
{
    public class CustomSourceMultiSelectorComponent<TProperties> :
        MultiSelectorFormComponent<TProperties> where TProperties : CustomSourceMultiSelectorProperties, new()
    {

        protected override IEnumerable<HtmlOptionItem> GetHtmlOptions()
        {
            var sourceType = Enum.Parse<DataSourceType>(Properties.DataSourceType);

            var options = sourceType switch
            {
                DataSourceType.SQL => DataSourceHelpers.ParseSqlQueryToOptions(Properties.DataSource, Properties.TextField, Properties.ValueField),
                DataSourceType.Macro => DataSourceHelpers.ParseMacroToOptions(Properties.DataSource, Properties.TextField, Properties.ValueField),
                _ => base.GetHtmlOptions()
            };

            if (Properties.SortItems)
                Array.Sort(options.ToArray(),
                    (field, specialField) => string.Compare(field.Text, specialField.Text, StringComparison.Ordinal));

            return options;
        }
    }
}
