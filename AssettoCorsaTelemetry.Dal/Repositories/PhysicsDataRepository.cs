using AssettoCorsaTelemetry.Core.Entities;
using AssettoCorsaTelemetry.Core.Interfaces;
using AssettoCorsaTelemetry.Dal.Postgresql;

namespace AssettoCorsaTelemetry.Dal.Repositories;

public class PhysicsDataRepository(AppDbContext db) : IPhysicsDataRepository
{
    public async Task AddPhysicsData(PhysicsData data)
    {
        db.PhysicsDataTable.Add(data);
        await db.SaveChangesAsync();
    }
}