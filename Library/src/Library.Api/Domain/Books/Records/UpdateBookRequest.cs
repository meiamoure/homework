namespace Library.Api.Domain.Books.Records;

public record UpdateBookRequest(
    string Title,
    string Description,
    string SerialNumber);
