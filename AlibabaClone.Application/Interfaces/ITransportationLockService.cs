namespace AlibabaClone.Application.Interfaces
{
    public interface ITransportationLockService
    {
        Task<IDisposable> AcquireLockAsync(long transportationId);
    }
}
