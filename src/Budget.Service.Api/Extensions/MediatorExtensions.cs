using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace Budget.Service.Api.Extensions
{
    /// <summary>
    /// Расширения связанные с медиторами
    /// </summary>
    internal static class MediatorExtensions
    {
        /// <summary>
        /// Добавление поддержки медаторов <see cref="IServiceCollection" />
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection" /></param>
        internal static void AddMediators(this IServiceCollection services)
        {
        }
    }
}
