using _5Layers.Animals.Persistence.EFCore.AnimalsDb;
using Animals.Application.Common;
using Animals.Application.Domain.Owners.Queries.GetOwners;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Animals.Infrastructure.Application.Domain.Owners.Queries.GetOwners;

public class GetOwnersQueryHandler(AnimalsDbContext dbContext) : IRequestHandler<GetOwnersQuery, PageResponse<OwnerDtoQuery[]>>
{
    public async Task<PageResponse<OwnerDtoQuery[]>> Handle(
        GetOwnersQuery query, CancellationToken cancellationToken)
    {

        var skip = query.PageSize * (query.Page - 1);

        var sqlQuery = dbContext.Owners
           .AsNoTracking()
           .OrderBy(o => o.LastName);
        var count = await sqlQuery.CountAsync(cancellationToken);

        var owners = await sqlQuery
            .OrderBy(o => o.LastName) 
            .Skip(skip)
            .Take(query.PageSize)
            .Select(o => new OwnerDtoQuery(
                o.Id,
                o.FirstName,
                o.LastName,
                o.MiddleName,
                o.Email,
                o.PhoneNumber
            ))
            .ToArrayAsync(cancellationToken);

        return new PageResponse<OwnerDtoQuery[]>(count, owners);
    }
}
