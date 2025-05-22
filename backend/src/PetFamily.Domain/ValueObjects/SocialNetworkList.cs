namespace PetFamily.Domain.ValueObjects;

public record SocialNetworkList
{
    public List<SocialNetwork> SocialNetwork { get; private set; }
}