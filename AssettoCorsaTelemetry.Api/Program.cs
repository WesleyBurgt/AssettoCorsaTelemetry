using AssettoCorsaTelemetry.Core;
using AssettoCorsaTelemetry.Core.Interfaces;
using AssettoCorsaTelemetry.Core.Services;
using AssettoCorsaTelemetry.Dal.Postgresql;
using AssettoCorsaTelemetry.Dal.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.Configure<AppSettings>(options =>
{
    options.ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
});

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<ITrackRepository, TrackRepository>();
builder.Services.AddScoped<ITrackService, TrackService>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ListenerPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:8082")
            .AllowCredentials()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("ListenerPolicy");
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
