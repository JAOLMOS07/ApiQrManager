using Application.Handlers.Link.Commands;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[ApiController]

[Route("[controller]")]
public class LinkController: ControllerBase
{
    private readonly ILinkHandler _linkHandler;

    public LinkController(ILinkHandler linkHandler)
    {
        _linkHandler = linkHandler;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateLink( CreateLinkCommand command)
    {
        await _linkHandler.CreateLinkAsync(command);
        return Accepted();
    }
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllLinks()
    {
        var links = await _linkHandler.GetLinkAsync();
        return Ok(links);
    }
    [HttpPatch("{id}")]
    [AllowAnonymous]

    public async Task<IActionResult> AssociateOneContent(string id, [FromBody] AssociateContentToLinkCommand toLinkCommand)
    {
        toLinkCommand.LinkId = id;
        await _linkHandler.AssociateContentToLinkAsync(toLinkCommand);
        return Ok();
    }
}