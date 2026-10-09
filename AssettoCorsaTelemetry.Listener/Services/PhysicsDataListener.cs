using AssettoCorsaTelemetry.Core.Events;
using AssettoCorsaTelemetry.Listener.Structs;
using System.Net.Sockets;
using System.Numerics;
using System.Runtime.InteropServices;
using AssettoCorsaTelemetry.Core.Entities;
using AssettoCorsaTelemetry.Core.Interfaces;

namespace AssettoCorsaTelemetry.Listener.Services
{
    public class PhysicsDataListener(UdpClient udpClient, IPhysicsDataService service) : IPhysicsDataListener
    {
        public event EventHandler<UnassignedPhysicsDataInfoEventArgs>? PhysicsDataInfoUpdated;
        
        private bool _isRunning;
        
        protected virtual void OnPhysicsDataInfoUpdated(UnassignedPhysicsDataInfoEventArgs e)
        {
            PhysicsDataInfoUpdated?.Invoke(this, e);
        }

        internal void Start()
        {
            _isRunning = true;
            _ = ProcessCarInfo();
        }

        internal void Stop()
        {
            _isRunning = false;
        }

        private async Task ProcessCarInfo()
        {
            while (_isRunning)
            {
                UdpReceiveResult result = await udpClient.ReceiveAsync();

                if (result.Buffer.Length < 328)
                {
                    Console.WriteLine($"Received packet with unexpected size: {result.Buffer.Length}");
                    continue;
                }
                
                RTCarInfo carInfo = ReadResult(result);
                UnassignedPhysicsData physicsData = MapToPhysicsData(carInfo);
                OnPhysicsDataInfoUpdated(new UnassignedPhysicsDataInfoEventArgs(physicsData));
                await service.AddPhysicsDataAsync(physicsData);
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
        
        private UnassignedPhysicsData MapToPhysicsData(RTCarInfo carInfo)
        {
            return new UnassignedPhysicsData()
            {
                Id = Guid.NewGuid(),
                
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

                AccGForces = new AccGForces
                {
                    Id = Guid.NewGuid(),
                    Vertical = carInfo.AccGVertical,
                    Horizontal = carInfo.AccGHorizontal,
                    Frontal = carInfo.AccGFrontal,
                },

                LapTime = TimeSpan.FromMilliseconds(carInfo.LapTime),
                LapCount = carInfo.LapCount,

                Throttle = carInfo.Throttle,
                Brake = carInfo.Brake,
                Clutch = carInfo.Clutch,
                EngineRpm = carInfo.EngineRPM,
                Steering = carInfo.Steering,

                Gear = carInfo.Gear,

                CgHeight = carInfo.CgHeight,

                WheelAngularSpeed = MapToWheelData(carInfo.WheelAngularSpeed),
                SlipAngle = MapToWheelData(carInfo.SlipAngle),
                SlipAngleContactPatch = MapToWheelData(carInfo.SlipAngleContactPatch),
                SlipRatio = MapToWheelData(carInfo.SlipRatio),
                TyreSlip = MapToWheelData(carInfo.TyreSlip),
                NdSlip = MapToWheelData(carInfo.NdSlip),
                Load = MapToWheelData(carInfo.Load),
                Dy = MapToWheelData(carInfo.Dy),
                Mz =  MapToWheelData(carInfo.Mz),
                TyreDirtyLevel = MapToWheelData(carInfo.TyreDirtyLevel),
                CamberRad = MapToWheelData(carInfo.CamberRad),
                TyreRadius = MapToWheelData(carInfo.TyreRadius),
                TyreLoadedRadius = MapToWheelData(carInfo.TyreLoadedRadius),
                SuspensionHeight  = MapToWheelData(carInfo.SuspensionHeight),

                CarPositionNormalized = carInfo.CarPositionNormalized,
                CarSlope = carInfo.CarSlope,

                CarCoordinates = new Vector3
                {
                    X = carInfo.CarCoordinates[0],
                    Y = carInfo.CarCoordinates[1],
                    Z = carInfo.CarCoordinates[2]
                }
            };
        }

        private WheelData MapToWheelData(float[] floatArray)
        {
            if (floatArray.Length != 4)
                throw new InvalidOperationException("Invalid amount of wheels");

            return new WheelData
            {
                Id = Guid.NewGuid(),
                FrontLeft = floatArray[0],
                FrontRight = floatArray[1],
                RearLeft = floatArray[2],
                RearRight = floatArray[3]
            };
        }
    }
}
