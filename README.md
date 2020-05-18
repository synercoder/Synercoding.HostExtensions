# Synercoding.HostExtensions
[![Nuget](https://img.shields.io/nuget/vpre/Synercoding.HostExtensions?label=Synercoding.HostExtensions)](https://www.nuget.org/packages/Synercoding.HostExtensions/)

This package contains general extensions, mostly to execute methods under certain conditions.

Install it using the following commands:

**Using the NuGet Package Manager**
```
Install-Package Synercoding.HostExtensions.EntityFramework -Version 1.0.0-alpha01
```

**Using the .NET CLI**
```
dotnet add package Synercoding.HostExtensions -Version 1.0.0-alpha01
```

---

# Synercoding.HostExtensions.EntityFrameworkCore
[![Nuget](https://img.shields.io/nuget/vpre/Synercoding.HostExtensions?label=Synercoding.HostExtensions.EntityFrameworkCore)](https://www.nuget.org/packages/Synercoding.HostExtensions.EntityFrameworkCore/)

This pacakge contains host extensions for EF Core for migrating and seeding the database.

Install it using the following commands:

**Using the NuGet Package Manager**
```
Install-Package Synercoding.HostExtensions.EntityFrameworkCore -Version 1.0.0-alpha01
```

**Using the .NET CLI**
```
dotnet add package Synercoding.HostExtensions.EntityFrameworkCore -Version 1.0.0-alpha01
```

---

# Synercoding.HostExtensions.EntityFramework
[![Nuget](https://img.shields.io/nuget/vpre/Synercoding.HostExtensions?label=Synercoding.HostExtensions.EntityFramework)](https://www.nuget.org/packages/Synercoding.HostExtensions.EntityFramework/)

This pacakge contains host extensions for Entity Framework (non-core) for migrating and seeding the database.

Install it using the following commands:

**Using the NuGet Package Manager**
```
Install-Package Synercoding.HostExtensions.EntityFramework -Version 1.0.0-alpha01
```

**Using the .NET CLI**
```
dotnet add package Synercoding.HostExtensions.EntityFramework -Version 1.0.0-alpha01
```

---


# Usages

Most of the tasks are build so the can be executed in sync and async code. Before calling `Run` or `RunAsync` on the `IHost`, you can call the different extension methods.

If you are for example using EF Core & migrations, you can call `ExecuteOnDevelopment` (from Synercoding.HostExtensions) with in it a call to `MigrateDbContext` (from Synercoding.HostExtensions.EntityFrameworkCore)

```
public static async Task Main(string[] args)
{
    await CreateHostBuilder(args)
        .Build()
        .ExecuteOnDevelopment(host => host.MigrateDbContext<MyContext>(DevelopmentSeeder))
        .ExecuteOnProduction(host => host.MigrateDbContext<MyContext>())
        .RunAsync();
}

private static Task DevelopmentSeeder(MyContext context, IServiceProvider services)
{
    // Seed method here
}
```