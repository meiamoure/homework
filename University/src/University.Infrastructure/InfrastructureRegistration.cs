using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using University.Core.Common;
using University.Core.Domain.Departments.Common;
using University.Core.Domain.Faculties.Common;
using University.Core.Domain.Groups.Common;
using University.Core.Domain.Students.Common;
using University.Infrastructure.Core.Common;
using University.Infrastructure.Core.Domain.Departments;
using University.Infrastructure.Core.Domain.Faculties;
using University.Infrastructure.Core.Domain.Groups;
using University.Infrastructure.Core.Domain.Students;

namespace University.Infrastructure;

public static class InfrastructureRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IStudentRepository, StudentsRepository>();
        services.AddScoped<IGroupRepository, GroupsRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentsRepository>();
        services.AddScoped<IFacultyRepository, FacultiesRepository>();
    }
}
