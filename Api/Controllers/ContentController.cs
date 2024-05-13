using Application;
using Application.Handlers.Content.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[ApiController]

[Route("[controller]")]
public class ContentController: ControllerBase
{
    private readonly IContentHandler _contentHandler;

    public ContentController(IContentHandler contentHandler)
    {
        _contentHandler = contentHandler;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateContent( CreateContentCommand command)
    {
        await _contentHandler.CreateContentAsync(command);
        return Accepted();
    }
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllContents()
    {
        var contents = await _contentHandler.GetContentAsync();
        return Ok(contents);
    }
}