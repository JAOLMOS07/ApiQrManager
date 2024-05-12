using System.Data;
using Infrastructure.Adapters.Repository;
using Infrastructure.Extensions.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions.DomainService;

public static class DomainExtensions {
    public static IServiceCollection AddDomainServices(this IServiceCollection svc) {
      
        //svc.AddTransient(typeof(SectionService));
     
        return svc;
    }
}