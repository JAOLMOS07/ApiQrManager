using System.Linq.Expressions;
using Application.Handlers.Content.Commands;

namespace Application.Interfaces;

public interface IContentHandler
{
    Task CreateContentAsync(CreateContentCommand command);

    Task<IEnumerable<Content>> GetContentAsync(
        Expression<Func<Content, bool>> filter = null,
        Func<IQueryable<Content>, IOrderedQueryable<Content>> orderBy = null,
        bool isTracking = false,
        params Expression<Func<Content, object>>[] includeObjectProperties);
}