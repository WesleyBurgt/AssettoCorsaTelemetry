using AssettoCorsaTelemetry.Core.Entities;
using AssettoCorsaTelemetry.Core.Interfaces;
using AssettoCorsaTelemetry.Dal.Postgresql;
using Microsoft.EntityFrameworkCore;

namespace AssettoCorsaTelemetry.Dal.Repositories;

public class CarRepository(AppDbContext db) : ICarRepository
{
    public async Task<Car> GetCarAsync(Guid userId, string modelName, CancellationToken cancellationToken = default)
    {
        Car? result = await db.Cars.FirstOrDefaultAsync(car => car.UserId == userId && car.ModelName == modelName, 
                                                        cancellationToken);
        if (result == null)
        {
            throw new KeyNotFoundException($"car {modelName} not found for user {userId}");
        }
        return result;
    }

    public async Task AddCarAsync(Car car, CancellationToken cancellationToken = default)
    {
        db.Cars.Add(car);
        await db.SaveChangesAsync(cancellationToken);
    }
}