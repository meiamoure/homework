using System.Net;

namespace Library.Infrastructure.Exceptions;
public record ExceptionResponse(HttpStatusCode StatusCode, object Data);
