using AssettoCorsaTelemetry.Core.Entities;

namespace AssettoCorsaTelemetry.Core.Interfaces;

public interface ICarRepository
{
    public Car GetCar(Guid userId, string model);
}