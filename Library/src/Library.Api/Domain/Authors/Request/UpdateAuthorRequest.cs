namespace Library.Api.Domain.Authors.Request;

public record UpdateAuthorRequest(
    string FirstName,
    string LastName);
