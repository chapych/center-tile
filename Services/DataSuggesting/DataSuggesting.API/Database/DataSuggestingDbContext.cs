using DataSuggesting.API.Database.Configurations;
using DataSuggesting.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataSuggesting.API.Database;

public class DataSuggestingDbContext(DbContextOptions<DataSuggestingDbContext> options) : DbContext(options)
{
    public DbSet<DataSuggestion> DataSuggestions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DataSuggestionTypeConfiguration());
    }
}