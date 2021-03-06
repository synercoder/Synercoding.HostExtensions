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
        /// <typeparam name="THost">The <see cref="IHost"/> type</typeparam>
        /// <param name="hostTask">The task that can be awaited to get the host.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="method">The method to execute if the predicate returns true.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<ElseExecuteHost> ExecuteIf<THost>(this Task<THost> hostTask, Func<IHost, bool> predicate, Func<IHost, IHost> method)
            where THost : IHost
        {
            var host = await hostTask;
            return ExecuteIf(host, predicate, method);
        }

        /// <summary>
        /// Execute a task if the predicate returns true.
        /// </summary>
        /// <typeparam name="THost">The <see cref="IHost"/> type</typeparam>
        /// <param name="hostTask">The task that can be awaited to get the host.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="method">The method to execute if the predicate returns true.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<ElseExecuteHost> ExecuteIf<THost>(this Task<THost> hostTask, Func<IHost, Task<bool>> predicate, Func<IHost, IHost> method)
            where THost : IHost
        {
            var host = await hostTask;
            return await ExecuteIf(host, predicate, method);
        }

        /// <summary>
        /// Execute a task if the predicate returns true.
        /// </summary>
        /// <typeparam name="THost">The <see cref="IHost"/> type</typeparam>
        /// <param name="hostTask">The task that can be awaited to get the host.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="method">The method to execute if the predicate returns true.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<ElseExecuteHost> ExecuteIf<THost>(this Task<THost> hostTask, Func<IHost, bool> predicate, Func<IHost, Task<IHost>> method)
            where THost : IHost
        {
            var host = await hostTask;
            return await ExecuteIf(host, predicate, method);
        }

        /// <summary>
        /// Execute a task if the predicate returns true.
        /// </summary>
        /// <typeparam name="THost">The <see cref="IHost"/> type</typeparam>
        /// <param name="hostTask">The task that can be awaited to get the host.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="method">The method to execute if the predicate returns true.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<ElseExecuteHost> ExecuteIf<THost>(this Task<THost> hostTask, Func<IHost, Task<bool>> predicate, Func<IHost, Task<IHost>> method)
            where THost : IHost
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
        public static ElseExecuteHost ExecuteIf(this IHost host, Func<IHost, bool> predicate, Func<IHost, IHost> method)
        {
            return predicate(host)
                ? new ElseExecuteHost(method(host), false)
                : new ElseExecuteHost(host, true);
        }

        /// <summary>
        /// Execute a task if the predicate returns true.
        /// </summary>
        /// <param name="host">The host that will be used to execute the method.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="method">The method to execute if the predicate returns true.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<ElseExecuteHost> ExecuteIf(this IHost host, Func<IHost, Task<bool>> predicate, Func<IHost, IHost> method)
        {
            return await predicate(host)
                ? new ElseExecuteHost(method(host), false)
                : new ElseExecuteHost(host, true);
        }

        /// <summary>
        /// Execute a task if the predicate returns true.
        /// </summary>
        /// <param name="host">The host that will be used to execute the method.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="method">The method to execute if the predicate returns true.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<ElseExecuteHost> ExecuteIf(this IHost host, Func<IHost, bool> predicate, Func<IHost, Task<IHost>> method)
        {
            return predicate(host)
                ? new ElseExecuteHost(await method(host), false)
                : new ElseExecuteHost(host, true);
        }

        /// <summary>
        /// Execute a task if the predicate returns true.
        /// </summary>
        /// <param name="host">The host that will be used to execute the method.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="method">The method to execute if the predicate returns true.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<ElseExecuteHost> ExecuteIf(this IHost host, Func<IHost, Task<bool>> predicate, Func<IHost, Task<IHost>> method)
        {
            return await predicate(host)
                ? new ElseExecuteHost(await method(host), false)
                : new ElseExecuteHost(host, true);
        }
    }
}
