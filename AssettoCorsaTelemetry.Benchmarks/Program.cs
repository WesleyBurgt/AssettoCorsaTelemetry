using AssettoCorsaTelemetry.Benchmarks.Telemetry;
using MassTransit;

var rabbitMqHost = Environment.GetEnvironmentVariable("RABBITMQ_HOST")!;
var rabbitMqUser = Environment.GetEnvironmentVariable("RABBITMQ_USER")!;
var rabbitMqPassword = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD")!;

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host(rabbitMqHost, "/", host =>
    {
        host.Username(rabbitMqUser);
        host.Password(rabbitMqPassword);
    });
});
var telemetrySettings = new TelemetryBenchmarkSettings();

var telemetryBenchmark = new TelemetryBenchmark(busControl, telemetrySettings);
await telemetryBenchmark.RunAsync();