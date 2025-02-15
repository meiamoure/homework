namespace Animals.Api.Domain.Owners.Record;

public record UpdateOwnerRequest(
string FirstName,
string LastName,
string? MiddleName,
string Email,
string PhoneNumber);
