namespace Library.Application.Domain.Books.Queries.GetBookDetails;
public record BookDetailsDto(
    Guid Id,
    string Title,
    string Description,
    string SerialNumber);
