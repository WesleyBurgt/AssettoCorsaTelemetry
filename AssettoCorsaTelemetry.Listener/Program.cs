using AssettoCorsaTelemetry.Core.Interfaces;
using AssettoCorsaTelemetry.Core.Services;
using AssettoCorsaTelemetry.Dal.Postgresql;
using AssettoCorsaTelemetry.Dal.Repositories;
using AssettoCorsaTelemetry.Listener.Services;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<IPhysicsDataRepository, PhysicsDataRepository>();
builder.Services.AddScoped<IPhysicsDataService, PhysicsDataService>();

builder.Services.AddHostedService<ListenerService>();

var host = builder.Build();
host.Run();