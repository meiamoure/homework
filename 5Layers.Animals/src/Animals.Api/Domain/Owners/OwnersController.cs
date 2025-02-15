using Animals.Api.Constants;
using Animals.Api.Domain.Owners.Record;
using Animals.Api.Domain.Owners.Recquest;
using Animals.Application.Domain.Animals.Queries.GetAnimals;
using Animals.Application.Domain.Owners.Commands.CreateOwner;
using Animals.Application.Domain.Owners.Commands.DeleteOwner;
using Animals.Application.Domain.Owners.Commands.UpdateOwner;
using Animals.Application.Domain.Owners.Queries.GetOwnerDetails;
using Animals.Application.Domain.Owners.Queries.GetOwners;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Animals.Api.Domain.Owners;

[Route(Routes.Owners)]
public class OwnersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OwnerDto>>> GetOwners(
        [FromQuery][Required] int page = 1,
        [FromQuery][Required] int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var query = new GetOwnersQuery(page, pageSize);
        var owners = await mediator.Send(query, cancellationToken);
        return Ok(owners);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OwnerDtoDetails>> GetOwnerDetails(
        [FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var query = new GetOwnersDetailsQuery(id);
        var owner = await mediator.Send(query, cancellationToken);
        return Ok(owner);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateOwner(CreateOwnerRequest request)
    {
        var command = new CreateOwnerCommand(
            request.FirstName,
            request.LastName,
            request.MiddleName,
            request.Email,
            request.PhoneNumber);
        var ownerId = await mediator.Send(command);
        return Ok(ownerId);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateOwner(
        [FromRoute] Guid id,
        [FromBody][Required] UpdateOwnerRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = new UpdateOwnerCommand(
            id,
            request.FirstName,
            request.LastName,
            request.MiddleName,
            request.Email,
            request.PhoneNumber);
        await mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOwner(
        [FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteOwnerCommand(id);
        await mediator.Send(command, cancellationToken); 
        return Ok();
    }
}
