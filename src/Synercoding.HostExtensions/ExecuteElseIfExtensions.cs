using System;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Hosting
{
    /// <summary>
    /// Extensions for the host to enable executions of code based on conditions.
    /// </summary>
    public static class ExecuteElseIfExtensions
    {
        /// <summary>
        /// Execute a task if the predicate returns true.
        /// </summary>
        /// <param name="hostTask">The task that can be awaited to get the host.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="method">The method to execute if the predicate returns true.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<ElseExecuteHost> ElseIf(this Task<ElseExecuteHost> hostTask, Func<IHost, bool> predicate, Func<IHost, IHost> method)
        {
            var host = await hostTask;
            return ElseIf(host, predicate, method);
        }

        /// <summary>
        /// Execute a task if the predicate returns true.
        /// </summary>
        /// <param name="hostTask">The task that can be awaited to get the host.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="method">The method to execute if the predicate returns true.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<ElseExecuteHost> ElseIf(this Task<ElseExecuteHost> hostTask, Func<IHost, bool> predicate, Func<IHost, Task<IHost>> method)
        {
            var host = await hostTask;
            return await ElseIf(host, predicate, method);
        }

        /// <summary>
        /// Execute a task if the predicate returns true.
        /// </summary>
        /// <param name="hostTask">The task that can be awaited to get the host.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="method">The method to execute if the predicate returns true.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<ElseExecuteHost> ElseIf(this Task<ElseExecuteHost> hostTask, Func<IHost, Task<bool>> predicate, Func<IHost, Task<IHost>> method)
        {
            var host = await hostTask;
            return await ElseIf(host, predicate, method);
        }

        /// <summary>
        /// Execute a task if the predicate returns true.
        /// </summary>
        /// <param name="host">The host that will be used to execute the method.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="method">The method to execute if the predicate returns true.</param>
        /// <returns>The host.</returns>
        public static ElseExecuteHost ElseIf(this ElseExecuteHost host, Func<IHost, bool> predicate, Func<IHost, IHost> method)
        {
            if (!host.CanElseExecute)
                return host;

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
        public static async Task<ElseExecuteHost> ElseIf(this ElseExecuteHost host, Func<IHost, bool> predicate, Func<IHost, Task<IHost>> method)
        {
            if (!host.CanElseExecute)
                return host;

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
        public static async Task<ElseExecuteHost> ElseIf(this ElseExecuteHost host, Func<IHost, Task<bool>> predicate, Func<IHost, Task<IHost>> method)
        {
            if (!host.CanElseExecute)
                return host;

            return await predicate(host)
                ? new ElseExecuteHost(await method(host), false)
                : new ElseExecuteHost(host, true);
        }
    }
}
