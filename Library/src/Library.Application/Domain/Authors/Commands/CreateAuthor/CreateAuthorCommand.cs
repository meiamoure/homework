﻿using MediatR;

namespace Library.Application.Domain.Authors.Commands.CreateAuthor;

public record CreateAuthorCommand(
    string FirstName,
    string LastName) : IRequest<Guid>;

