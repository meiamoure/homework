namespace Library.Application.Domain.Authors.Queries.GetAuthorDetails;

public record AuthorDetailsDto(
    Guid Id,
    string FirstName,
    string LastName);

