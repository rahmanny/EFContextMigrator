<a name='assembly'></a>
# EFContextMigrator

## Contents

- [ErrorAction](#T-EFContextMigrator-Config-ErrorAction 'EFContextMigrator.Config.ErrorAction')
  - [Break](#F-EFContextMigrator-Config-ErrorAction-Break 'EFContextMigrator.Config.ErrorAction.Break')
  - [IgnoreAndLog](#F-EFContextMigrator-Config-ErrorAction-IgnoreAndLog 'EFContextMigrator.Config.ErrorAction.IgnoreAndLog')
  - [SilentlyContinue](#F-EFContextMigrator-Config-ErrorAction-SilentlyContinue 'EFContextMigrator.Config.ErrorAction.SilentlyContinue')
- [MigrateConfig\`1](#T-EFContextMigrator-Config-MigrateConfig`1 'EFContextMigrator.Config.MigrateConfig`1')
  - [EfProjectName](#P-EFContextMigrator-Config-MigrateConfig`1-EfProjectName 'EFContextMigrator.Config.MigrateConfig`1.EfProjectName')
  - [ErrorAction](#P-EFContextMigrator-Config-MigrateConfig`1-ErrorAction 'EFContextMigrator.Config.MigrateConfig`1.ErrorAction')
  - [Logger](#P-EFContextMigrator-Config-MigrateConfig`1-Logger 'EFContextMigrator.Config.MigrateConfig`1.Logger')
  - [MigratorType](#P-EFContextMigrator-Config-MigrateConfig`1-MigratorType 'EFContextMigrator.Config.MigrateConfig`1.MigratorType')
  - [SourceDbContext](#P-EFContextMigrator-Config-MigrateConfig`1-SourceDbContext 'EFContextMigrator.Config.MigrateConfig`1.SourceDbContext')
  - [TargetDbContext](#P-EFContextMigrator-Config-MigrateConfig`1-TargetDbContext 'EFContextMigrator.Config.MigrateConfig`1.TargetDbContext')
- [MigratorType](#T-EFContextMigrator-Config-MigratorType 'EFContextMigrator.Config.MigratorType')
  - [InMemory](#F-EFContextMigrator-Config-MigratorType-InMemory 'EFContextMigrator.Config.MigratorType.InMemory')
- [Migrator\`1](#T-EFContextMigrator-Migrator`1 'EFContextMigrator.Migrator`1')
  - [Initialize(source,target,EFProjectName,isMemory)](#M-EFContextMigrator-Migrator`1-Initialize-`0,`0,System-String,System-Boolean- 'EFContextMigrator.Migrator`1.Initialize(`0,`0,System.String,System.Boolean)')
  - [Initialize(config)](#M-EFContextMigrator-Migrator`1-Initialize-EFContextMigrator-Config-MigrateConfig{`0}- 'EFContextMigrator.Migrator`1.Initialize(EFContextMigrator.Config.MigrateConfig{`0})')
  - [Migrate(Exclude)](#M-EFContextMigrator-Migrator`1-Migrate-System-String- 'EFContextMigrator.Migrator`1.Migrate(System.String)')
- [QueryableExtensions](#T-EFContextMigrator-Extensions-QueryableExtensions 'EFContextMigrator.Extensions.QueryableExtensions')
  - [Set(context,t)](#M-EFContextMigrator-Extensions-QueryableExtensions-Set-Microsoft-EntityFrameworkCore-DbContext,System-Type- 'EFContextMigrator.Extensions.QueryableExtensions.Set(Microsoft.EntityFrameworkCore.DbContext,System.Type)')

<a name='T-EFContextMigrator-Config-ErrorAction'></a>
## ErrorAction `type`

##### Namespace

EFContextMigrator.Config

##### Summary

Error actions

<a name='F-EFContextMigrator-Config-ErrorAction-Break'></a>
### Break `constants`

##### Summary

Stop work and throw an exception

<a name='F-EFContextMigrator-Config-ErrorAction-IgnoreAndLog'></a>
### IgnoreAndLog `constants`

##### Summary

Continue execution and log error

<a name='F-EFContextMigrator-Config-ErrorAction-SilentlyContinue'></a>
### SilentlyContinue `constants`

##### Summary

Continue execution and do not log error

<a name='T-EFContextMigrator-Config-MigrateConfig`1'></a>
## MigrateConfig\`1 `type`

##### Namespace

EFContextMigrator.Config

##### Summary

Configuration

<a name='P-EFContextMigrator-Config-MigrateConfig`1-EfProjectName'></a>
### EfProjectName `property`

##### Summary

Name of the project containing the Entity Framework classes

<a name='P-EFContextMigrator-Config-MigrateConfig`1-ErrorAction'></a>
### ErrorAction `property`

##### Summary

Error actions

<a name='P-EFContextMigrator-Config-MigrateConfig`1-Logger'></a>
### Logger `property`

##### Summary

Logger

<a name='P-EFContextMigrator-Config-MigrateConfig`1-MigratorType'></a>
### MigratorType `property`

##### Summary

Migrator Type

<a name='P-EFContextMigrator-Config-MigrateConfig`1-SourceDbContext'></a>
### SourceDbContext `property`

##### Summary

Source DbContext

<a name='P-EFContextMigrator-Config-MigrateConfig`1-TargetDbContext'></a>
### TargetDbContext `property`

##### Summary

Target DbContext

<a name='T-EFContextMigrator-Config-MigratorType'></a>
## MigratorType `type`

##### Namespace

EFContextMigrator.Config

##### Summary

Type of Migration

<a name='F-EFContextMigrator-Config-MigratorType-InMemory'></a>
### InMemory `constants`

##### Summary

Im Memory Migration

<a name='T-EFContextMigrator-Migrator`1'></a>
## Migrator\`1 `type`

##### Namespace

EFContextMigrator

##### Summary

Migrator main class

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Entity Framework Context Class |

<a name='M-EFContextMigrator-Migrator`1-Initialize-`0,`0,System-String,System-Boolean-'></a>
### Initialize(source,target,EFProjectName,isMemory) `method`

##### Summary

Object initialization, checking connection to contexts.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [\`0](#T-`0 '`0') | Data source |
| target | [\`0](#T-`0 '`0') | Data recipient |
| EFProjectName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name of the project with the Entity Framework contexts |
| isMemory | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Use Memory to collect and transfer data |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ApplicationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ApplicationException 'System.ApplicationException') |  |

<a name='M-EFContextMigrator-Migrator`1-Initialize-EFContextMigrator-Config-MigrateConfig{`0}-'></a>
### Initialize(config) `method`

##### Summary

Object initialization, checking connection to contexts.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| config | [EFContextMigrator.Config.MigrateConfig{\`0}](#T-EFContextMigrator-Config-MigrateConfig{`0} 'EFContextMigrator.Config.MigrateConfig{`0}') |  |

<a name='M-EFContextMigrator-Migrator`1-Migrate-System-String-'></a>
### Migrate(Exclude) `method`

##### Summary

Starting data migration

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Exclude | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | DBSets excluded from migration |

<a name='T-EFContextMigrator-Extensions-QueryableExtensions'></a>
## QueryableExtensions `type`

##### Namespace

EFContextMigrator.Extensions

##### Summary

IQueryable Extension Methods

<a name='M-EFContextMigrator-Extensions-QueryableExtensions-Set-Microsoft-EntityFrameworkCore-DbContext,System-Type-'></a>
### Set(context,t) `method`

##### Summary



##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [Microsoft.EntityFrameworkCore.DbContext](#T-Microsoft-EntityFrameworkCore-DbContext 'Microsoft.EntityFrameworkCore.DbContext') | Entity Framework context |
| t | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | Data type |
