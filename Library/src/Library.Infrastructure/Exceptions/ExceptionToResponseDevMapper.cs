﻿using System.Net;
using Library.Core.Exceptions;

namespace Library.Infrastructure.Exceptions;
public class ExceptionToResponseDeveloperMapper : IExceptionToResponseDeveloperMapper
{
    public ExceptionResponse Map(Exception exception)
    {
        return exception switch
        {
            NotFoundException => new ExceptionResponse(
                HttpStatusCode.NotFound,
                new
                {
                    exception.Message,
                    exception.StackTrace
                }),
            AlreadyExistsException ex => new ExceptionResponse(
                HttpStatusCode.Conflict,
                new
                {
                    ex.Details,
                    ex.Message,
                    ex.StackTrace
                }),
            ValidationException ex => new ExceptionResponse(
                HttpStatusCode.BadRequest,
                new
                {
                    ex.Message,
                    Errors = ex.Failures
                        .Select(e => new
                        {
                            e.PropertyName,
                            e.ErrorMessage
                        })
                        .ToList(),
                    exception.StackTrace
                }),
            RuleValidationException ex => new ExceptionResponse(
                HttpStatusCode.BadRequest,
                new
                {
                    ex.Message,
                    Errors = ex.Failures,
                    exception.StackTrace
                }),
            _ => new ExceptionResponse(
                ExceptionStatusCodes.InternalServerError,
                new
                {
                    exception.Message,
                    exception.StackTrace
                })
        };
    }
}
