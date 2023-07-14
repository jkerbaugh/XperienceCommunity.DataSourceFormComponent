using CMS;
using Kentico.Forms.Web.Mvc;
using XperienceCommunity.CustomSourceFormComponents;

[assembly: AssemblyDiscoverable]

[assembly: RegisterFormComponent(
    CustomSourceDropDownComponent.IDENTIFIER,
    typeof(CustomSourceDropDownComponent),
    "Drop-down list w/DataSource",
    IsAvailableInFormBuilderEditor = true,
    ViewName = "~/FormComponents/CustomSourceDropDown/_CustomSourceDropDown.cshtml",
    IconClass = "icon-menu"
)]

[assembly: RegisterFormComponent(
    CustomSourceRadioButtonComponent.IDENTIFIER,
    typeof(CustomSourceRadioButtonComponent),
    "Radio buttons w/DataSource",
    IsAvailableInFormBuilderEditor = true,
    ViewName = "~/FormComponents/CustomSourceRadioButton/_CustomSourceRadioButton.cshtml",
    IconClass = "icon-list"
)]

[assembly: RegisterFormComponent(
    CustomSourceMultipleChoiceComponent.IDENTIFIER,
    typeof(CustomSourceMultipleChoiceComponent),
    "Multiple choice w/DataSource",
    IsAvailableInFormBuilderEditor = true,
    ViewName = "~/FormComponents/CustomSourceMultipleChoice/_CustomSourceMultipleChoice.cshtml",
    IconClass = "icon-list"
)]