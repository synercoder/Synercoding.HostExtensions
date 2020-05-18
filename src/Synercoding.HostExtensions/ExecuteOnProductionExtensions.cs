using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Hosting
{
    /// <summary>
    /// Extensions for the host to enable executions of code if environment is set to production.
    /// </summary>
    public static class ExecuteOnProductionExtensions
    {
        /// <summary>
        /// Execute method if the host environment is set to Production
        /// </summary>
        /// <typeparam name="THost">The <see cref="IHost"/> type</typeparam>
        /// <param name="hostTask">The task that can be awaited to get the host.</param>
        /// <param name="method">The method to execute if the environment is Production.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static Task<ElseExecuteHost> ExecuteOnProduction<THost>(this Task<THost> hostTask, Func<IHost, IHost> method)
            where THost : IHost
            => hostTask.ExecuteIf(_predicate, method);

        /// <summary>
        /// Execute method if the host environment is set to Production
        /// </summary>
        /// <typeparam name="THost">The <see cref="IHost"/> type</typeparam>
        /// <param name="hostTask">The task that can be awaited to get the host.</param>
        /// <param name="method">The method to execute if the environment is Production.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static Task<ElseExecuteHost> ExecuteOnProduction<THost>(this Task<THost> hostTask, Func<IHost, Task<IHost>> method)
            where THost : IHost
            => hostTask.ExecuteIf(_predicate, method);

        /// <summary>
        /// Execute method if the host environment is set to Production
        /// </summary>
        /// <typeparam name="THost">The <see cref="IHost"/> type</typeparam>
        /// <param name="host">The host that will be used to execute the method.</param>
        /// <param name="method">The method to execute if the environment is Production.</param>
        /// <returns>The host.</returns>
        public static ElseExecuteHost ExecuteOnProduction<THost>(this THost host, Func<IHost, IHost> method)
            where THost : IHost
            => host.ExecuteIf(_predicate, method);

        /// <summary>
        /// Execute method if the host environment is set to Production
        /// </summary>
        /// <typeparam name="THost">The <see cref="IHost"/> type</typeparam>
        /// <param name="host">The host that will be used to execute the method.</param>
        /// <param name="method">The method to execute if the environment is Production.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static Task<ElseExecuteHost> ExecuteOnProduction<THost>(this THost host, Func<IHost, Task<IHost>> method)
            where THost : IHost
            => host.ExecuteIf(_predicate, method);

        private static bool _predicate(IHost host)
            => host.Services.GetRequiredService<IHostEnvironment>().IsProduction();
    }
}
