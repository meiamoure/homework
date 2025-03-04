namespace Library.Api.Domain.Books.Records;

public record CreateBookRequest(
    string Title,
    string Description,
    string SerialNumber);
