using Kentico.Forms.Web.Mvc;

namespace XperienceCommunity.DataSourceFormComponents
{
    public class CustomSourceDropDownProperties : CustomSourceSelectorProperties
    {

        /// <summary>Gets or sets the first option label value.</summary>
        /// <remarks>
        /// Option is not displayed when null or <see cref="F:System.String.Empty" /> is set.
        /// </remarks>
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "{$kentico.formbuilder.component.dropdown.properties.optionlabel$}", Tooltip = "{$kentico.formbuilder.component.dropdown.properties.optionlabel.tooltip$}", Order = 5)]
        public string OptionLabel { get; set; }


        [EditingComponent(CheckBoxComponent.IDENTIFIER, Label = "Allow Multiple", Order = 6)]
        public bool AllowMultiple { get; set; }
    }
}
