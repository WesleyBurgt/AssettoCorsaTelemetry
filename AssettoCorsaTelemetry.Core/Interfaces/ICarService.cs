using AssettoCorsaTelemetry.Core.Entities;

namespace AssettoCorsaTelemetry.Core.Interfaces;

public interface ICarService
{
    public Task<Car> GetCarAsync(Guid userId, string modelName, CancellationToken cancellationToken = default);
    public Task EnsureCarExistsAsync(Guid userId, string modelName, CancellationToken cancellationToken = default);
}