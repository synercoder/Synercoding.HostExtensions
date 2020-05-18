using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using Synercoding.HostExtensions.EntityFrameworkCore;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Hosting
{
    /// <summary>
    /// Extension class used for migration related methods
    /// </summary>
    public static class MigrateDbContextExtensions
    {
        /// <summary>
        /// Migrate and seed the DbContext using the seed delegate.
        /// </summary>
        /// <typeparam name="THost">The <see cref="IHost"/> type</typeparam>
        /// <typeparam name="TContext">The DbContext type</typeparam>
        /// <typeparam name="TMigrationsConfiguration">The type of the migrations configuration to use during initialization.</typeparam>
        /// <param name="hostTask">The task that can be awaited to get the host.</param>
        /// <param name="seeder">The seed delegate.</param>
        /// <returns>A task that represents the asynchronous migration operation.</returns>
        public static async Task<IHost> MigrateDbContext<THost, TContext, TMigrationsConfiguration>(this Task<THost> hostTask, AsyncSeedMethod<TContext> seeder)
            where THost : IHost
            where TContext : DbContext
            where TMigrationsConfiguration : DbMigrationsConfiguration<TContext>, new()
        {
            var host = await hostTask;
            return await host.MigrateDbContext<TContext, TMigrationsConfiguration>(seeder);
        }

        /// <summary>
        /// Migrate and seed the DbContext using the seed delegate.
        /// </summary>
        /// <typeparam name="THost">The <see cref="IHost"/> type</typeparam>
        /// <typeparam name="TContext">The DbContext type</typeparam>
        /// <typeparam name="TMigrationsConfiguration">The type of the migrations configuration to use during initialization.</typeparam>
        /// <param name="hostTask">The task that can be awaited to get the host.</param>
        /// <param name="seeder">The seed delegate.</param>
        /// <returns>A task that represents the asynchronous migration operation.</returns>
        public static async Task<IHost> MigrateDbContext<THost, TContext, TMigrationsConfiguration>(this Task<THost> hostTask, SeedMethod<TContext> seeder)
            where THost : IHost
            where TContext : DbContext
            where TMigrationsConfiguration : DbMigrationsConfiguration<TContext>, new()
        {
            var host = await hostTask;
            return await host.MigrateDbContext<TContext, TMigrationsConfiguration>(seeder);
        }

        /// <summary>
        /// Migrate the DbContext.
        /// </summary>
        /// <typeparam name="THost">The <see cref="IHost"/> type</typeparam>
        /// <typeparam name="TContext">The DbContext type</typeparam>
        /// <typeparam name="TMigrationsConfiguration">The type of the migrations configuration to use during initialization.</typeparam>
        /// <param name="hostTask">The task that can be awaited to get the host.</param>
        /// <returns>A task that represents the asynchronous migration operation.</returns>
        public static async Task<IHost> MigrateDbContext<THost, TContext, TMigrationsConfiguration>(this Task<THost> hostTask)
            where THost : IHost
            where TContext : DbContext
            where TMigrationsConfiguration : DbMigrationsConfiguration<TContext>, new()
        {
            var host = await hostTask;
            return await host.MigrateDbContext<TContext, TMigrationsConfiguration>();
        }

        /// <summary>
        /// Migrate and seed the DbContext using the seed delegate.
        /// </summary>
        /// <typeparam name="TContext">The DbContext type</typeparam>
        /// <typeparam name="TMigrationsConfiguration">The type of the migrations configuration to use during initialization.</typeparam>
        /// <param name="hostTask">The task that can be awaited to get the host.</param>
        /// <param name="seeder">The seed delegate.</param>
        /// <returns>A task that represents the asynchronous migration operation.</returns>
        public static async Task<IHost> MigrateDbContext<TContext, TMigrationsConfiguration>(this Task<ElseExecuteHost> hostTask, AsyncSeedMethod<TContext> seeder)
            where TContext : DbContext
            where TMigrationsConfiguration : DbMigrationsConfiguration<TContext>, new()
        {
            var host = await hostTask;
            return await host.MigrateDbContext<TContext, TMigrationsConfiguration>(seeder);
        }

        /// <summary>
        /// Migrate and seed the DbContext using the seed delegate.
        /// </summary>
        /// <typeparam name="TContext">The DbContext type</typeparam>
        /// <typeparam name="TMigrationsConfiguration">The type of the migrations configuration to use during initialization.</typeparam>
        /// <param name="hostTask">The task that can be awaited to get the host.</param>
        /// <param name="seeder">The seed delegate.</param>
        /// <returns>A task that represents the asynchronous migration operation.</returns>
        public static async Task<IHost> MigrateDbContext<TContext, TMigrationsConfiguration>(this Task<ElseExecuteHost> hostTask, SeedMethod<TContext> seeder)
            where TContext : DbContext
            where TMigrationsConfiguration : DbMigrationsConfiguration<TContext>, new()
        {
            var host = await hostTask;
            return await host.MigrateDbContext<TContext, TMigrationsConfiguration>(seeder);
        }

        /// <summary>
        /// Migrate the DbContext.
        /// </summary>
        /// <typeparam name="TContext">The DbContext type</typeparam>
        /// <typeparam name="TMigrationsConfiguration">The type of the migrations configuration to use during initialization.</typeparam>
        /// <param name="hostTask">The task that can be awaited to get the host.</param>
        /// <returns>A task that represents the asynchronous migration operation.</returns>
        public static async Task<IHost> MigrateDbContext<TContext, TMigrationsConfiguration>(this Task<ElseExecuteHost> hostTask)
            where TContext : DbContext
            where TMigrationsConfiguration : DbMigrationsConfiguration<TContext>, new()
        {
            var host = await hostTask;
            return await host.MigrateDbContext<TContext, TMigrationsConfiguration>();
        }

        /// <summary>
        /// Migrate and seed the DbContext using the seed delegate.
        /// </summary>
        /// <typeparam name="TContext">The DbContext type</typeparam>
        /// <typeparam name="TMigrationsConfiguration">The type of the migrations configuration to use during initialization.</typeparam>
        /// <param name="hostTask">The task that can be awaited to get the host.</param>
        /// <param name="seeder">The seed delegate.</param>
        /// <returns>A task that represents the asynchronous migration operation.</returns>
        public static async Task<IHost> MigrateDbContext<TContext, TMigrationsConfiguration>(this Task<IHost> hostTask, AsyncSeedMethod<TContext> seeder)
            where TContext : DbContext
            where TMigrationsConfiguration : DbMigrationsConfiguration<TContext>, new()
        {
            var host = await hostTask;
            return await host.MigrateDbContext<TContext, TMigrationsConfiguration>(seeder);
        }

        /// <summary>
        /// Migrate and seed the DbContext using the seed delegate.
        /// </summary>
        /// <typeparam name="TContext">The DbContext type</typeparam>
        /// <typeparam name="TMigrationsConfiguration">The type of the migrations configuration to use during initialization.</typeparam>
        /// <param name="hostTask">The task that can be awaited to get the host.</param>
        /// <param name="seeder">The seed delegate.</param>
        /// <returns>A task that represents the asynchronous migration operation.</returns>
        public static async Task<IHost> MigrateDbContext<TContext, TMigrationsConfiguration>(this Task<IHost> hostTask, SeedMethod<TContext> seeder)
            where TContext : DbContext
            where TMigrationsConfiguration : DbMigrationsConfiguration<TContext>, new()
        {
            var host = await hostTask;
            return await host.MigrateDbContext<TContext, TMigrationsConfiguration>(seeder);
        }

        /// <summary>
        /// Migrate the DbContext.
        /// </summary>
        /// <typeparam name="TContext">The DbContext type</typeparam>
        /// <typeparam name="TMigrationsConfiguration">The type of the migrations configuration to use during initialization.</typeparam>
        /// <param name="hostTask">The task that can be awaited to get the host.</param>
        /// <returns>A task that represents the asynchronous migration operation.</returns>
        public static async Task<IHost> MigrateDbContext<TContext, TMigrationsConfiguration>(this Task<IHost> hostTask)
            where TContext : DbContext
            where TMigrationsConfiguration : DbMigrationsConfiguration<TContext>, new()
        {
            var host = await hostTask;
            return await host.MigrateDbContext<TContext, TMigrationsConfiguration>();
        }

        /// <summary>
        /// Migrate the DbContext
        /// </summary>
        /// <typeparam name="TContext">The DbContext type</typeparam>
        /// <typeparam name="TMigrationsConfiguration">The type of the migrations configuration to use during initialization.</typeparam>
        /// <param name="host">The host that will execute the migration.</param>
        /// <returns>A task that represents the asynchronous migration operation.</returns>
        public static Task<IHost> MigrateDbContext<TContext, TMigrationsConfiguration>(this IHost host)
            where TContext : DbContext
            where TMigrationsConfiguration : DbMigrationsConfiguration<TContext>, new()
        {
            return host.MigrateDbContext<TContext, TMigrationsConfiguration>((p1, p2) => Task.CompletedTask);
        }

        /// <summary>
        /// Migrate and seed the DbContext using the seed delegate.
        /// </summary>
        /// <typeparam name="TContext">The DbContext type</typeparam>
        /// <typeparam name="TMigrationsConfiguration">The type of the migrations configuration to use during initialization.</typeparam>
        /// <param name="host">The host that will execute the migration.</param>
        /// <param name="seeder">The seed delegate.</param>
        /// <returns>A task that represents the asynchronous migration operation.</returns>
        public static Task<IHost> MigrateDbContext<TContext, TMigrationsConfiguration>(this IHost host, SeedMethod<TContext> seeder)
            where TContext : DbContext
            where TMigrationsConfiguration : DbMigrationsConfiguration<TContext>, new()
        {
            Task asyncSeeder(TContext c, IServiceProvider s)
            {
                seeder(c, s);
                return Task.CompletedTask;
            }
            return host.MigrateDbContext<TContext, TMigrationsConfiguration>(asyncSeeder);
        }

        /// <summary>
        /// Migrate and seed the DbContext using the seed delegate.
        /// </summary>
        /// <typeparam name="TContext">The DbContext type</typeparam>
        /// <typeparam name="TMigrationsConfiguration">The type of the migrations configuration to use during initialization.</typeparam>
        /// <param name="host">The host that will execute the migration.</param>
        /// <param name="seeder">The seed delegate.</param>
        /// <returns>A task that represents the asynchronous migration operation.</returns>
        public static Task<IHost> MigrateDbContext<TContext, TMigrationsConfiguration>(this IHost host, AsyncSeedMethod<TContext> seeder)
            where TContext : DbContext
            where TMigrationsConfiguration : DbMigrationsConfiguration<TContext>, new()
        {
            var retry = Policy.Handle<SqlException>()
                .WaitAndRetryAsync(new TimeSpan[]
                {
                    TimeSpan.FromSeconds(3),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(8),
                });

            return _migrateDbContext<TContext, TMigrationsConfiguration>(host, retry, seeder);
        }

        private static async Task<IHost> _migrateDbContext<TContext, TMigrationsConfiguration>(this IHost host, IAsyncPolicy retryPolicy, AsyncSeedMethod<TContext> seeder)
            where TContext : DbContext
            where TMigrationsConfiguration : DbMigrationsConfiguration<TContext>, new()
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var logger = services.GetRequiredService<ILogger<TContext>>();

                var context = services.GetService<TContext>();

                try
                {
                    logger.LogInformation($"Migrating database associated with context {typeof(TContext).Name}");

                    await retryPolicy
                        .ExecuteAsync(async () =>
                        {
                            var migrator = new MigrateDatabaseToLatestVersion<TContext, TMigrationsConfiguration>(true);
                            migrator.InitializeDatabase(context);

                            await seeder(context, services).ConfigureAwait(false);
                        })
                        .ConfigureAwait(false);


                    logger.LogInformation($"Migrated database associated with context {typeof(TContext).Name}");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"An error occurred while migrating the database used on context {typeof(TContext).Name}");
                }
            }

            return host;
        }
    }
}
