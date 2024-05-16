using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Application.Configuration;

public class LinkConfig: IEntityTypeConfiguration<Link>
{
    public void Configure(EntityTypeBuilder<Link> builder)
    {
        builder
            .ToTable("Link", SchemaNames.Link);

        builder
            .Property(link => link.ContentId);
        builder
            .Property(link => link.ContentTitle);

        builder
            .Property(order => order.LastRenewalDate)
            .IsRequired();
        builder
            .Property(section => section.SubscriptionType)
            .HasConversion<string>()
            .HasMaxLength(20);
        builder
            .Property(section => section.Active)
            .IsRequired();
        
    }
}