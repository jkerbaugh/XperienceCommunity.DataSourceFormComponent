using Kentico.Forms.Web.Mvc;
using Microsoft.Azure.Search.Models;

namespace XperienceCommunity.CustomSourceFormComponents.Interfaces
{
    internal interface IDataSourceComponent
    {
        public string DataSourceType { get; set; }

        public string TextField { get; set; }

        public string ValueField { get; set; }

        public bool SortItems { get; set; }
    }
}
