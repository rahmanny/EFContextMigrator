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
 migrator.Initialize(sourceContext, targetContext, "YourEFProjectName");
 ```
  - Run Migration
    ```cs
  migrator.Migrate("Classes for exclusion, separated by commas");
   ```