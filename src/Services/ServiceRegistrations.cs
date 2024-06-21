using Microsoft.EntityFrameworkCore;
using Note.Api.Data;
using Note.Api.Data.Models;

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
        // services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
    }
}