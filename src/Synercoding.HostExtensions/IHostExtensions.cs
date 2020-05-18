using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Hosting
{
    /// <summary>
    /// Extensions for <see cref="IHost"/>
    /// </summary>
    public static class IHostExtensions
    {
        /// <summary>
        /// Runs an application and returns a Task that only completes when the token is  triggered or shutdown is triggered.
        /// </summary>
        /// <param name="hostTask">The task that can be awaited to return the <see cref="IHost"/> to run.</param>
        /// <param name="token">The token to trigger shutdown.</param>
        /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
        public static async Task RunAsync(this Task<IHost> hostTask, CancellationToken token = default)
        {
            var host = await hostTask;

            await host.RunAsync(token);
        }
    }
}
