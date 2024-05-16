using System.Text.Json.Serialization;

namespace Application.Handlers.Link.Commands
{
    public record AssociateContentToLinkCommand
    {
        [JsonIgnore]
        public string? LinkId { get; set; }
        public string ContentId { get; set; }
        public AssociateContentToLinkCommand(string contentId)
        {
            ContentId = contentId;
       
        }
    }

  
}