using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Networking.Transport;
using System;


public enum OpCode
{
    KEEP_ALIVE = 1,
    WELCOME = 2,
    START_GAME = 3,
    MAKE_MOVE = 4,
    REMATCH = 5,
}

public static class NetUtility 
{
    public static void OnData(DataStreamReader stream , NetworkConnection cnn, Server server = null) // when receive
    {
        NetMessage msg = null; // null to see
        var opCode = (OpCode)stream.ReadByte(); //read the msg
        switch(opCode) // what enum is it???
        {
            case OpCode.KEEP_ALIVE: msg = new NetKeepAlive(stream); break;
            case OpCode.WELCOME: msg = new NetWelcome(stream); break;
            case OpCode.START_GAME:  msg = new NetStartGame(stream); break;
            case OpCode.MAKE_MOVE : msg = new NetMakeMove(stream); break;
            case OpCode.REMATCH: msg = new NetRematch(stream); break;
            default:
                Debug.LogError("Message received no OpCode");
                break;
        }
        if (server != null)
        {
            msg.ReceivedOnServer(cnn);
        }
        else 
            msg.ReceivedOnClient();
    }




    //Net messages C = client , S= server
    public static Action<NetMessage> C_KEEP_ALIVE;
    public static Action<NetMessage> C_WELCOME;
    public static Action<NetMessage> C_START_GAME;
    public static Action<NetMessage> C_MAKE_MOVE;
    public static Action<NetMessage> C_REMATCH;
    public static Action<NetMessage, NetworkConnection> S_KEEP_ALIVE;
    public static Action<NetMessage, NetworkConnection> S_WELCOME;
    public static Action<NetMessage, NetworkConnection> S_START_GAME;
    public static Action<NetMessage, NetworkConnection> S_MAKE_MOVE;
    public static Action<NetMessage, NetworkConnection> S_REMATCH;



}
