# Synercoding.HostExtensions
[![Nuget](https://img.shields.io/nuget/vpre/Synercoding.HostExtensions?label=Synercoding.HostExtensions)](https://www.nuget.org/packages/Synercoding.HostExtensions/)

This package contains general extensions, mostly to execute methods under certain conditions.

Install it using the following commands:

**Using the NuGet Package Manager**
```
Install-Package Synercoding.HostExtensions.EntityFramework -Version 1.0.0-alpha02
```

**Using the .NET CLI**
```
dotnet add package Synercoding.HostExtensions -Version 1.0.0-alpha02
```

---

# Synercoding.HostExtensions.EntityFrameworkCore
[![Nuget](https://img.shields.io/nuget/vpre/Synercoding.HostExtensions?label=Synercoding.HostExtensions.EntityFrameworkCore)](https://www.nuget.org/packages/Synercoding.HostExtensions.EntityFrameworkCore/)

This pacakge contains host extensions for EF Core for migrating and seeding the database.

Install it using the following commands:

**Using the NuGet Package Manager**
```
Install-Package Synercoding.HostExtensions.EntityFrameworkCore -Version 1.0.0-alpha02
```

**Using the .NET CLI**
```
dotnet add package Synercoding.HostExtensions.EntityFrameworkCore -Version 1.0.0-alpha02
```

---

# Synercoding.HostExtensions.EntityFramework
[![Nuget](https://img.shields.io/nuget/vpre/Synercoding.HostExtensions?label=Synercoding.HostExtensions.EntityFramework)](https://www.nuget.org/packages/Synercoding.HostExtensions.EntityFramework/)

This pacakge contains host extensions for Entity Framework (non-core) for migrating and seeding the database.

Install it using the following commands:

**Using the NuGet Package Manager**
```
Install-Package Synercoding.HostExtensions.EntityFramework -Version 1.0.0-alpha02
```

**Using the .NET CLI**
```
dotnet add package Synercoding.HostExtensions.EntityFramework -Version 1.0.0-alpha02
```

---


# Usages

Most of the tasks are build so the can be executed in sync and async code. Before calling `Run` or `RunAsync` on the `IHost`, you can call the different extension methods.

If you are for example running a website using EF Core & migrations:

- You can call `ExecuteOnDevelopment` (from Synercoding.HostExtensions) with in it a call to `MigrateDbContext` (from Synercoding.HostExtensions.EntityFrameworkCore) and execute the development seed method. 
- If the environment isn't development, but instead testing, then the testseed will be executed.
- And if non of those apply, only the migration will be executed.

```
public class Program
{
    public static async Task Main(string[] args)
    {
        await CreateHostBuilder(args)
            .Build()
            .ExecuteOnDevelopment(host => host.MigrateDbContext<MyContext>(DevelopmentSeeder))
            .ElseIf(host => IsTestingEnvironment(host), host => host.MigrateDbContext<MyContext>(TestingSeeder))
            .Else(host => host.MigrateDbContext<MyContext>())
            .RunAsync();
    }

    private static bool IsTestingEnvironment(IHost host)
        => host.Services.GetRequiredService<IHostEnvironment>().IsEnvironment("Testing");

    private static Task DevelopmentSeeder(MyContext context, IServiceProvider services)
    {
        // Development seed method here
        return Task.CompletedTask;
    }

    private static Task TestingSeeder(MyContext context, IServiceProvider services)
    {
        // Testing seed method here
        return Task.CompletedTask;
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
```