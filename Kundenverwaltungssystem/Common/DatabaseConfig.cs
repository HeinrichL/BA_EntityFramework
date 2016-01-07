namespace Common
{
    public static class DatabaseConfig
    {
        public const string ConnString =
            @"metadata=""res://*/1 - Implementation.KundenverwaltungModel.csdl|res://*/1 - Implementation.KundenverwaltungModel.ssdl|res://*/1 - Implementation.KundenverwaltungModel.msl"";provider=System.Data.SqlClient;provider connection string=""data source=THINKPAD\SQLSERVER2012;initial catalog=KundenverwaltungEFDesigner;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework""";
        //public const string ConnString = @"server=Thinkpad\SQLSERVER2012; Database=KundenverwaltungEFDesigner;Integrated Security=SSPI;";
        public const string ConnStringSQLite = "test.db";
    }
}