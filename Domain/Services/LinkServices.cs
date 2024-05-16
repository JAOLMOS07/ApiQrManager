using System.Linq.Expressions;
using Domain.Entities;
using Domain.Ports;

namespace Domain.Services;

public class LinkServices
{
    private readonly IGenericRepository<Link> _linkRepository;
    private readonly IGenericRepository<Content> _contentRepository;
    
    public LinkServices()
    {
    }

    public LinkServices(IGenericRepository<Link> linkRepository, IGenericRepository<Content> contentRepository)
    {
        _linkRepository = linkRepository;
        _contentRepository = contentRepository;
    }

    public async Task CreateAsync(Link link)
    {
        await _linkRepository.AddAsync(link);
    }
   public async Task AssociateContentToLinkAsync(string linkId,string contentId)
       {
           Link link = await GetLinkById(new Guid(linkId));
           Content content = await GetContentById(new Guid(contentId));
           
           link.AssociateContent(content);

           await _linkRepository.UpdateAsync(link);

       }

       private async Task<Content> GetContentById( Guid id)
       {
           var content = await _contentRepository.GetByIdAsync(id);
           _ = content ??
               throw new Exception(string.Format("Contenido no encontrado", nameof(id), id));
           return content;
       }

       public async Task<IEnumerable<Link>> GetAsync(
        Expression<Func<Link, bool>> filter = null,
        Func<IQueryable<Link>, IOrderedQueryable<Link>> orderBy = null,
        bool isTracking = false,
        params Expression<Func<Link, object>>[] includeObjectProperties)
    {
        return await _linkRepository.GetAsync(filter, orderBy, isTracking, includeObjectProperties);
    }
    
    private async Task<Link> GetLinkById(Guid id)
    {
        var link = await _linkRepository.GetByIdAsync(id);
        _ = link ??
            throw new Exception(string.Format("link no encontrado", nameof(id), id));
        return link;
    }
}