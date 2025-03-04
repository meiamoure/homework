using Library.Core.Common;
using Library.Core.Domain.Books.Common;
using MediatR;

namespace Library.Application.Domain.Books.Commands.DeleteBook;
public class DeleteBookCommandHandler(
    IBookRepository bookRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteBookCommand>
{
    public async Task Handle(DeleteBookCommand command, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetById(command.Id, cancellationToken);
        bookRepository.Delete(book);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
