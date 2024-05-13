using System.Linq.Expressions;
using Domain.Entities;
using Domain.Ports;

namespace Domain.Services;

public class LinkServices
{
    private readonly IGenericRepository<Link> _linkRepository;

    public LinkServices(IGenericRepository<Link> linkRepository)
    {
        _linkRepository = linkRepository;
    }

    public LinkServices()
    {
    }
    public async Task CreateAsync(Link link)
    {
        await _linkRepository.AddAsync(link);
    }
    
    public async Task<IEnumerable<Link>> GetAsync(
        Expression<Func<Link, bool>> filter = null,
        Func<IQueryable<Link>, IOrderedQueryable<Link>> orderBy = null,
        bool isTracking = false,
        params Expression<Func<Link, object>>[] includeObjectProperties)
    {
        return await _linkRepository.GetAsync(filter, orderBy, isTracking, includeObjectProperties);
    }
}