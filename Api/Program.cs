
using Infrastructure;
using Infrastructure.Extensions;
using Infrastructure.Extensions.Persistence;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ConfigurationManager config = builder.Configuration;

if (builder.Environment.IsEnvironment(ApiConstants.LocalEnvironment))
{
    config.AddUserSecrets<Program>();
}
else
{
    config.AddEnvironmentVariables();
}

builder.Services.AddHealthChecks();

builder.Services.AddInfrastructure(config,builder.Environment);

builder.Services.Configure<DatabaseSettings>(config.GetSection(nameof(DatabaseSettings)));
var settings = config.GetSection(nameof(DatabaseSettings)).Get<DatabaseSettings>();
builder.Services.AddHealthChecks().AddSqlServer(settings.ConnectionString);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
await app.InitializeDatabasesAsync();
app.UseInfrastructure();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();   

app.Run();