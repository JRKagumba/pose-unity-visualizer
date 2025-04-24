using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class UDPReceiver : MonoBehaviour
{
    UdpClient client;
    public int port = 5005;
    public string lastReceivedUDPPacket = "";

    void Start()
    {
        client = new UdpClient(port);
        client.BeginReceive(new AsyncCallback(OnReceive), null);
        Debug.Log($"Listening for UDP data on port {port}");
    }

    void OnReceive(System.IAsyncResult result)
    {
        IPEndPoint ip = new IPEndPoint(IPAddress.Any, port);
        byte[] data = client.EndReceive(result, ref ip);
        lastReceivedUDPPacket = Encoding.UTF8.GetString(data);
        Debug.Log($"Received: {lastReceivedUDPPacket}");

        // Keep listening
        client.BeginReceive(new AsyncCallback(OnReceive), null);
    }
}
