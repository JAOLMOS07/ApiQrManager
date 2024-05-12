using System.Text.Json;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Context.Application.Configuration;

public class ContentConfig: IEntityTypeConfiguration<Content>
{
    
    public void Configure(EntityTypeBuilder<Content> builder)
    {
        builder
            .ToTable("Content", SchemaNames.Content);
        
        builder
            .Property(content => content.Title)
            .IsRequired()
            .HasMaxLength(200);
        builder
            .Property(content => content.Description)
            .IsRequired()
            .HasMaxLength(200);
        builder
            .Property(x => x.LogoUrl)
            .HasMaxLength(250);
        builder
            .Property(x => x.Multimedia)
            .HasConversion(
                v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
                v => JsonSerializer.Deserialize<List<string>>(v, new JsonSerializerOptions()),
                new ValueComparer<List<string>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList()))
            .HasMaxLength(5000);
    }
}