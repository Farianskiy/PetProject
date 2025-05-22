namespace PetFamily.Domain.ValueObjects;

public record RequisiteList
{
    public List<Requisite> Requisite { get; private set; }
}