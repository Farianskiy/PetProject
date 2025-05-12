using CSharpFunctionalExtensions;

namespace PetFamily.Domain.ValueObjects;

public class FullName
{
    private FullName(string firstName, string lastName, string middleName)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
    }
    
    public string FirstName { get; }
    public string LastName { get; }
    public string MiddleName { get; }

    public static Result<FullName> Create(string firstName, string lastName, string middleName)
    {
        if(string.IsNullOrWhiteSpace(firstName))
            return Result.Failure<FullName>("First name cannot be empty");
        
        if(string.IsNullOrWhiteSpace(lastName))
            return Result.Failure<FullName>("Last name cannot be empty");
        
        if(string.IsNullOrWhiteSpace(middleName))
            return Result.Failure<FullName>("Middle name cannot be empty");
        
        var fullName = new FullName(firstName, lastName, middleName);
        
        return Result.Success<FullName>(fullName);
    }
}