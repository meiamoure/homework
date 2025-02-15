namespace Animals.Api.Domain.Owners.Recquest;

public record CreateOwnerRequest(
    string FirstName,
    string LastName,
    string? MiddleName,
    string Email,
    string PhoneNumber);
