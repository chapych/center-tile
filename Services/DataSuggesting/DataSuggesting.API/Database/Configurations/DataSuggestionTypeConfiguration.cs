using DataSuggesting.API.Domain.Entities;
using DataSuggesting.API.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataSuggesting.API.Database.Configurations;

public class DataSuggestionTypeConfiguration : IEntityTypeConfiguration<DataSuggestion>
{
    public void Configure(EntityTypeBuilder<DataSuggestion> builder)
    {
        builder.OwnsOne(ds => ds.Comment);
        
        builder.OwnsOne(ds => ds.Email);
        
        builder.OwnsOne(ds => ds.Data, ownedNavigationBuilder =>
        {
            ownedNavigationBuilder.OwnsOne(d => d.Material);
            ownedNavigationBuilder.OwnsMany(d => d.Coordinates);
        });
        builder.Navigation(ds => ds.Email).IsRequired();
        
        builder.Navigation(ds => ds.Comment).IsRequired();

        builder.Navigation(ds => ds.Data).IsRequired();
    }
}