using Animals.Application.Domain.Animals.Queries.GetAnimals;

namespace Animals.Application.Domain.Owners.Queries.GetOwnerDetails;

public record OwnerDtoDetails(
    Guid Id,
    string FirstName,
    string LastName,
    string? MiddleName,
    string Email,
    string PhoneNumber);
