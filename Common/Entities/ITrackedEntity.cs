namespace CRM.Api.Model;

public interface ITrackedEntity
{
    DateTimeOffset DateCreated { get; set; }
    DateTimeOffset DateModified { get; set; }
}