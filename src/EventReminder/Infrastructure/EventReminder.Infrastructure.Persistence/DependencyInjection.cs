using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EventReminder.SharedKernel.Primitives;
using EventReminder.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace EventReminder.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString(ConnectionString.SettingsKey);
            services.AddDbContext<EventReminderDbContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IDbContext>(serviceProvider => serviceProvider.GetRequiredService<EventReminderDbContext>());

            return services;
        }
    }
}
