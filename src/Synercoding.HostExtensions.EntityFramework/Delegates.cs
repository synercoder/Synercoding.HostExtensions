using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Synercoding.HostExtensions.EntityFrameworkCore
{

    /// <summary>
    /// An async delegate representing a database seeding method
    /// </summary>
    /// <typeparam name="TContext">The DbContext type</typeparam>
    /// <param name="context">The context that needs to be seeded.</param>
    /// <param name="services">A <see cref="IServiceProvider"/> that can be used for seeding.</param>
    /// <returns>An awaitable task representing this delegate call</returns>
    public delegate Task AsyncSeedMethod<TContext>(TContext context, IServiceProvider services)
            where TContext : DbContext;

    /// <summary>
    /// An delegate representing a database seeding method
    /// </summary>
    /// <typeparam name="TContext">The DbContext type</typeparam>
    /// <param name="context">The context that needs to be seeded.</param>
    /// <param name="services">A <see cref="IServiceProvider"/> that can be used for seeding.</param>
    public delegate void SeedMethod<TContext>(TContext context, IServiceProvider services)
            where TContext : DbContext;
}
