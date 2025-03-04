namespace Library.Application.Domain.Authors.Queries.GetAuthors;
public record AuthorDtoQuery(
    Guid Id,
    string FirstName,
    string LastName);
