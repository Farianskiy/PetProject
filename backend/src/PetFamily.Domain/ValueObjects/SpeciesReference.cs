using CSharpFunctionalExtensions;
using PetFamily.Domain.Species;

namespace PetFamily.Domain.ValueObjects;

public class SpeciesReference
{
    private SpeciesReference(BreedId breedId, SpeciesId speciesId)
    {
        BreedId = breedId;
        SpeciesId = speciesId;
    }
    public BreedId BreedId { get; }
    public SpeciesId SpeciesId { get; }

    public static Result<SpeciesReference> Create(BreedId breedId, SpeciesId speciesId)
    {
        if (breedId is null || breedId.Value == Guid.Empty)
            return Result.Failure<SpeciesReference>("Invalid SpeciesId");
        
        if (speciesId is null || speciesId.Value == Guid.Empty)
            return Result.Failure<SpeciesReference>("Invalid SpeciesId");
        
        var speciesReference = new SpeciesReference(breedId, speciesId);
        
        return Result.Success<SpeciesReference>(speciesReference);
    }
    
}