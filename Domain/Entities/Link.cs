using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities;

public class Link: EntityBase<Guid>
{
    public Link()
    {
    }

    public Link(Guid id, DateTime lastRenewalDate, SubscriptionType subscriptionType)
    {
        Id = id;
        LastRenewalDate = lastRenewalDate;
        SubscriptionType = subscriptionType;
        Active = true;
    }

    public Guid? ContentId { get;  set; }
    public string? ContentTitle { get;  set; }
    public DateTime LastRenewalDate { get;  set; }
    public SubscriptionType SubscriptionType { get;  set; }
    public bool Active { get;  set; }
    
    public void AssociateContent(Content content)
    {
        ContentId = content.Id;
        ContentTitle = content.Title;
    }

    public void SetActiveLink(bool active)
    {
        Active = active;
    }
}