
using Domain.Entities;
using Domain.Entities.Base;
using Infrastructure.Extensions.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;

namespace Infrastructure.Context.Application
{
    public class PersistenceContext : DbContext 
    {
        private readonly DatabaseSettings? _databaseSettings;

        public PersistenceContext(
            DbContextOptions<PersistenceContext> options,
            IOptions<DatabaseSettings> databaseSettings
        ) : base(options)
        {
            _databaseSettings = databaseSettings.Value ?? throw new ArgumentNullException(nameof(databaseSettings.Value));
        }

    
      

        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }

        protected override void OnModelCreating(ModelBuilder? modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }

            if (_databaseSettings != null && !string.IsNullOrEmpty(_databaseSettings?.SchemaName))
            {
                modelBuilder.HasDefaultSchema(_databaseSettings?.SchemaName ?? "DefaultText");
            }

            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                Type t = entityType.ClrType;
                if (!typeof(DomainEntity).IsAssignableFrom(t)) continue;
                modelBuilder.Entity(entityType.Name).Property<DateTime>("CreatedOn").HasDefaultValueSql("GETDATE()");
                modelBuilder.Entity(entityType.Name).Property<DateTime>("LastModifiedOn").HasDefaultValueSql("GETDATE()");
            }
            
            modelBuilder.AppendGlobalQueryFilter<ISoftDelete>(s => s.DeletedOn == null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
