using Library.Core.Common;
using Library.Core.Domain.Books.Checkers;
using Library.Core.Domain.Books.Models;

namespace Library.Core.Domain.Books.Rules;
public class SerialNumberMustBeUniqueBusinessRule(
    string serialNumber, ISerialNumberMustBeUniqueChecker checker) : IBusinessRuleAsync
{
    public async Task<RuleResult> CheckAsync(CancellationToken cancellationToken = default)
    {
        var isUnique = await checker.IsUnique(serialNumber, cancellationToken);
        return Check(isUnique);
    }

    private RuleResult Check(bool isBelongs)
    {
        if (isBelongs) return RuleResult.Success();
        return RuleResult.Failed($"{nameof(Book)}'s {nameof(Book.SerialNumber)} must be unique.");
    }
}
