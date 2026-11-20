using AssettoCorsaTelemetry.Dtos;

namespace AssettoCorsaTelemetry.Benchmarks.Telemetry;

public static class TelemetryFactory
{
    private static float[] RandomFloatArray(int floatCount, float min, float max)
    {
        List<float> result = [];
        for (int i = 0; i < floatCount; i++)
        {
            result.Add(RandomFloat(min, max));
        }
        return result.ToArray();
    }
    
    private static float RandomFloat(float min, float max)
    {
        float randomDecimal = Random.Shared.NextSingle();
        int randomDecimalMax = 1;
        if (min + randomDecimalMax > max)
        {
            // result is already too large
            float diff = max - min;
            return min + (randomDecimal * diff);
        }

        int minInt = (int)Math.Floor(min);
        int maxInt = (int)Math.Ceiling(max) - randomDecimalMax;
        int randomInt = RandomInt(minInt, maxInt);
        float result = randomInt + randomDecimal;
        return result;
    }
    
    private static int RandomInt(int min, int max) => Random.Shared.Next(min, max);
    
    private static bool RandomBool() => Random.Shared.Next(0, 1) == 0;

    public static TelemetryReceived Create()
    {
        Guid sessionId = Guid.NewGuid();
        float speedKmh = RandomFloat(-50, 300);
        return new TelemetryReceived
        {
            MessageId = Guid.NewGuid(),
            Data = new PhysicsDataDto
            {
                AccGForces = RandomFloatArray(3, -5, 5),
                Brake = RandomFloat(0, 1),
                CamberRad = RandomFloatArray(4, -0.4f, 0.2f),
                CarCoordinates =  RandomFloatArray(3, -1000, 1000),
                CarPositionNormalized = RandomFloat(0, 1),
                CarSlope = RandomFloat(0, 1),
                CgHeight = RandomFloat(0, 1),
                Clutch =  RandomFloat(0, 1),
                Dy = RandomFloatArray(4, 0, 1.8f),
                EngineRpm =  RandomFloat(800, 7500),
                Gear = RandomInt(0, 7),
                Identifier = 97,
                InPit = false,
                IsAbsEnabled = true,
                IsAbsInAction = RandomBool(),
                IsEngineLimiterOn = false,
                IsTcEnabled = true,
                IsTcInAction = RandomBool(),
                LapCount = RandomInt(0, 10),
                LapTime = TimeSpan.FromMilliseconds(RandomInt(0, 120000)),
                Load = RandomFloatArray(4, 0, 20000),
                Mz = RandomFloatArray(4, -2300, 1800),
                NdSlip = RandomFloatArray(4, 0, 10),
                SessionId = sessionId,
                SlipAngleContactPatch = [0,0,0,0],
                SlipAngle = RandomFloatArray(4, -11.5f, 20),
                SlipRatio =  RandomFloatArray(4, -1, 0.03f),
                SpeedKmh = speedKmh,
                SpeedMph =  speedKmh * 0.621371f,
                SpeedMs =  speedKmh / 3.6f,
                Steering =  RandomFloat(-320, 320),
                SuspensionHeight = RandomFloatArray(4, 0.005f, 0.08f),
                Throttle =  RandomFloat(0, 1),
                Timestamp = DateTimeOffset.Now,
                TyreDirtyLevel = RandomFloatArray(4, 0, 2.5f),
                TyreLoadedRadius =  RandomFloatArray(4, 0.25f, 0.34f),
                TyreRadius =  [0.34f,0.34f,0.3525f,0.3525f],
                TyreSlip = [0,0,0,0],
                WheelAngularSpeed = RandomFloatArray(4, -0.4f, 226.5f)
            }
        };
    }
}