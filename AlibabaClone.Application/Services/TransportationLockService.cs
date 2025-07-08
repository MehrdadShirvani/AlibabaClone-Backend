using AlibabaClone.Application.Interfaces;
using System.Collections.Concurrent;

namespace AlibabaClone.Application.Services
{
    public class TransportationLockService : ITransportationLockService
    {
        private readonly ConcurrentDictionary<long, SemaphoreSlim> _locks = new();
        public async Task<IDisposable> AcquireLockAsync(long transportationId)
        {
            var semaphore = _locks.GetOrAdd(transportationId, new SemaphoreSlim(1,1));
            await semaphore.WaitAsync();
            return new Releaser(() => semaphore.Release());
        }

        private class Releaser : IDisposable {
            private readonly Action _release;
            public Releaser(Action release) { _release = release; }
            public void Dispose() => _release();
        }

    }
}
