﻿using MediatR;

namespace University.Application.Domain.Students.Commands.DeleteStudent;
public record DeleteStudentCommand(Guid Id) : IRequest;
