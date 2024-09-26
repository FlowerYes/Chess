using Unity.Networking.Transport;
using UnityEngine;


public class NetMessage 
{
    public OpCode Code { set; get; }


    public virtual void Serialize(ref DataStreamWriter writer)
    {
        writer.WriteByte((byte)Code);//write package
    }
    public virtual void Deserialize( DataStreamReader reader) //unpack
    {

    }
    public virtual void ReceivedOnClient()
    {

    }
    public virtual void ReceivedOnServer(NetworkConnection cnn) //who sent the mess??
    { 

    }
}
