using CSharpFunctionalExtensions;

namespace PetFamily.Domain.ValueObjects;

public class PhoneNumber
{
    private PhoneNumber(string number)
    {
        Number = number;
    }
    
    public string Number {get; }

    public static Result<PhoneNumber> Create(string number)
    {
        if(string.IsNullOrWhiteSpace(number))
            return Result.Failure<PhoneNumber>("Phone number is required");
        
        var phoneNumber = new PhoneNumber(number);
        
        return Result.Success<PhoneNumber>(phoneNumber);
    }
    
}