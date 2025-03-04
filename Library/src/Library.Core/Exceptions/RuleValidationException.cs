namespace Library.Core.Exceptions;
public class RuleValidationException(IEnumerable<string> failures) : DomainException("Validation failed.")
{
    public IReadOnlyCollection<string> Failures { get; } = failures.ToList().AsReadOnly();
}

