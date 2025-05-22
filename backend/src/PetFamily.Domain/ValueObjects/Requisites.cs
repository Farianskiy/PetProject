using CSharpFunctionalExtensions;

namespace PetFamily.Domain.ValueObjects;

public class Requisite
{
    private Requisite(string name, string description)
    {
            Name = name;
            Description = description;
    }
    
    public string Name { get; }
    public string Description { get; }

    public static Result<Requisite> Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Requisite>("Name cannot be empty");
        
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<Requisite>("Description cannot be empty");
        
        var requisites = new Requisite(name, description);
        
        return Result.Success<Requisite>(requisites);
    }
}