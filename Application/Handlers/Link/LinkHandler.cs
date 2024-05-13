using System.Linq.Expressions;
using Application.Handlers.Link.Commands;
using Application.Interfaces;
using Domain.Enums;
using Domain.Services;

namespace Application.Handlers.Link;

public class LinkHandler:ILinkHandler
{
    private readonly LinkServices _linkService;

    public LinkHandler(LinkServices linkService)
    {
        _linkService = linkService;
    }

    public async Task CreateLinkAsync(CreateLinkCommand command)
    {
        Guid id = new Guid();
        Domain.Entities.Link newLink = MapCommandToEntity(command, id);
        await _linkService.CreateAsync(newLink);
    }

    public async Task<IEnumerable<Domain.Entities.Link>> GetLinkAsync(Expression<Func<Domain.Entities.Link, bool>> filter = null, Func<IQueryable<Domain.Entities.Link>, IOrderedQueryable<Domain.Entities.Link>> orderBy = null, bool isTracking = false,
        params Expression<Func<Domain.Entities.Link, object>>[] includeObjectProperties)
    {
        return await _linkService.GetAsync(filter, orderBy, isTracking, includeObjectProperties);
    }
    private Domain.Entities.Link MapCommandToEntity(CreateLinkCommand command, Guid id)
    {
        return new Domain.Entities.Link(id,command.LastRenewalDate,command.SubscriptionType);
        
    }
}