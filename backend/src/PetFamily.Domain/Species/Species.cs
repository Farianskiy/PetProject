using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species;

public class Species
{
    private readonly List<Breed> _breeds = [];
    
    private Species(SpeciesId id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public SpeciesId Id { get; private set; }
    public string Name { get; private set; }
    public IReadOnlyList<Breed> Breeds => _breeds;

    public static Result<Species> Create(SpeciesId id, string name)
    {
        if(string.IsNullOrEmpty(name))
            return Result.Failure<Species>("Species name cannot be null or empty.");
        
        var species = new Species(id, name);

        return Result.Success<Species>(species);
    }
}

public record SpeciesId
{
    private SpeciesId(Guid value)
    {
        Value = value;
    }
    
    public Guid Value { get; }
    
    public static SpeciesId NewSpeciesId() => new(Guid.NewGuid());
    
    public static SpeciesId NewEmpty() => new(Guid.Empty);
}