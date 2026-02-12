namespace ClassAttendanceManagementSystem_backend;

public static class DependancyInjection
{
    public static IServiceCollection AddPresentationLayer(this IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddOpenApi();
        services.AddSwaggerGen();
        services.AddControllers();
        return services;
    }

}