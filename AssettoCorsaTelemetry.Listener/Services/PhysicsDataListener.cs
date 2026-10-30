using System.Net.Http.Json;
using AssettoCorsaTelemetry.Listener.Structs;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using AssettoCorsaTelemetry.Dtos;

namespace AssettoCorsaTelemetry.Listener.Services
{
    public class PhysicsDataListener
    {
        private readonly HttpClient _apiClient;
        private readonly UdpClient _udpClient;
        
        private bool _isRunning;
        private List<Task> _runningTasks = [];
        
        public PhysicsDataListener(IHttpClientFactory httpClientFactory, UdpClient udpClient)
        {
            _apiClient = httpClientFactory.CreateClient("listener-api");
            _udpClient = udpClient;
        }

        internal void Start()
        {
            _isRunning = true;
            _ = ProcessCarInfo();
        }

        internal async Task StopAsync()
        {
            _isRunning = false;
            await Task.WhenAll(_runningTasks);
        }

        private async Task ProcessCarInfo()
        {
            while (_isRunning)
            {
                UdpReceiveResult result = await _udpClient.ReceiveAsync();

                if (result.Buffer.Length < 328)
                {
                    Console.WriteLine($"Received packet with unexpected size: {result.Buffer.Length}");
                    continue;
                }
                
                RTCarInfo carInfo = ReadResult(result);
                UnassignedPhysicsDataDto physicsData = MapToPhysicsData(carInfo);
                Task postData = _apiClient.PostAsJsonAsync("listener/addphysicsdata", physicsData);
                _runningTasks.Add(postData);
                _runningTasks.RemoveAll(task => task.IsCompleted);
            }
        }

        private RTCarInfo ReadResult(UdpReceiveResult result)
        {
            byte[] bytes = result.Buffer;

            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            RTCarInfo data = Marshal.PtrToStructure<RTCarInfo>(handle.AddrOfPinnedObject());
            handle.Free();
            return data;
        }

        private UnassignedPhysicsDataDto MapToPhysicsData(RTCarInfo carInfo)
        {
            return new UnassignedPhysicsDataDto()
            {
                Timestamp = DateTimeOffset.UtcNow,
                
                Identifier = carInfo.Identifier,
                
                Size = carInfo.Size,

                SpeedKmh = carInfo.SpeedKmh,
                SpeedMph = carInfo.SpeedMph,
                SpeedMs = carInfo.SpeedMs,

                IsAbsEnabled = carInfo.IsAbsEnabled != 0,
                IsAbsInAction = carInfo.IsAbsInAction != 0,
                IsTcInAction = carInfo.IsTcInAction != 0,
                IsTcEnabled = carInfo.IsTcEnabled != 0,
                InPit = carInfo.InPit != 0,
                IsEngineLimiterOn = carInfo.IsEngineLimiterOn != 0,

                AccGForces = [carInfo.AccGVertical,
                    carInfo.AccGHorizontal, 
                    carInfo.AccGFrontal],

                LapTime = TimeSpan.FromMilliseconds(carInfo.LapTime),
                LapCount = carInfo.LapCount,

                Throttle = carInfo.Throttle,
                Brake = carInfo.Brake,
                Clutch = carInfo.Clutch,
                EngineRpm = carInfo.EngineRPM,
                Steering = carInfo.Steering,

                Gear = carInfo.Gear,

                CgHeight = carInfo.CgHeight,

                WheelAngularSpeed = carInfo.WheelAngularSpeed,
                SlipAngle = carInfo.SlipAngle,
                SlipAngleContactPatch = carInfo.SlipAngleContactPatch,
                SlipRatio = carInfo.SlipRatio,
                TyreSlip = carInfo.TyreSlip,
                NdSlip = carInfo.NdSlip,
                Load = carInfo.Load,
                Dy = carInfo.Dy,
                Mz =  carInfo.Mz,
                TyreDirtyLevel = carInfo.TyreDirtyLevel,
                CamberRad = carInfo.CamberRad,
                TyreRadius = carInfo.TyreRadius,
                TyreLoadedRadius = carInfo.TyreLoadedRadius,
                SuspensionHeight  = carInfo.SuspensionHeight,

                CarPositionNormalized = carInfo.CarPositionNormalized,
                CarSlope = carInfo.CarSlope,

                CarCoordinates = carInfo.CarCoordinates
            };
        }
    }
}
