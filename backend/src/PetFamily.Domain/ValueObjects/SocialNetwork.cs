using CSharpFunctionalExtensions;

namespace PetFamily.Domain.ValueObjects;

public class SocialNetwork
{
    private SocialNetwork(string name, string url)
    {
        Name = name;
        Url = url;
    }
    public string Name { get; }
    public string Url { get; }

    public static Result<SocialNetwork> Create(string name, string url)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<SocialNetwork>("Name cannot be empty");
        
        if (string.IsNullOrWhiteSpace(url))
            return Result.Failure<SocialNetwork>("Url cannot be empty");
        
        var socialNetwork = new SocialNetwork(name, url);
        
        return Result.Success<SocialNetwork>(socialNetwork);
    }
}