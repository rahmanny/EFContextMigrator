using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EFContextMigrator.Extensions;

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

        /// <summary>
        /// Object initialization, checking connection to contexts.
        /// </summary>
        /// <param name="source">Data source</param>
        /// <param name="target">Data recipient</param>
        /// <param name="EFProjectName">Name of the project with the Entity Framework contexts</param>
        /// <exception cref="ApplicationException"></exception>
        public void Initialize(T source, T target, string EFProjectName)
        {
            _sourceContext = source;
            _targetContext = target;
            _EFProjectName = EFProjectName;
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
        /// Starting data migration
        /// </summary>
        /// <param name="Exclude">DBSets excluded from migration</param>
        public void Migrate(string Exclude)
        {

            _targetContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var sourceTables = GetDbSets(_sourceContext);
            Console.WriteLine($"Build Migration Query");
            BuildMigrationQuery(_sourceContext);
            Console.WriteLine($"Done");

            //foreach (var sourceTable in sourceTables.Where(x => !Exclude.Contains(x.Name)))
            foreach (var sourceTable in _processList)
            {
                var EntitiestoExclude = Exclude.Split(",").ToList();
                if (!EntitiestoExclude.Contains(sourceTable.Name))
                {
                    MigrateEntity(sourceTable);
                }
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
                    _targetContext.SaveChanges();
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