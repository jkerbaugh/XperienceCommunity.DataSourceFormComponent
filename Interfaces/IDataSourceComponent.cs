namespace XperienceCommunity.DataSourceFormComponents
{
    internal interface IDataSourceComponent
    {
        public string DataSourceType { get; set; }

        public string TextField { get; set; }

        public string ValueField { get; set; }

        public bool SortItems { get; set; }
    }
}
