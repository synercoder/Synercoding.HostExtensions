using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Hosting
{
    /// <summary>
    /// An <see cref="IHost"/> wrapper that supports else and elseif methods
    /// </summary>
    public sealed class ElseExecuteHost : IHost
    {
        private readonly IHost _host;

        internal ElseExecuteHost(IHost host, bool canElseExecute)
        {
            _host = host;
            CanElseExecute = canElseExecute;
        }

        /// <summary>
        /// If <see cref="CanElseExecute"/> is true, an else condition can be executed.
        /// </summary>
        public bool CanElseExecute { get; }

        /// <inheritdoc/>
        public IServiceProvider Services
            => _host.Services;

        /// <inheritdoc/>
        public void Dispose()
            => _host.Dispose();

        /// <inheritdoc/>
        public Task StartAsync(CancellationToken cancellationToken = default)
            => _host.StartAsync(cancellationToken);

        /// <inheritdoc/>
        public Task StopAsync(CancellationToken cancellationToken = default)
            => _host.StopAsync(cancellationToken);

        internal IHost Unwrap()
            => _host;
    }
}
