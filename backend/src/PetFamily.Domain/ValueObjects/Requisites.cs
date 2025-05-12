using CSharpFunctionalExtensions;

namespace PetFamily.Domain.ValueObjects;

public class Requisite
{
    private Requisite(string name, string description, string infoOfTransfer)
    {
            Name = name;
            Description = description;
            InfoOfTransfer = infoOfTransfer;
    }
    
    public string Name { get; }
    public string Description { get; }
    public string InfoOfTransfer { get; }

    public static Result<Requisite> Create(string name, string description, string infoOfTransfer)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Requisite>("Name cannot be empty");
        
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<Requisite>("Description cannot be empty");
        
        if (string.IsNullOrWhiteSpace(infoOfTransfer))
            return Result.Failure<Requisite>("InfoOfTransfer cannot be empty");
        
        var requisites = new Requisite(name, description, infoOfTransfer);
        
        return Result.Success<Requisite>(requisites);
    }
}