using AssettoCorsaTelemetry.Listener.Structs;
using AssettoCorsaTelemetry.Listener.Enums;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace AssettoCorsaTelemetry.Listener.Services
{
    public class HandShakeService
    {
        private readonly IPEndPoint _endPoint;
        private readonly UdpClient _udpClient;
        private readonly byte[] _handShakeOperationBytes;
        private readonly byte[] _subscribePhysicsOperationBytes;

        public HandShakeService(IPEndPoint endpoint, UdpClient udpClient)
        {
            _endPoint = endpoint;
            _udpClient = udpClient;
            
            UdpOperation handShake = new UdpOperation
            {
                Identifier = 1,
                Version = 1,
                OperationId = OperationId.Handshake
            };
            _handShakeOperationBytes = handShake.ToByteArray();
            UdpOperation subscribe = new UdpOperation
            {
                Identifier = 1,
                Version = 1,
                OperationId = OperationId.SubscribeUpdate
            };
            _subscribePhysicsOperationBytes = subscribe.ToByteArray();
        }

        public async Task SendHandShakeRequestAsync()
        {
            Console.WriteLine($"Sending handshake to {_endPoint.Address}:{_endPoint.Port}...");
            await _udpClient.SendAsync(_handShakeOperationBytes, _handShakeOperationBytes.Length, _endPoint);
            Console.WriteLine("Handshake sent. Waiting for Assetto Corsa...");
        }

        public async Task GetHandShakeResponseAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                UdpReceiveResult response = await _udpClient.ReceiveAsync(cancellationToken);

                Console.WriteLine($"Received {response.Buffer.Length} bytes from {response.RemoteEndPoint}");

                if (response.Buffer.Length != 408)
                {
                    Console.WriteLine($"Unexpected packet size: {response.Buffer.Length}");
                    return;
                }

                Console.WriteLine();
                Console.WriteLine("Handshake received!");
                HandShakeResponse handShakeResponse = ReadResult(response);
                DisplayHandshake(handShakeResponse);

                Console.WriteLine();
                Console.WriteLine("Subscribing to car telemetry...");
                await _udpClient.SendAsync(_subscribePhysicsOperationBytes, _subscribePhysicsOperationBytes.Length, _endPoint);
                Console.WriteLine("Subscribed to car telemetry");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine();
                Console.WriteLine("Timed out waiting for Assetto Corsa.");
                Console.WriteLine();
                Console.WriteLine("Check:");
                Console.WriteLine("  - Assetto Corsa is running");
                Console.WriteLine("  - You are actually inside a driving session");
                Console.WriteLine($"  - IP is {_endPoint.Address} if AC is on this PC");
                Console.WriteLine($"  - UDP port is {_endPoint.Port}");
            }
        }
        
        private HandShakeResponse ReadResult(UdpReceiveResult result)
        {
            byte[] bytes = result.Buffer;

            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            HandShakeResponse data = Marshal.PtrToStructure<HandShakeResponse>(handle.AddrOfPinnedObject());
            handle.Free();
            return data;
        }

        private void DisplayHandshake(HandShakeResponse handShakeResponse)
        {
            Console.WriteLine($"  Car:        {handShakeResponse.CarName}");
            Console.WriteLine($"  Driver:     {handShakeResponse.DriverName}");
            Console.WriteLine($"  Track:      {handShakeResponse.TrackName}");
            Console.WriteLine($"  Track config:{handShakeResponse.TrackConfig}");
            Console.WriteLine($"  Identifier:  {handShakeResponse.Identifier}");
            Console.WriteLine($"  Version:     {handShakeResponse.Version}");
        }
    }
}
