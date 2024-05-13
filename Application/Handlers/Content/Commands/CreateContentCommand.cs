using Microsoft.AspNetCore.Http;

namespace Application.Handlers.Content.Commands;

public class CreateContentCommand
{
    public CreateContentCommand(string description, string title, string? logo, List<string>? multimedia)
    {
        Description = description;
        Title = title;
        Logo = logo;
        Multimedia = multimedia;
    }

    public CreateContentCommand()
    {
    }

    public string Description { get;  set; }
    public string Title { get;  set; }
    public string? Logo { get;  set; }
    public List<string>? Multimedia { get; set; }
}