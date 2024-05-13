using System.Linq.Expressions;
using Domain.Entities;
using Domain.Ports;

namespace Domain.Services;

public class ContentService
{
    private readonly IGenericRepository<Content> _contentRepository;

    public ContentService(IGenericRepository<Content> contentRepository)
    {
        _contentRepository = contentRepository;
    }

    public ContentService()
    {
    }
    public async Task CreateAsync(Content content)
    {
        await _contentRepository.AddAsync(content);
    }
    
    public async Task<IEnumerable<Content>> GetAsync(
        Expression<Func<Content, bool>> filter = null,
        Func<IQueryable<Content>, IOrderedQueryable<Content>> orderBy = null,
        bool isTracking = false,
        params Expression<Func<Content, object>>[] includeObjectProperties)
    {
        return await _contentRepository.GetAsync(filter, orderBy, isTracking, includeObjectProperties);
    }
}