<a name='assembly'></a>
# EFContextMigrator

## Contents

- [Migrator\`1](#T-EFContextMigrator-Migrator`1 'EFContextMigrator.Migrator`1')
  - [Initialize(source,target,EFProjectName,isMemory)](#M-EFContextMigrator-Migrator`1-Initialize-`0,`0,System-String,System-Boolean- 'EFContextMigrator.Migrator`1.Initialize(`0,`0,System.String,System.Boolean)')
  - [Migrate(Exclude)](#M-EFContextMigrator-Migrator`1-Migrate-System-String- 'EFContextMigrator.Migrator`1.Migrate(System.String)')
- [QueryableExtensions](#T-EFContextMigrator-Extensions-QueryableExtensions 'EFContextMigrator.Extensions.QueryableExtensions')
  - [Set(context,t)](#M-EFContextMigrator-Extensions-QueryableExtensions-Set-Microsoft-EntityFrameworkCore-DbContext,System-Type- 'EFContextMigrator.Extensions.QueryableExtensions.Set(Microsoft.EntityFrameworkCore.DbContext,System.Type)')

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
