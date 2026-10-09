using AssettoCorsaTelemetry.Listener.Structs;
using AssettoCorsaTelemetry.Listener.Enums;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace AssettoCorsaTelemetry.Listener.Services
{
    public class HandShakeService
    {
        private IPEndPoint _endPoint;
        private UdpClient _udpClient;

        public HandShakeService(IPEndPoint endpoint, UdpClient udpClient)
        {
            _endPoint = endpoint;
            _udpClient = udpClient;
        }

        public async Task SendHandShakeRequestAsync()
        {
            Console.WriteLine($"Sending handshake to {_endPoint.Address}:{_endPoint.Port}...");
            UdpOperation handShake = new UdpOperation
            {
                Identifier = 0,
                Version = 1,
                OperationId = OperationId.Handshake
            };
            byte[] handShakeBytes = handShake.ToByteArray();

            await _udpClient.SendAsync(handShakeBytes, handShakeBytes.Length, _endPoint);
            Console.WriteLine("Handshake sent. Waiting for Assetto Corsa...");
        }

        public async Task GetHandShakeResponseAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _udpClient.ReceiveAsync(cancellationToken);

                Console.WriteLine($"Received {response.Buffer.Length} bytes from {response.RemoteEndPoint}");

                if (response.Buffer.Length == 408)
                {
                    Console.WriteLine();
                    Console.WriteLine("Handshake received!");
                    HandShakeResponse handShakeResponse = ParseHandshake(response.Buffer);
                    DisplayHandshake(handShakeResponse);

                    Console.WriteLine();
                    Console.WriteLine("Subscribing to car telemetry...");

                    UdpOperation subscribe = new UdpOperation
                    {
                        Identifier = 0,
                        Version = 1,
                        OperationId = OperationId.SubscribeUpdate
                    };
                    byte[] subscribeBytes = subscribe.ToByteArray();

                    await _udpClient.SendAsync(subscribeBytes, subscribeBytes.Length, _endPoint);

                    Console.WriteLine("Subscribed to car telemetry");
                }
                else
                {
                    Console.WriteLine($"Unexpected packet size: {response.Buffer.Length}");
                }
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

        private HandShakeResponse ParseHandshake(byte[] data)
        {
            string carName = ReadString(data, 0, 100);
            string driverName = ReadString(data, 100, 100);
            int identifier = BitConverter.ToInt32(data, 200);
            int version = BitConverter.ToInt32(data, 204);
            string trackName = ReadString(data, 208, 100);
            string trackConfig = ReadString(data, 308, 100);

            return new HandShakeResponse
            {
                CarName = carName,
                DriverName = driverName,
                Identifier = identifier,
                Version = version,
                TrackName = trackName,
                TrackConfig = trackConfig
            };
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

        private string ReadString(byte[] data, int offset, int length)
        {
            return Encoding.Unicode.GetString(data, offset, length)
                                   .TrimEnd('\0');
        }
    }
}
