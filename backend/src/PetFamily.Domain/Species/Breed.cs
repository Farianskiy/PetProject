using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species;

public class Breed
{
    private Breed(BreedId breedId, string name)
    {
        Id = breedId;
        Name = name;
    }
    
    public BreedId Id { get; private set; }
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
}