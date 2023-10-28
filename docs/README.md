# Global NuGet tools

```powershell
# Nuke - https://nuke.build
dotnet tool install --global Nuke.GlobalTool

# EF Core CLI tools - https://learn.microsoft.com/en-us/ef/core/cli/dotnet
dotnet tool install --global dotnet-ef
```

# Persistence
💡 The commands below assume that you're in the `root` repo directory.

### Apply migrations
```powershell
dotnet ef database update -p .\src\Persistence\PlanningPoker.Persistence.csproj -s .\src\WebAPI\PlanningPoker.WebAPI.csproj
```

### Create migrations
```powershell
dotnet ef migrations add "MyNewMigration" -p .\src\Persistence\PlanningPoker.Persistence.csproj -s .\src\WebAPI\PlanningPoker.WebAPI.csproj
```

# Identity
### Scaffolding Identity UI Pages
https://learn.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-7.0&tabs=netcore-cli

### Installing the `ASP.NET Core scaffolder`
```powershell
dotnet tool install -g dotnet-aspnet-codegenerator
dotnet aspnet-codegenerator identity -h
```

### Required NuGet packages
```powershell
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Identity.UI
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```