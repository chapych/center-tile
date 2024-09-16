using System.Runtime.CompilerServices;
using DataSuggesting.API.Domain.SeedWork;

namespace DataSuggesting.API.Domain.Enumerations;

public class Material : Enumeration
{
    public static Material Tile = new(1);
    public static Material Asphalt = new(2);
    public static Material Paving = new(3);

    private Material(int id, [CallerMemberName] string name = null) : base(id, name)
    {
    }
}