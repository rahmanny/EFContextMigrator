using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EFContextMigrator.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EFContextMigrator.Extensions;
using Microsoft.Extensions.Logging;

namespace EFContextMigrator
{
    /// <summary>
    /// Migrator main class
    /// </summary>
    /// <typeparam name="T">Entity Framework Context Class</typeparam>
    public class Migrator<T> where T : DbContext
    {
        private T _sourceContext;
        private T _targetContext;
        private List<IEntityType> _processList = new List<IEntityType>();
        private string _EFProjectName;
        private bool _isMemory;
        private bool _isLoggerExist;
        private ILogger _logger;
        private bool _throw = false;

        /// <summary>
        /// Object initialization, checking connection to contexts.
        /// </summary>
        /// <param name="source">Data source</param>
        /// <param name="target">Data recipient</param>
        /// <param name="EFProjectName">Name of the project with the Entity Framework contexts</param>
        /// <param name="isMemory">Use Memory to collect and transfer data</param>
        /// <exception cref="ApplicationException"></exception>
        [ObsoleteAttribute("This method is obsolete.", true)]
        public void Initialize(T source, T target, string EFProjectName, bool isMemory)
        {
            _sourceContext = source;
            _targetContext = target;
            _EFProjectName = EFProjectName;
            _isMemory = isMemory;
            try
            {
                if (_sourceContext.Database.CanConnect() == false)
                {
                    throw new ApplicationException("Could not connect to Source DB");
                }
                if (_targetContext.Database.CanConnect() == false)
                {
                    throw new ApplicationException("Could not connect to Target DB");
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Object initialization, checking connection to contexts.
        /// </summary>
        /// <param name="config"></param>
        public void Initialize(MigrateConfig<T> config)
        {
            _sourceContext = config.SourceDbContext;
            _targetContext = config.TargetDbContext;
            _EFProjectName = config.EfProjectName;
            if (config.MigratorType == MigratorType.InMemory)
            {
                _isMemory = true;
            }

            if (config.Logger == null)
            {
                _isLoggerExist = false;
            }
            else if (config.ErrorAction == ErrorAction.IgnoreAndLog)
            {
                _isLoggerExist = true;
                _logger = config.Logger;
            }
            else if (config.ErrorAction == ErrorAction.SilentlyContinue)
            {
                _isLoggerExist = false;
            }

            if (config.ErrorAction == ErrorAction.Break)
            {
                _throw = true;
            }

            try
            {
                if (_sourceContext.Database.CanConnect() == false)
                {
                    throw new ApplicationException("Could not connect to Source DB");
                }
                if (_targetContext.Database.CanConnect() == false)
                {
                    throw new ApplicationException("Could not connect to Target DB");
                }
            }
            catch (Exception e)
            {
                if (_isLoggerExist)
                {
                    _logger.LogCritical(e.Message);
                }

                if (_throw)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Starting data migration
        /// </summary>
        /// <param name="Exclude">DBSets excluded from migration</param>
        public void Migrate(string Exclude)
        {

            _targetContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            if (_isMemory)
            {
                _targetContext.ChangeTracker.AutoDetectChangesEnabled = false;
            }

            var sourceTables = GetDbSets(_sourceContext);
            //Console.WriteLine($"Build Migration Query");
            //BuildMigrationQuery(_sourceContext);
            //Console.WriteLine($"Done");

            foreach (var sourceTable in sourceTables.Where(x => !Exclude.Contains(x.Name)))
            //foreach (var sourceTable in _processList)
            {
                var EntitiestoExclude = Exclude.Split(",").ToList();
                if (!EntitiestoExclude.Contains(sourceTable.Name))
                {
                    MigrateEntity(sourceTable);
                }
            }

            if (_isMemory)
            {
                Console.WriteLine("Detect changes");
                _targetContext.ChangeTracker.DetectChanges();
                Console.WriteLine("Process all tables done, save to target DB");
                _targetContext.SaveChanges();
            }

            Console.WriteLine("Migration Done");


        }

        private void MigrateEntity(IEntityType entity)
        {
            Console.WriteLine($"Process table {entity.Name}");
            var assembly = Assembly.Load($"{nameof(_EFProjectName)}");
            var databaseAssemblyTypes = assembly.GetTypes();
            var next = true;
            int skip = 0;
            var sourceType = databaseAssemblyTypes.FirstOrDefault(t => t.FullName == entity.Name);
            var queryable = _sourceContext.Set(sourceType);
            while (next)
            {
                var objects = queryable.Skip(skip).Take(1000);
                if (objects.Count() != 0)
                {
                    skip += 1000;
                    _targetContext.AddRange(objects);
                    if (_isMemory == false)
                    {
                        _targetContext.SaveChanges();
                    }
                }
                else
                {
                    next = false;
                }
            }

            Console.WriteLine($"Process table {entity.Name} done");
        }

        private List<IEntityType> GetDbSets(DbContext context)
        {
            return context.Model.GetEntityTypes().ToList();
        }

        [ObsoleteAttribute("This method is obsolete.", true)]
        private void BuildMigrationQuery(DbContext context)
        {
            var models = context.Model;
            var relational = models.GetRelationalModel();
            var tables = relational.Tables;
            var sourceTables = GetDbSets(_sourceContext);
            while (_processList.Count < sourceTables.Count())
            {
                foreach (var table in tables)
                {
                    if (table.ForeignKeyConstraints.Count() == 0)
                    {
                        var entity = table.EntityTypeMappings.FirstOrDefault().EntityType;
                        if (!_processList.Contains(entity))
                        {
                            _processList.Add(sourceTables.FirstOrDefault(x => x == entity));
                        }


                    }
                    else
                    {
                        var isretaltionaalreadyinquery = true;
                        var listRelational = table.ForeignKeyConstraints.ToList();
                        foreach (var tablerelational in listRelational)
                        {
                            var mappings = tablerelational.PrincipalTable.EntityTypeMappings.ToList();
                            foreach (var mapping in mappings)
                            {
                                if (!_processList.Contains(mapping.EntityType))
                                {
                                    isretaltionaalreadyinquery = false;
                                }
                            }
                        }

                        if (isretaltionaalreadyinquery)
                        {
                            var entity = table.EntityTypeMappings.FirstOrDefault().EntityType;
                            if (!_processList.Contains(entity))
                            {
                                _processList.Add(sourceTables.FirstOrDefault(x => x == entity));
                            }
                        }
                    }
                }
            }

        }


    }
}