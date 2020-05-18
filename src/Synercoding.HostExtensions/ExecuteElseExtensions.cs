using System;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Hosting
{
    /// <summary>
    /// Extensions for the host to enable executions of code based on conditions.
    /// </summary>
    public static class ExecuteElseExtensions
    {
        /// <summary>
        /// Execute a task if the predicate returns true.
        /// </summary>
        /// <param name="hostTask">The task that can be awaited to get the host.</param>
        /// <param name="method">The method to execute if the predicate returns true.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<IHost> Else(this Task<ElseExecuteHost> hostTask, Func<IHost, IHost> method)
        {
            var host = await hostTask;
            return Else(host, method);
        }

        /// <summary>
        /// Execute a task if the predicate returns true.
        /// </summary>
        /// <param name="hostTask">The task that can be awaited to get the host.</param>
        /// <param name="method">The method to execute if the predicate returns true.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<IHost> Else(this Task<ElseExecuteHost> hostTask, Func<IHost, Task<IHost>> method)
        {
            var host = await hostTask;
            return await Else(host, method);
        }

        /// <summary>
        /// Execute a task if the predicate returns true.
        /// </summary>
        /// <param name="host">The host that will be used to execute the method.</param>
        /// <param name="method">The method to execute if the predicate returns true.</param>
        /// <returns>The host.</returns>
        public static IHost Else(this ElseExecuteHost host, Func<IHost, IHost> method)
        {
            if (!host.CanElseExecute)
                return host.Unwrap();

            return method(host);
        }

        /// <summary>
        /// Execute a task if the predicate returns true.
        /// </summary>
        /// <param name="host">The host that will be used to execute the method.</param>
        /// <param name="method">The method to execute if the predicate returns true.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<IHost> Else(this ElseExecuteHost host, Func<IHost, Task<IHost>> method)
        {
            if (!host.CanElseExecute)
                return host.Unwrap();

            return await method(host);
        }
    }
}
