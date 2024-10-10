namespace Common;

public class AppSettings
{
    public static ConnectionString ConnectionStrings { get; set; }
    
    public static ServiceBus ServiceBus { get; set; }

    public static CrmApi CrmApi { get; set; }
}


public class ConnectionString
{
    public string EsoftCRM { get; set; }
}

public class ServiceBus
{
    public string ConnectionString { get; set; }
}

public class CrmApi
{
    public string PIMUrl { get; set; }
}