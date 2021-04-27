using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.IO;
using UnityEngine.UI;
using System;

public class Client : MonoBehaviour
{
    public GameObject chatContainer;
    public GameObject messagePrefab;
    public GameObject text;
    private bool socketReady;
    private TcpClient socket;
    private NetworkStream stream;
    private StreamWriter writer;
    private StreamReader reader;
    public string ClientName;

    public void ConnectToServer()
    {
        if (socketReady)
            return;
        string host = "127.0.0.1";
        int port = 28000;
        

       
        
        // create the socket
        try
        {
            socket = new TcpClient(host,port);
            stream = socket.GetStream();
            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);
            socketReady = true;
            Debug.Log("We connected");
            Debug.Log("On port " + port);
        }
        catch(Exception e)
        {
            Debug.Log("Socket Error: " + e.Message);
        }
    }

    private void Update()
    {
        if (socketReady)
        {
            if (stream.DataAvailable)
            {
                string data = reader.ReadLine();
                if(data != null)
                {
                    OnIncomingData(data);
                }
            }
        }
    }
    private void OnIncomingData(string data)
    {
        text.GetComponentInChildren<Text>().text = data;
    }
    private void Send(string data)
    {
        if (!socketReady)
            return;
        writer.WriteLine(data);
        writer.Flush();
    }
    public void OnSendButton()
    {
        string message = GameObject.Find("SendInput").GetComponent<InputField>().text;
        Send(message);
    }
    private void CloseSocket()
    {
        if (!socketReady)
            return;
        writer.Close();
        reader.Close();
        socket.Close();
        socketReady = false;
    }
    private void OnApplicationQuit()
    {
        CloseSocket();
    }
    private void OnDisable()
    {
        CloseSocket();
    }
}
