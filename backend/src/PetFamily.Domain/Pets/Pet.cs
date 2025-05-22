
using CSharpFunctionalExtensions;
using PetFamily.Domain.Species;
using PetFamily.Domain.ValueObjects;

namespace PetFamily.Domain.Pets;

public class Pet : Shared.Entity<PetId>
{
    private readonly List<Requisite> _requisites = [];

    private Pet(PetId id) : base(id)
    {
        
    }
    
    private Pet(PetId petId, string name, SpeciesReference species, string allDescription, string coloring, string healthPet, Address address, int weight, int height, PhoneNumber phoneNumber, bool neuteredOrNot, DateTime birthDate,
        bool vaccinatedOrNot, HelpStatus status, DateTime createDate)
        : base(petId)
    {
        Name = name;
        Species = species;
        AllDescription = allDescription;
        Coloring = coloring;
        HealthPet = healthPet;
        AddressPet = address;
        Weight = weight;
        Height = height;
        Phone = phoneNumber;
        NeuteredOrNot = neuteredOrNot;
        BirthDate = birthDate;
        VaccinatedOrNot = vaccinatedOrNot;
        Status = status;
        CreateDate = createDate;
    }
    public string Name { get; private set; }
    public SpeciesReference Species { get; private set; }
    public string AllDescription {get; private set;}
    public string Coloring {get; private set;}
    public string HealthPet {get; private set;}
    public Address AddressPet  {get; private set;}
    public int Weight {get; private set;}
    public int Height {get; private set;}
    public PhoneNumber Phone {get; private set;}
    public bool NeuteredOrNot {get; private set;}
    public DateTime BirthDate {get; private set;}
    public bool VaccinatedOrNot {get; private set;}
    public HelpStatus Status {get; private set;}
    public RequisiteList Requisites { get; private set; }
    public DateTime CreateDate {get; private set;}

    public static Result<Pet> Create(PetId petId, string name, SpeciesReference species, string allDescription, string coloring, string healthPet, Address address, int weight, int height, PhoneNumber phoneNumber, bool neuteredOrNot, DateTime birthDate,
        bool vaccinatedOrNot, HelpStatus status, DateTime createDate)
    {
        if(string.IsNullOrWhiteSpace(name))
            return Result.Failure<Pet>("The Name field is not filled in");
        
        if(string.IsNullOrWhiteSpace(allDescription))
            return Result.Failure<Pet>("The description field is not filled in");
        
        if(string.IsNullOrWhiteSpace(coloring))
            return Result.Failure<Pet>("The coloring field is not filled in");
        
        if(string.IsNullOrWhiteSpace(healthPet))
            return Result.Failure<Pet>("The health pet field is not filled in");
        
        if(weight <= 0)
            return Result.Failure<Pet>("Invalid weight value");
        
        if(height <= 0)
            return Result.Failure<Pet>("Invalid height value");
        
        if (birthDate == default || birthDate > DateTime.UtcNow)
            return Result.Failure<Pet>("Vaccinated or not is null");
        
        var pet = new Pet(petId, name, species, allDescription, coloring, healthPet, address, weight, height, phoneNumber, neuteredOrNot, birthDate, vaccinatedOrNot, HelpStatus.NeedsHelp, DateTime.UtcNow);
        
        return Result.Success<Pet>(pet);
    }
}