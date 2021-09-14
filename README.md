# EFContextMigrator
Library for easy data migration between Entity Framework contexts

## Get Started
 - Install EFContextMigrator package from NuGet
 - Create a migrator object
 ```cs
  ContextMigrator<YourRootContext> migrator = new ContextMigrator<YourRootContext>();
 ```
 - Initialize parameters
  ```cs
 migrator.Initialize(sourceContext, targetContext, "YourEFProjectName" , true);
 ```
The inMemory option loads the source database into RAM and then saves it to the target database.
  - Run Migration
 ```cs
  migrator.Migrate("Classes for exclusion, separated by commas");
 ```