using AssettoCorsaTelemetry.Listener.Services;
using MassTransit;

var builder = Host.CreateApplicationBuilder(args);

var apiBaseUrl = Environment.GetEnvironmentVariable("API_BASE_URL") ?? "http://backend:8080/";

builder.Services.AddHttpClient("listener-api", client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});

var rabbitMqHost = builder.Configuration.GetSection("RabbitMq")["Host"];
var rabbitMqUsername = builder.Configuration.GetSection("RabbitMq")["Username"];
var rabbitMqPassword = builder.Configuration.GetSection("RabbitMq")["Password"];

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(rabbitMqHost, "/", h =>
        {
            h.Username(rabbitMqUsername ?? "telemetry");
            h.Password(rabbitMqPassword ?? "telemetry_dev_password");
        });
    });
});

builder.Services.AddHostedService<ListenerService>();

var host = builder.Build();
host.Run();