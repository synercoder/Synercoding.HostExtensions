using System;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Hosting
{
    /// <summary>
    /// Extensions for the host to enable executions of code based on conditions.
    /// </summary>
    public static class ExecuteIfExtensions
    {
        /// <summary>
        /// Execute a task if the predicate returns true.
        /// </summary>
        /// <param name="hostTask">The task that can be awaited to get the host.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="method">The method to execute if the predicate returns true.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<IHost> ExecuteIf(this Task<IHost> hostTask, Func<IHost, bool> predicate, Func<IHost, IHost> method)
        {
            var host = await hostTask;
            return ExecuteIf(host, predicate, method);
        }

        /// <summary>
        /// Execute a task if the predicate returns true.
        /// </summary>
        /// <param name="hostTask">The task that can be awaited to get the host.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="method">The method to execute if the predicate returns true.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<IHost> ExecuteIf(this Task<IHost> hostTask, Func<IHost, bool> predicate, Func<IHost, Task<IHost>> method)
        {
            var host = await hostTask;
            return await ExecuteIf(host, predicate, method);
        }

        /// <summary>
        /// Execute a task if the predicate returns true.
        /// </summary>
        /// <param name="hostTask">The task that can be awaited to get the host.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="method">The method to execute if the predicate returns true.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<IHost> ExecuteIf(this Task<IHost> hostTask, Func<IHost, Task<bool>> predicate, Func<IHost, Task<IHost>> method)
        {
            var host = await hostTask;
            return await ExecuteIf(host, predicate, method);
        }

        /// <summary>
        /// Execute a task if the predicate returns true.
        /// </summary>
        /// <param name="host">The host that will be used to execute the method.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="method">The method to execute if the predicate returns true.</param>
        /// <returns>The host.</returns>
        public static IHost ExecuteIf(this IHost host, Func<IHost, bool> predicate, Func<IHost, IHost> method)
        {
            return predicate(host)
                ? method(host)
                : host;
        }

        /// <summary>
        /// Execute a task if the predicate returns true.
        /// </summary>
        /// <param name="host">The host that will be used to execute the method.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="method">The method to execute if the predicate returns true.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<IHost> ExecuteIf(this IHost host, Func<IHost, bool> predicate, Func<IHost, Task<IHost>> method)
        {
            return predicate(host)
                ? await method(host)
                : host;
        }

        /// <summary>
        /// Execute a task if the predicate returns true.
        /// </summary>
        /// <param name="host">The host that will be used to execute the method.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="method">The method to execute if the predicate returns true.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<IHost> ExecuteIf(this IHost host, Func<IHost, Task<bool>> predicate, Func<IHost, Task<IHost>> method)
        {
            return await predicate(host)
                ? await method(host)
                : host;
        }
    }
}
