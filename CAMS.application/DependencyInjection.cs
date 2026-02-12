
using CAMS.application.Courses.Create;
using CAMS.application.Courses.GetById;
using CAMS.application.Students.Create;
using CAMS.application.Units.Create;
using Microsoft.Extensions.DependencyInjection;

namespace CAMS.application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<CreateStudentHandler>();
        services.AddScoped<CreateCourseHandler>();
        services.AddScoped<GetStudentByIdHandler>();
        services.AddScoped<GetCourseByIdHandler>();
        services.AddScoped<CreateUnitHandler>();
        services.AddScoped<GetUnitByIdHandler>();
        return services;
    }

}