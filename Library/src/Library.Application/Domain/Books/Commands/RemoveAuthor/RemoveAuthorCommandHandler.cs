using Library.Core.Common;
using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Books.Common;
using MediatR;

namespace Library.Application.Domain.Books.Commands.RemoveAuthor;
public class RemoveAuthorCommandHandler(IAuthorsRepository authorsRepository,
    IBookRepository bookRepository, IUnitOfWork unitOfWork) : IRequestHandler<RemoveAuthorCommand>
{
    public async Task Handle(RemoveAuthorCommand command, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetById(command.BookId, cancellationToken) ?? throw new Exception("Book not found");
        var author = await authorsRepository.GetAuthorById(command.AuthorId, cancellationToken) ?? throw new Exception("Author not found");
        book.RemoveAuthor(author);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
