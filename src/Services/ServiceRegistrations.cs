using Note.Api.Data;

namespace Note.Api.Services;
public class ServiceRegistrations
{
    public static void RegisterServices(IServiceCollection services)
    {
        // Default Services
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        // My Services
        services.AddSingleton<Database>();
        services.AddSingleton<EntryService>();
    }
}