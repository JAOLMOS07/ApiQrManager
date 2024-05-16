using System.Linq.Expressions;
using Application.Handlers.Content.Commands;
using Application.Interfaces;
using Domain.Services;

namespace Application.Handlers.Content;

public class ContentHandler:IContentHandler
{
    private readonly ContentService _contentService;
    private List<string>? MultimediaUrl { get; set; }
    public ContentHandler(ContentService contentService)
    {
        _contentService = contentService;
    }
    public async Task CreateContentAsync(CreateContentCommand command)
    {
        Guid id = new Guid();

        if (command.Multimedia != null)
        {
            MultimediaUrl = new List<string>();
            MultimediaUrl.Add("img.com/example");
        }

        Domain.Entities.Content content = MapCommandToEntity(command, id, command.Multimedia);
        await _contentService.CreateAsync(content);
      
    }
    public async Task<IEnumerable<Domain.Entities.Content>> GetContentAsync(
        Expression<Func<Domain.Entities.Content, bool>> filter = null,
        Func<IQueryable<Domain.Entities.Content>, IOrderedQueryable<Domain.Entities.Content>> orderBy = null,
        bool isTracking = false,
        params Expression<Func<Domain.Entities.Content, object>>[] includeObjectProperties)
    {
        return await _contentService.GetAsync(filter, orderBy, isTracking, includeObjectProperties);
    }
    private Domain.Entities.Content MapCommandToEntity(CreateContentCommand command, Guid id, List<string>? multimediaUrls)
    {
        return new Domain.Entities.Content(id, command.Description, command.Title,command.Logo,multimediaUrls);
    }
}