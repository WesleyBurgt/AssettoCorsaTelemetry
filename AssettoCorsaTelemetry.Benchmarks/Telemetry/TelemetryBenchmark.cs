using MassTransit;
using NBomber.CSharp;
using Response = NBomber.CSharp.Response;

namespace AssettoCorsaTelemetry.Benchmarks.Telemetry;

public class TelemetryBenchmark(IBusControl bus, TelemetryBenchmarkSettings settings)
{    
    public async Task RunAsync()
    {
        await bus.StartAsync();

        try
        {
            var scenario = Scenario.Create(
                    "physics_data_ingestion",
                    async context =>
                    {
                        try
                        {
                            var telemetry = TelemetryFactory.Create();

                            await bus.Publish(telemetry);

                            return Response.Ok();
                        }
                        catch
                        {
                            return Response.Fail();
                        }
                    })
                .WithWarmUpDuration(settings.WarmUp)
                .WithLoadSimulations(
                    Simulation.Inject(
                        rate: settings.MessagesPerSecond,
                        interval: settings.Interval,
                        during: settings.Duration
                    )
                );

            NBomberRunner
                .RegisterScenarios(scenario)
                .WithTestSuite("AssettoCorsaTelemetry")
                .WithTestName("PhysicsDataIngestion")
                .Run();
        }
        finally
        {
            await bus.StopAsync();
        }
    }
}