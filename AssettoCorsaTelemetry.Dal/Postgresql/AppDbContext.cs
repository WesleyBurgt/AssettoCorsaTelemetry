using System.Numerics;
using AssettoCorsaTelemetry.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AssettoCorsaTelemetry.Dal.Postgresql;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<PhysicsData> PhysicsDataTable => Set<PhysicsData>();
    public DbSet<Session> Sessions => Set<Session>();
    
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

            entity.OwnsOne(x => x.Data, data =>
            {
                data.Property(x => x.Timestamp);

                data.Property(x => x.CarCoordinates)
                    .HasConversion(_vector3Converter);

                data.OwnsOne(x => x.AccGForces);
                data.OwnsOne(x => x.CamberRad);
                data.OwnsOne(x => x.Dy);
                data.OwnsOne(x => x.Load);
                data.OwnsOne(x => x.Mz);
                data.OwnsOne(x => x.NdSlip);
                data.OwnsOne(x => x.SlipAngle);
                data.OwnsOne(x => x.SlipAngleContactPatch);
                data.OwnsOne(x => x.SlipRatio);
                data.OwnsOne(x => x.SuspensionHeight);
                data.OwnsOne(x => x.TyreDirtyLevel);
                data.OwnsOne(x => x.TyreLoadedRadius);
                data.OwnsOne(x => x.TyreRadius);
                data.OwnsOne(x => x.TyreSlip);
                data.OwnsOne(x => x.WheelAngularSpeed);
            });

            entity.Navigation(x => x.Data).IsRequired();
        });
    }
}