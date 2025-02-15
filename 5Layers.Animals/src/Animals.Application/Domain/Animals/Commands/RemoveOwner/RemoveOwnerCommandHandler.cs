using Animals.Core.Common;
using Animals.Core.Domain.Animals.Common;
using Animals.Core.Domain.Owners.Common;
using MediatR;

namespace Animals.Application.Domain.Animals.Commands.RemoveOwner;

public class RemoveOwnerCommandHandler(IAnimalsRepository animalsRepository,
    IOwnersRepository ownersRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<RemoveOwnerCommand>
{
    public async Task Handle(RemoveOwnerCommand command, CancellationToken cancellationToken) 
    {
        var animal = await animalsRepository.GetById(command.AnimalId, cancellationToken);
        if (animal == null)
        {
            throw new Exception("Animal not found");
        }

        var owner = await ownersRepository.GetOwnerById(command.OwnerId, cancellationToken);
        if (owner == null)
        {
            throw new Exception("Owner not found");
        }

        animal.RemoveOwner(owner);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
