namespace Library.Core.Domain.Books.Checkers;
public interface ISerialNumberMustBeUniqueChecker
{
    Task<bool> IsUnique(string serialNumber, CancellationToken cancellationToken = default);
}
