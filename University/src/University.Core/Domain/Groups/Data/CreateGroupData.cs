﻿namespace University.Core.Domain.Groups.Data;
public record CreateGroupData(
    string Name,
    Guid DepartmentId);
