namespace Common.Config;

public class DomainException : Exception
{
    public DomainException(string message) : base(message)
    {
        Code = "";
    }
    
    public DomainException(string code, string message) : base(message)
    {
        Code = code;
    }

    public DomainException(string message, Exception? innerException) : base(message, innerException)
    {

    }
    
    public DomainException(string code, string message, Exception? innerException) : base(message, innerException)
    {
        Code = code;
    }

    public string Code { get; }
}