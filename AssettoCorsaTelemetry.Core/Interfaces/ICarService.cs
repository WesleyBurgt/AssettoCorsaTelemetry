using AssettoCorsaTelemetry.Core.Entities;

namespace AssettoCorsaTelemetry.Core.Interfaces;

public interface ICarService
{
    public Task<Car> EnsureCarExistsAsync(Guid userId, string modelName, CancellationToken cancellationToken = default);
}