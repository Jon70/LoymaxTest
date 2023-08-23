using LoymaxTest.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace LoymaxTest.Persistence.Extensions
{
    /// <summary>
    /// Расширения ServiceCollection
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Регистрация БД в DI
        /// </summary>
        /// <param name="services">Сервисы</param>
        /// <param name="connectionString">Строка подключения</param>
        /// <returns>Обновленные сервисы</returns>
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BankDbContext>(options => options.UseSqlite(connectionString), 
                ServiceLifetime.Transient);
            services.AddScoped<IBankDbContext>(provider => provider.GetService<BankDbContext>()!);

            return services;
        }
    }
}
