namespace Employees.Api.Extensions;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        string corsPolicy = configuration["CorsPolicy"] ?? "Local";
        services.AddCors(opt => opt.AddPolicy(corsPolicy, conf =>
            conf.AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod()
        ));

        return services;
    }
}
