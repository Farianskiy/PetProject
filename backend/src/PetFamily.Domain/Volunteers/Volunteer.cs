using CSharpFunctionalExtensions;
using PetFamily.Domain.Pets;
using PetFamily.Domain.ValueObjects;

namespace PetFamily.Domain.Volunteers;

public class Volunteer
{
    private readonly List<Pet> _ownedPets = [];
    private readonly List<SocialNetwork> _socialNetworks = [];
    private readonly List<Requisite> _requisites = [];
    private Volunteer(VolunteerId volunteerId, FullName fullName, string email, string description, int experienceYears, PhoneNumber phone)
    {
        Id = volunteerId;
        FullName = fullName;
        Email = email;
        Description = description;
        ExperienceYears = experienceYears;
        Phone = phone;
    }
    
    public VolunteerId Id { get; private set; }
    public FullName FullName { get; private set; }
    public string Email { get; private set; }
    public string Description {get; private set; }
    public int ExperienceYears { get; private set; }
    public PhoneNumber Phone { get; private set; }
    
    public int CountPetsFoundHome => _ownedPets.Count(p => p.Status == HelpStatus.FoundHome);
    
    public int CountPetsSearchingHome => _ownedPets.Count(p => p.Status == HelpStatus.SearchingHome);
    
    public int CountPetsNeedsHelp => _ownedPets.Count(p => p.Status == HelpStatus.NeedsHelp);
    
    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;
    
    public IReadOnlyList<Requisite> Requisites => _requisites;
    
    public IReadOnlyList<Pet> OwnedPets => _ownedPets;
    

    public static Result<Volunteer> Create(VolunteerId volunteerId, FullName fullName, string email, string description, int experienceYears, PhoneNumber phone)
    {
        if(string.IsNullOrWhiteSpace(email))
            return Result.Failure<Volunteer>("The email address is not filled in");
        
        if(string.IsNullOrWhiteSpace(description))
            return Result.Failure<Volunteer>("Invalid description");
        
        if(experienceYears < 0)
            return Result.Failure<Volunteer>("Invalid experience years");
        
        var volunteer = new Volunteer(volunteerId, fullName, email, description, experienceYears, phone);
        
        return Result.Success<Volunteer>(volunteer);
    }
}