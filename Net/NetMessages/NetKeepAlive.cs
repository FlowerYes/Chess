using Unity.Networking.Transport;

public class NetKeepAlive : NetMessage
{
    public NetKeepAlive() //making the box
    {
        Code = OpCode.KEEP_ALIVE;
    }
    public NetKeepAlive(DataStreamReader reader) // receive the box
    {
        Code = OpCode.KEEP_ALIVE;
        Deserialize(reader);
    }
    public override void Serialize(ref DataStreamWriter writer)
    {
        writer.WriteByte((byte)Code); //operation code write 
    }
    public override void Deserialize(DataStreamReader reader)
    {
        // we don't have to deserialize anything since it's a keep alive message
    }

    public override void ReceivedOnClient()
    {
        NetUtility.C_KEEP_ALIVE?.Invoke(this);
    }
    public override void ReceivedOnServer(NetworkConnection cnn) 
    { 
        NetUtility.S_KEEP_ALIVE?.Invoke(this, cnn);
    }
}
