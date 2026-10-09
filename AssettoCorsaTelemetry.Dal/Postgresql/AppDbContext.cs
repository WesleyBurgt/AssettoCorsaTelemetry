using System.Globalization;
using System.Numerics;
using AssettoCorsaTelemetry.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AssettoCorsaTelemetry.Dal.Postgresql;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<PhysicsData> PhysicsDataTable => Set<PhysicsData>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UnassignedPhysicsData>()
            .Property(x => x.CarCoordinates)
            .HasConversion(_vector3Converter);
    }
    
    private readonly ValueConverter<Vector3, List<float>> _vector3Converter = new (
        vector => new List<float> {vector.X, vector.Y, vector.Z },
        floatArray => new Vector3(floatArray[0], floatArray[1], floatArray[2])
    );
}