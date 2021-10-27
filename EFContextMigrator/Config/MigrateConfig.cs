
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFContextMigrator.Config
{
    /// <summary>
    /// Configuration
    /// </summary>
    public class MigrateConfig<T> where T : DbContext
    {

        /// <summary>
        /// Source DbContext
        /// </summary>
        [Required(ErrorMessage = "SourceDbContext is a required field.")]
        public T SourceDbContext { get; set; }

        /// <summary>
        /// Target DbContext
        /// </summary>
        [Required(ErrorMessage = "TargetDbContext is a required field.")]
        public T TargetDbContext { get; set; }

        /// <summary>
        /// Migrator Type
        /// </summary>
        [Required(ErrorMessage = "MigratorType is a required field.")]
        public MigratorType MigratorType { get; set; }

        /// <summary>
        /// Name of the project containing the Entity Framework classes
        /// </summary>
        [Required(ErrorMessage = "EfProjectName is a required field.")]
        public string EfProjectName { get; set; }

        /// <summary>
        /// Error actions
        /// </summary>
        [Required(ErrorMessage = "ErrorAction is a required field.")]
        public ErrorAction ErrorAction { get; set; }

#nullable enable
        /// <summary>
        /// Logger
        /// </summary>
        public ILogger? Logger { get; set; }
#nullable disable
    }
}