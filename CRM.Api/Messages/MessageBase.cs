namespace CRM.Api.Messages;

public class MessageBase
{
    public string TraceId { get; set; }
    public DateTime CreatedDate { get; set; }

    public MessageBase()
    {
        TraceId = Guid.NewGuid().ToString();
        CreatedDate = DateTime.UtcNow;
    }
}