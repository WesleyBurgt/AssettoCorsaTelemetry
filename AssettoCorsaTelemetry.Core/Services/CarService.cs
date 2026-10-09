using AssettoCorsaTelemetry.Core.Entities;
using AssettoCorsaTelemetry.Core.Interfaces;

namespace AssettoCorsaTelemetry.Core.Services;

public class CarService(ICarRepository repository)
{
    public Car GetCar(Guid userId, string model)
    {
        return repository.GetCar(userId, model);
    }
}