using System.Linq.Expressions;
using Application.Handlers.Link.Commands;

namespace Application.Interfaces;

public interface ILinkHandler
{
    Task CreateLinkAsync(CreateLinkCommand command);
    Task AssociateContentToLinkAsync(AssociateContentToLinkCommand command);
    Task<IEnumerable<Link>> GetLinkAsync(
        Expression<Func<Link, bool>> filter = null,
        Func<IQueryable<Link>, IOrderedQueryable<Link>> orderBy = null,
        bool isTracking = false,
        params Expression<Func<Link, object>>[] includeObjectProperties);
}