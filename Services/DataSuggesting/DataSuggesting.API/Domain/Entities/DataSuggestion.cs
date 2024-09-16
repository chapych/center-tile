using DataSuggesting.API.Domain.Enumerations;
using DataSuggesting.API.Domain.SeedWork;
using DataSuggesting.API.Domain.ValueObjects;

namespace DataSuggesting.API.Domain.Entities;

public class DataSuggestion : Entity<Guid>
{
    public Email Email { get; init; }
    public Comment Comment { get; init; }
    public Data Data { get; init; }

    public DataSuggestion(Email email, 
        Comment comment, 
        IEnumerable<Coordinate> coordinates, 
        Material material) : this()
    {
        Email = email;
        Comment = comment;

        Data = new Data(coordinates, material);
    }

    /// <summary>
    /// EF Core constructor
    /// </summary>
    private DataSuggestion()
    { }
}