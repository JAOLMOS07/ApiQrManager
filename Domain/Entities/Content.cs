using Domain.Entities.Base;

namespace Domain.Entities;

public class Content: EntityBase<Guid>
{
    public Content(Guid id,string description, string title, string? logoUrl, List<string>? multimedia)
    {
        Id = id;
        Description = description;
        Title = title;
        LogoUrl = logoUrl;
        Multimedia = multimedia;
    }

    public Content()
    {
    }

    public string Description { get; set; }
    public string Title { get; set; }
    public string? LogoUrl { get; set; }
    public List<string>? Multimedia { get; set; }
}