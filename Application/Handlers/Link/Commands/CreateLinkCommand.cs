using Domain.Enums;

namespace Application.Handlers.Link.Commands;

public class CreateLinkCommand
{
    public CreateLinkCommand()
    {
    }

    public CreateLinkCommand( SubscriptionType subscriptionType)
    {
      
        SubscriptionType = subscriptionType;
     
    }

 
    public SubscriptionType SubscriptionType { get;  set; }
   
}