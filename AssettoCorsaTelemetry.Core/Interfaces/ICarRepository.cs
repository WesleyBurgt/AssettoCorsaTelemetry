using AssettoCorsaTelemetry.Core.Entities;

namespace AssettoCorsaTelemetry.Core.Interfaces;

public interface ICarRepository
{
    public Task<Car> GetCarAsync(Guid userId, string modelName, CancellationToken cancellationToken = default);
    public Task AddCarAsync(Car car, CancellationToken cancellationToken = default);
}