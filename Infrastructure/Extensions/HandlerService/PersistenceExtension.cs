
using Application;
using Application.Handlers.Content;
using Application.Handlers.Link;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions.HandlerService;

public static class DomainExtensions {
    public static IServiceCollection AddHandlerServices(this IServiceCollection svc) {
      
        svc.AddTransient(typeof(IContentHandler),typeof(ContentHandler));
        svc.AddTransient(typeof(ILinkHandler),typeof(LinkHandler));

        return svc;
    }
}