using System.Net;
using System.Net.Sockets;

namespace AssettoCorsaTelemetry.Listener.Services;

public class ListenerService(IHttpClientFactory httpClientFactory) : IHostedService
{
    private PhysicsDataListener? _physicsDataListener;
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var acIp = Environment.GetEnvironmentVariable("AC_IP") ?? "host.docker.internal";
        var acPortString = Environment.GetEnvironmentVariable("AC_IP") ?? "9996";
        int acPort = Convert.ToInt32(acPortString);

        IPHostEntry hostEntry = await Dns.GetHostEntryAsync(acIp, cancellationToken);
        IPAddress address = hostEntry.AddressList.First();

        IPEndPoint endpoint = new(address, acPort); 
        UdpClient udpClient = new UdpClient();

        HandShakeService handShakeService = new HandShakeService(endpoint, udpClient);
        await handShakeService.SendHandShakeRequestAsync();

        await handShakeService.GetHandShakeResponseAsync(cancellationToken);

        _physicsDataListener = new PhysicsDataListener(httpClientFactory, udpClient);
        _physicsDataListener.Start();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _physicsDataListener?.StopAsync()!;
    }
}