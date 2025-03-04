using Library.Core.Common;
using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Books.Common;
using MediatR;

namespace Library.Application.Domain.Books.Commands.AssignAuthor;
public class AssignAuthorCommandHandler(
    IAuthorsRepository authorsRepository, IBookRepository bookRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<AssignAuthorCommand>
{
    public async Task Handle(AssignAuthorCommand command, CancellationToken cancellationToken)
    {
        var author = await bookRepository.GetById(command.AuthorId, cancellationToken);
        var book = await authorsRepository.GetAuthorById(command.BookId, cancellationToken);
        author.AssignAuthor(book);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
