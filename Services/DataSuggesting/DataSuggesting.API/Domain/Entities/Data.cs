using DataSuggesting.API.Domain.Enumerations;
using DataSuggesting.API.Domain.SeedWork;
using DataSuggesting.API.Domain.ValueObjects;

namespace DataSuggesting.API.Domain.Entities;

public class Data : ValueObject<Data>
{
    private readonly List<Coordinate> _coordinates;
    public IEnumerable<Coordinate> Coordinates => _coordinates.AsReadOnly();
    public Material Material { get; init; }

    public Data(IEnumerable<Coordinate> coordinates, 
        Material material) : this()
    {
        _coordinates = coordinates.ToList();
        Material = material;
    }

    /// <summary>
    /// EF Core constructor
    /// </summary>
    private Data()
    { }

    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
    {
        return [_coordinates, Material];
    }
}