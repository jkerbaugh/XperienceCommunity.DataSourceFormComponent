using Kentico.Content.Web.Mvc;
using Kentico.Forms.Web.Mvc;
using XperienceCommunity.CustomSourceFormComponents.Interfaces;

namespace XperienceCommunity.CustomSourceFormComponents
{
    public class CustomSourceMultiSelectorProperties : MultiSelectorProperties, IDataSourceComponent
    {

        [EditingComponent(RadioButtonsComponent.IDENTIFIER,
            Label = "Type",
            DefaultValue = "List", Order = 2)]
        [EditingComponentProperty(nameof(DataSource), TypesConstant.TYPE_SOURCE)]
        public string DataSourceType { get; set; } = "List";

        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Text Field", Order = 4)]
        [VisibilityCondition(nameof(DataSourceType), ComparisonTypeEnum.IsNotEqualTo, "List")]
        public string TextField { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Value Field", Order = 5)]
        [VisibilityCondition(nameof(DataSourceType), ComparisonTypeEnum.IsNotEqualTo, "List")]
        public string ValueField { get; set; }

        [EditingComponent(CheckBoxComponent.IDENTIFIER, Label = "Sort Items", Order = 6)]
        public bool SortItems { get; set; }


    }
}
