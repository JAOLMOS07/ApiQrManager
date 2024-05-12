using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Path = System.IO.Path;

namespace Infrastructure.Extensions.OpenApi;

public static class OpenApiDocumentationExtensions {
    public static IServiceCollection AddOpenApiDocumentation(this IServiceCollection svc, IWebHostEnvironment env) {
        return svc.AddSwaggerGen(o =>
        {
           

            // Configuración para incluir el documento YAML
            o.CustomSchemaIds(type => type.FullName); // Personalización opcional del ID del esquema
            o.DescribeAllParametersInCamelCase(); // Otras configuraciones opcionales

           
            o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Por favor ingresa el token con 'Bearer ' prefijo",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });

            o.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
    }

    public static IApplicationBuilder UseOpenApiDocumentation(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Block Api"));
        return app;
    }
}

public class YamlOperationFilter : IOperationFilter
{
    private readonly string _yamlDoc;

    public YamlOperationFilter(string yamlDoc)
    {
        _yamlDoc = yamlDoc;
    }

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // Agregar manualmente la extensión del documento YAML
        operation.Extensions.Add("x-wagmp-code-gen-yaml", new OpenApiString(_yamlDoc));
    }
}