using Domain.Enums;

namespace Application.Handlers.Link.Commands;

public class CreateLinkCommand
{
    public CreateLinkCommand()
    {
    }

    public CreateLinkCommand(DateTime lastRenewalDate, SubscriptionType subscriptionType)
    {
        LastRenewalDate = lastRenewalDate;
        SubscriptionType = subscriptionType;
     
    }

    public DateTime LastRenewalDate { get;  set; }
    public SubscriptionType SubscriptionType { get;  set; }
   
}