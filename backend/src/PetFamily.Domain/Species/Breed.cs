using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species;

public class Breed : Shared.Entity<BreedId>
{
    private Breed(BreedId id) : base(id)
    {
        
    }
    
    private Breed(BreedId breedId, string name)
        : base(breedId)
    {
        Name = name;
    }
    
    public string Name { get; private set; }

    public static Result<Breed> Create(BreedId breedId, string name)
    {
        if(string.IsNullOrWhiteSpace(name))
            return Result.Failure<Breed>("Name cannot be empty");
        
        var breed = new Breed(breedId, name);
        
        return Result.Success<Breed>(breed);
    }
}

public record BreedId
{
    private BreedId(Guid value)
    {
        Value = value;
    }
    
    public Guid Value { get; }
    
    public static BreedId NewBreedId() => new(Guid.NewGuid());
    
    public static BreedId NewEmpty() => new(Guid.Empty);

    public static BreedId Create(Guid id) => new(id);
}