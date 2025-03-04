using Library.Core.Common;
using Library.Core.Domain.Books.Common;
using Library.Core.Domain.Books.Data;
using MediatR;

namespace Library.Application.Domain.Books.Commands.UpdateBook;
public class UpdateBookCommandHandler(
    IBookRepository bookRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateBookCommand>
{
    public async Task Handle(
        UpdateBookCommand command, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetById(
            command.Id,
            cancellationToken);

        var data = new UpdateBookData(
            command.Title,
            command.Description,
            command.SerialNumber);
        book.Update(data);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
