using System.Reflection;
using FluentValidation;
using LoymaxTest.Application.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LoymaxTest.Application.Extensions
{
    /// <summary>
    /// Расширения ServiceCollection
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Регистрация сервисов в DI
        /// </summary>
        /// <param name="services">Сервисы</param>
        /// <returns>Обновленные сервисы</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg
                => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
