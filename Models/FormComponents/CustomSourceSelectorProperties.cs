using Kentico.Forms.Web.Mvc;
using XperienceCommunity.CustomSourceFormComponents.Interfaces;

using static XperienceCommunity.CustomSourceFormComponents.Models.Contants.TooltipConstants;

namespace XperienceCommunity.CustomSourceFormComponents
{
    public class CustomSourceSelectorProperties : SelectorProperties, IDataSourceComponent
    {
        [EditingComponent(RadioButtonsComponent.IDENTIFIER,
            Label = "Type",
            DefaultValue = "List", Order = 2, Tooltip = DATA_SOURCE_TIP)]
        [EditingComponentProperty(nameof(DataSource), TypesConstant.TYPE_SOURCE)]
        public string DataSourceType { get; set; } = "List";

        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Text Field", Order = 3, Tooltip = ITEM_FORMAT_TIP)]
        [VisibilityCondition(nameof(DataSourceType), ComparisonTypeEnum.IsNotEqualTo, "List")]
        public string TextField { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Value Field", Order = 4, Tooltip = VALUE_FORMAT_TIP)]
        [VisibilityCondition(nameof(DataSourceType), ComparisonTypeEnum.IsNotEqualTo, "List")]
        public string ValueField { get; set; }

        [EditingComponent(CheckBoxComponent.IDENTIFIER, Label = "Sort Items", Order = 5, Tooltip = ALLOW_SORT_TIP)]
        public bool SortItems { get; set; }
    }
}
