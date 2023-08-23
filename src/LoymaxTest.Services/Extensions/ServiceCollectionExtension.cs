using Microsoft.Extensions.DependencyInjection;
using LoymaxTest.Services.Auth;
using LoymaxTest.Services.Interfaces;
using LoymaxTest.Services.Hashing;

namespace LoymaxTest.Services.Extensions
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Регистрация сервисов в DI
        /// </summary>
        /// <param name="services">Сервисы</param>
        /// <returns>Обновленные сервисы</returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<ITokenService, TokenService>();
            services.AddSingleton<IHashingService, HashingService>();

            return services;
        }
    }
}
