using LoymaxTest.DataAccess.Interfaces;
using LoymaxTest.DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace LoymaxTest.DataAccess.Extensions
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
        public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddEntityFrameworkSqlite();
            services.AddDbContext<BankDbContext>(options => options.UseSqlite(connectionString), 
                ServiceLifetime.Transient);
            services.AddScoped<IBankDbContext, BankDbContext>();

            return services;
        }
    }
}
