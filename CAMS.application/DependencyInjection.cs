
using CAMS.application.Courses.Create;
using CAMS.application.Students.Create;
using Microsoft.Extensions.DependencyInjection;

namespace CAMS.application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<CreateStudentHandler>();
        services.AddScoped<CreateCourseHandler>();

        return services;
    }

}