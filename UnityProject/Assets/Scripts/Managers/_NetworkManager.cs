using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//Create a class for the message you send to the Client
public class RegisterHostMessage : MessageBase
{
    public string m_Name;
    public string m_Comment;
}


public class _NetworkManager : MonoBehaviour
{
    NetworkClient client;

    NetworkConnection connection;

    void DoConnect()
    {
        client = new NetworkClient();
        client.Connect("127.0.0.1", 9001);
    }

    private void Start()
    {
        NetworkServer.Reset();
        NetworkServer.Listen(9001);
        DoConnect();

    }

    private void Update()
    {
        //Debug.Log(NetworkServer.connections);
        //Debug.Log(client.isConnected);

 
    }
}