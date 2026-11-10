using System.Numerics;
using AssettoCorsaTelemetry.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AssettoCorsaTelemetry.Dal.Postgresql;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<PhysicsData> PhysicsDataTable => Set<PhysicsData>();
    public DbSet<Session> Sessions => Set<Session>();
    public DbSet<Car> Cars => Set<Car>();
    public DbSet<Track> Tracks => Set<Track>();
    
    private readonly ValueConverter<Vector3, List<float>> _vector3Converter = new (
        vector => new List<float> {vector.X, vector.Y, vector.Z },
        floatArray => new Vector3(floatArray[0], floatArray[1], floatArray[2])
    );
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PhysicsData>(entity =>
        {
            entity.ToTable("PhysicsData");

            entity.HasKey(x => new { x.Timestamp, x.Id });

            entity.Property(x => x.Timestamp)
                .IsRequired();

            entity.Property(x => x.CarCoordinates).HasConversion(_vector3Converter);

            entity.OwnsOne(x => x.AccGForces);
            entity.OwnsOne(x => x.CamberRad);
            entity.OwnsOne(x => x.Dy);
            entity.OwnsOne(x => x.Load);
            entity.OwnsOne(x => x.Mz);
            entity.OwnsOne(x => x.NdSlip);
            entity.OwnsOne(x => x.SlipAngle);
            entity.OwnsOne(x => x.SlipAngleContactPatch);
            entity.OwnsOne(x => x.SlipRatio);
            entity.OwnsOne(x => x.SuspensionHeight);
            entity.OwnsOne(x => x.TyreDirtyLevel);
            entity.OwnsOne(x => x.TyreLoadedRadius);
            entity.OwnsOne(x => x.TyreRadius);
            entity.OwnsOne(x => x.TyreSlip);
            entity.OwnsOne(x => x.WheelAngularSpeed);
        });
    }
}