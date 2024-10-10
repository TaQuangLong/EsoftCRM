namespace Common;

public class AppSettings
{
    public static ConnectionString ConnectionStrings { get; set; }
    
    public static ServiceBusConnection ServiceBusConnection { get; set; }

    public static CrmApi CrmApi { get; set; }
}


public class ConnectionString
{
    public string EsoftCRM { get; set; }
}

public class ServiceBusConnection
{
    public string ServiceBus { get; set; }
}

public class CrmApi
{
    public string PIMUrl { get; set; }
}