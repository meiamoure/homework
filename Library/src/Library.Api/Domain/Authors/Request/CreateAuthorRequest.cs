namespace Library.Api.Domain.Authors.Request;

public record CreateAuthorRequest(
    string FirstName,
    string LastName);
