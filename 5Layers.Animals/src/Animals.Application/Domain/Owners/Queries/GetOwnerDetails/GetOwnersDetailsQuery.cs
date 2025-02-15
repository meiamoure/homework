using MediatR;

namespace Animals.Application.Domain.Owners.Queries.GetOwnerDetails;

public record GetOwnersDetailsQuery(Guid Id) : IRequest<OwnerDtoDetails>;

