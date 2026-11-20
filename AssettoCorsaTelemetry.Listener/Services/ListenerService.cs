using System.Net;
using System.Net.Sockets;
using MassTransit;

namespace AssettoCorsaTelemetry.Listener.Services;

public class ListenerService(IPublishEndpoint publishEndpoint) : IHostedService
{
    private PhysicsDataListener? _physicsDataListener;
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var acIp = Environment.GetEnvironmentVariable("AC_IP") ?? "host.docker.internal";
        var acPortString = Environment.GetEnvironmentVariable("AC_PORT") ?? "9996";
        int acPort = Convert.ToInt32(acPortString);

        IPHostEntry hostEntry = await Dns.GetHostEntryAsync(acIp, cancellationToken);
        IPAddress address = hostEntry.AddressList.First();

        IPEndPoint endpoint = new(address, acPort); 
        UdpClient udpClient = new UdpClient();

        HandShakeService handShakeService = new HandShakeService(publishEndpoint, endpoint, udpClient);
        await handShakeService.SendHandShakeRequestAsync();

        await handShakeService.GetHandShakeResponseAsync(cancellationToken);

        _physicsDataListener = new PhysicsDataListener(publishEndpoint, udpClient, handShakeService.SessionId);
        _physicsDataListener.Start();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _physicsDataListener?.StopAsync()!;
    }
}