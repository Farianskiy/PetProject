using CSharpFunctionalExtensions;

namespace PetFamily.Domain.ValueObjects;

public class Address
{
    private Address(string country, string city, string street, string house)
    {
        Country = country;
        City = city;
        Street = street;
        House = house;
        
    }
    
    public string Country {get; }
    public string City {get; }
    public string Street {get; }
    public string House {get; }

    public static Result<Address> Create(string country, string city, string street, string house)
    {
        if(string.IsNullOrWhiteSpace(country))
            return Result.Failure<Address>("Country is required");
        
        if(string.IsNullOrWhiteSpace(city))
            return Result.Failure<Address>("City is required");
        
        if(string.IsNullOrWhiteSpace(street))
            return Result.Failure<Address>("Street is required");
        
        if(string.IsNullOrWhiteSpace(house))
            return Result.Failure<Address>("House is required");
        
        var address = new Address(country, city, street, house);
        
        return Result.Success<Address>(address);
    }
}