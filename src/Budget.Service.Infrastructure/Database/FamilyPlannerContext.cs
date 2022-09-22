using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Budget.Service.Api.Test")]

namespace Budget.Service.Infrastructure.Database
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    internal class FamilyPlannerContext: DbContext
    {
        /// <summary>
        /// Конструктор <see cref="FamilyPlannerContext" />
        /// </summary>
        /// <param name="options">настройки для подключения к БД</param>
        public FamilyPlannerContext(DbContextOptions options): base(options)
        { }

        /// <summary>
        /// Действия во время создания модели
        /// </summary>
        /// <param name="modelBuilder"><see cref="ModelBuilder" /></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
