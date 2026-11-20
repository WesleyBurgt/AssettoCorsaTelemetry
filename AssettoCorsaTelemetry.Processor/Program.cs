using AssettoCorsaTelemetry.Core;
using AssettoCorsaTelemetry.Core.Interfaces;
using AssettoCorsaTelemetry.Core.Services;
using AssettoCorsaTelemetry.Dal.Postgresql;
using AssettoCorsaTelemetry.Dal.Repositories;
using AssettoCorsaTelemetry.Dtos;
using AssettoCorsaTelemetry.Processor;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

var rabbitMq = builder.Configuration.GetSection("RabbitMq");

var rabbitMqHost = rabbitMq["Host"] ?? "localhost";
var rabbitMqUsername = rabbitMq["Username"] ?? "telemetry";
var rabbitMqPassword = rabbitMq["Password"] ?? "telemetry_dev_password";

var connectionString = builder.Configuration
                           .GetConnectionString("DefaultConnection")
                       ?? throw new ArgumentNullException("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.Configure<AppSettings>(options =>
{
    options.ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
});

builder.Services.AddScoped<AppSettings>();
builder.Services.AddScoped<IPhysicsDataRepository, PhysicsDataRepository>();
builder.Services.AddScoped<IPhysicsDataService, PhysicsDataService>();
builder.Services.AddScoped<ITrackRepository, TrackRepository>();
builder.Services.AddScoped<ITrackService, TrackService>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<ISessionService, SessionService>();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<PhysicsDataBatchConsumer>(cfg =>
    {
        cfg.Options<BatchOptions>(options => options
            .SetMessageLimit(1000)
            .SetTimeLimit(TimeSpan.FromMilliseconds(250))
            .SetConcurrencyLimit(1)
            .GroupBy<TelemetryReceived, Guid>(
                context => context.Message.Data.SessionId));
    });
    
    x.AddConsumer<SessionBatchConsumer>(cfg =>
    {
        cfg.Options<BatchOptions>(options => options
            .SetMessageLimit(10)
            .SetTimeLimit(TimeSpan.FromMilliseconds(1000))
            .SetConcurrencyLimit(1));
    });

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(rabbitMqHost, "/", h =>
        {
            h.Username(rabbitMqUsername);
            h.Password(rabbitMqPassword);
        });

        cfg.ConfigureEndpoints(context);
    });
});

var host = builder.Build();
await host.RunAsync();