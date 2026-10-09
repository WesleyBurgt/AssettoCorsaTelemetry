using AssettoCorsaTelemetry.Listener.Enums;

namespace AssettoCorsaTelemetry.Listener.Structs
{
    public struct UdpOperation
    {
        public int Identifier;
        public int Version;
        public OperationId OperationId;

        public byte[] ToByteArray()
        {
            byte[] result = new byte[12];
            BitConverter.GetBytes(Identifier).CopyTo(result, 0);
            BitConverter.GetBytes(Version).CopyTo(result, 4);
            BitConverter.GetBytes((int)OperationId).CopyTo(result, 8);
            return result;
        }
    }
}
