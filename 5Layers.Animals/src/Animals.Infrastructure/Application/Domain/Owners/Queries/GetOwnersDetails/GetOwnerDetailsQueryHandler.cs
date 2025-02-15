using _5Layers.Animals.Persistence.EFCore.AnimalsDb;
using Animals.Application.Domain.Owners.Queries.GetOwnerDetails;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Animals.Infrastructure.Application.Domain.Owners.Queries.GetOwnersDetails;

public class GetOwnerDetailsQueryHandler(AnimalsDbContext dbContext)
    : IRequestHandler<GetOwnersDetailsQuery, OwnerDtoDetails>
{
    public async Task<OwnerDtoDetails> Handle(
        GetOwnersDetailsQuery query,
        CancellationToken cancellationToken)
    {
        var owner = await dbContext
                   .Owners
                   .AsNoTracking()
                   .FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken)
               ?? throw new ArgumentException($"Owner with id: {query.Id} was not found.", nameof(query.Id));

        return new OwnerDtoDetails(
            owner.Id,
            owner.FirstName,
            owner.LastName,
            owner.MiddleName,
            owner.Email,
            owner.PhoneNumber);
    }
}
