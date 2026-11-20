namespace AssettoCorsaTelemetry.Benchmarks.Telemetry;

public class TelemetryBenchmarkSettings
{
    public readonly int MessagesPerSecond = 500;
    public readonly TimeSpan Duration = TimeSpan.FromSeconds(30);
    public readonly TimeSpan WarmUp = TimeSpan.FromSeconds(10);
    public readonly TimeSpan Interval = TimeSpan.FromSeconds(1);
}