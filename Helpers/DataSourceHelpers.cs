using System;
using System.Collections;
using System.Collections.Generic;
using CMS.DataEngine;
using System.Data;
using CMS.Base;
using CMS.Helpers;
using CMS.MacroEngine;
using Kentico.Web.Mvc;

namespace XperienceCommunity.CustomSourceFormComponents
{
    internal class DataSourceHelpers
    {
        internal static IEnumerable<HtmlOptionItem> ParseSqlQueryToOptions(string query, string textFormat, string valueFormat, QueryTypeEnum sqlTypeEnum = QueryTypeEnum.SQLQuery)
        {
            if (!string.IsNullOrEmpty(query))
            {
                var resolver = MacroResolver.GetInstance();

                query = resolver.ResolveMacros(query);
                var dataSource = ConnectionHelper.ExecuteQuery(query, null, sqlTypeEnum);
                if (DataHelper.DataSourceIsEmpty(dataSource)) 
                    yield break;

                foreach (DataRow row in (InternalDataCollectionBase)dataSource.Tables[0].Rows)
                {
                    var child = resolver.CreateChild();
                    child.SetAnonymousSourceData(row);
                    child.SetNamedSourceData("Item", row);

                    var value = !string.IsNullOrEmpty(valueFormat) ? child.ResolveMacros(valueFormat) : (row[0] != DBNull.Value ? ValidationHelper.GetString(row[0], null) : string.Empty);
                    var text = !string.IsNullOrEmpty(textFormat) ? child.ResolveMacros(textFormat) : ValidationHelper.GetString(row[1], null);
                    
                    yield return new HtmlOptionItem()
                    {
                        Value = value,
                        Text = text
                    };
                }
            }
        }

        internal static IEnumerable<HtmlOptionItem> ParseMacroToOptions(string expression, string textFormat, string valueFormat)
        {
            if (!string.IsNullOrEmpty(expression))
            {
                var resolver = MacroResolver.GetInstance();

                var flag = expression.StartsWithCSafe("{%") && expression.EndsWithCSafe("%}") && expression.Length >= 4;
                expression = MacroProcessor.RemoveDataMacroBrackets(expression);
                var evaluationResult = resolver.ResolveMacroExpression(expression, true, !flag);
                if (evaluationResult != null && evaluationResult.Result != null)
                {
                    IEnumerable enumerable;
                    if (evaluationResult.Result is IEnumerable && !(evaluationResult.Result is string))
                        enumerable = (IEnumerable)evaluationResult.Result;
                    else
                        enumerable = new ArrayList()
                        {
                            evaluationResult.Result
                        };
                    foreach (var data in enumerable)
                    {
                        var child = resolver.CreateChild();
                        child.SetAnonymousSourceData(data);
                        child.SetNamedSourceData("Item", data);

                        var option = DataToHtmlOptionItem(data.ToString());

                        if (!string.IsNullOrEmpty(valueFormat))
                            option.Value = child.ResolveMacros($@"{{%{MacroProcessor.RemoveDataMacroBrackets(valueFormat)}%}}", null);
                        if (!string.IsNullOrEmpty(textFormat))
                            option.Text = child.ResolveMacros($@"{{%{MacroProcessor.RemoveDataMacroBrackets(textFormat)}%}}", null);

                        if (!string.IsNullOrEmpty(option.Text))
                            yield return option;
                    }
                }
            }
        }


        internal static HtmlOptionItem DataToHtmlOptionItem(string line)
        {
            var strArray = line.Trim().Split(';');
            var specialField = strArray.Length <= 3
                ? new HtmlOptionItem()
                {
                    Value = strArray[0].Replace("\0\0", ";")
                }
                : throw new FormatException("The source text is in wrong format.");

            specialField.Text = strArray.Length > 1 ? strArray[1].Replace("\0\0", ";") : specialField.Value;

            return specialField;
        }
    }
}
