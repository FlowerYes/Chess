using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Networking.Transport;


public class NetWelcome : NetMessage
{
    public int AssignedTeam { set; get; }

    public NetWelcome() //making the box
    {
        Code = OpCode.WELCOME;
    }
    public NetWelcome(DataStreamReader reader) // receive the box
    {
        Code = OpCode.WELCOME;
        Deserialize(reader);
    }

    public override void Serialize(ref DataStreamWriter writer)
    {
        writer.WriteByte((byte)Code);
        writer.WriteInt((AssignedTeam)); //it has to be int byte not compatible to avoid corruption
    }
    public override void Deserialize(DataStreamReader reader)
    {
        // we already read in the ::On data here we just read in the same order
        AssignedTeam = reader.ReadInt();
    }
    public override void ReceivedOnClient()
    {
        NetUtility.C_WELCOME?.Invoke(this);
    }
    public override void ReceivedOnServer(NetworkConnection cnn)
    {
        NetUtility.S_WELCOME?.Invoke(this, cnn);
    }

}
