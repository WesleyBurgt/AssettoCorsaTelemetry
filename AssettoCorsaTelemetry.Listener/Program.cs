using AssettoCorsaTelemetry.Listener.Services;

var builder = Host.CreateApplicationBuilder(args);

var apiBaseUrl = Environment.GetEnvironmentVariable("API_BASE_URL") ?? "http://backend:8080/";

builder.Services.AddHttpClient("listener-api", client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});

builder.Services.AddHostedService<ListenerService>();

var host = builder.Build();
host.Run();