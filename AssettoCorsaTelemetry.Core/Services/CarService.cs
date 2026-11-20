using AssettoCorsaTelemetry.Core.Entities;
using AssettoCorsaTelemetry.Core.Interfaces;

namespace AssettoCorsaTelemetry.Core.Services;

public class CarService(ICarRepository repository) : ICarService
{
    public async Task<Car> EnsureCarExistsAsync(Guid userId, string modelName, CancellationToken cancellationToken = default)
    {
        try
        {
            Car car = await repository.GetCarAsync(userId, modelName, cancellationToken);
            return car;
        }
        catch (KeyNotFoundException) //adds if it does not exist
        {
            Car car = new Car
            {
                Id = Guid.NewGuid(),
                ModelName = modelName,
                UserId = userId
            };
            await repository.AddCarAsync(car, cancellationToken);
            return car;
        }
    }
}