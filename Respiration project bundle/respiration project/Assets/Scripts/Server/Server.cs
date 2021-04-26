using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System;
using System.Net;
using System.IO;
using UnityEngine.UI;

public class Server : MonoBehaviour
{
    public GameObject outputtext;
    private List<ServerClient> clients;
    private List<ServerClient> disconnectList;
    public int port = 6321;
    private TcpListener server;
    private bool serverStarted;
    private double hugoSpeed = 0.0;
    private List<string> clientslist;
    public TCPInputParser parserCode;

    private void Start()
    {
        clientslist = new List<string>();
        clients = new List<ServerClient>();
        disconnectList = new List<ServerClient>();

        try
        {
            server = new TcpListener(IPAddress.Any, port);
            server.Start();
            startListening();
            serverStarted = true;
            Debug.Log("server has been started on port " + port.ToString());
        }
        catch (Exception e)
        {
            Debug.Log("Socket Error " + e.Message);
        }

    }
    private void Update()
    {
        if (!serverStarted)
        {
            return;
        }
        foreach (ServerClient c in clients)
        {
            // Is the client still connected
            if (!IsConnected(c.tcp))
            {
                c.tcp.Close();
                disconnectList.Add(c);
                clients.Remove(c);
                continue;
            }
            //check for messages from the client
            else
            {
                NetworkStream s = c.tcp.GetStream();
                if (s.DataAvailable)
                {
                    StreamReader reader = new StreamReader(s, true);
                    string data = reader.ReadLine();

                    if (data != null)
                    {
                        OnIncomingData(c, data);
                    }
                }
            }
        }

        for( int i = 0; i<disconnectList.Count -1; i++)
        {
            Broadcast(disconnectList[i].ClientName + " has disconnected", clients);
            clients.Remove(disconnectList[i]);
            disconnectList.RemoveAt(i);
        }
    }
    private void startListening()
    {
        server.BeginAcceptTcpClient(AcceptTcpClient, server);
    }
    private bool IsConnected(TcpClient c)
    {
        try
        {
            if (c != null && c.Client != null && c.Client.Connected)
            {
                if (c.Client.Poll(0, SelectMode.SelectRead))
                {
                    return !(c.Client.Receive(new byte[1], SocketFlags.Peek) == 0);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        catch
        {
            return false;
        }
    }
    private void AcceptTcpClient(IAsyncResult ar)
    {
        TcpListener listener = (TcpListener)ar.AsyncState;
        clients.Add(new ServerClient(listener.EndAcceptTcpClient(ar)));
        startListening();
        // Send a message to everyone saying someone just connected

        // Error in broadcast popping up here
        //Broadcast("%NAME",new List<ServerClient>() { clients[clients.Count - 1] });
    }

    public void speedUp()
    {
        if(hugoSpeed < 100)
        {
            hugoSpeed += 10;
        }
        if(hugoSpeed > 100)
        {
            hugoSpeed = 100;
        }

        Debug.Log("hugospeed " + hugoSpeed);

        double hugoout = hugoSpeed / 100;
        Debug.Log("hugoout " + hugoout);
        double hugojoint = hugoout * .8;
        double hugoacceleration = hugoout * .6;

        Debug.Log("joint " + hugojoint);
        Debug.Log("accel " + hugoacceleration);





        //Broadcast()
    }
    public void speedDown()
    {
        if(hugoSpeed> 0)
        {
            hugoSpeed -= 10;
        }
        if(hugoSpeed < 0)
        {
            hugoSpeed = 0;
        }
        Debug.Log("hugospeed " + hugoSpeed);

        double hugoout = hugoSpeed / 100;
        Debug.Log("hugoout " + hugoout);
        double hugojoint = hugoout * .8;
        double hugoacceleration = hugoout * .6;

        Debug.Log("joint " + hugojoint);
        Debug.Log("accel " + hugoacceleration);

    }

    private void Broadcast(string data, List<ServerClient> c1)
    {
        foreach(ServerClient c in c1)
        {
            if (disconnectList.Contains(c))
                return;
            try
            {
                StreamWriter writer = new StreamWriter(c.tcp.GetStream());
                writer.WriteLine(data);
                outputtext.GetComponent<Text>().text = data;
                
                writer.Flush();
            }
            catch(Exception e)
            {
                Debug.Log("Write error: " + e.Message + " to client " + c.ClientName);
            }
        }
    }






    private void OnIncomingData(ServerClient c, string data)
    {
        if (c.ClientName == "Guest")
        {
            c.ClientName = data.Split(' ')[1];
            outputtext.GetComponent<Text>().text = c.ClientName + " has connecteed!";
            return;
        }
        //Debug.Log(data);
        parserCode.streamParser(data);

        if (c.ClientName != "UnityBase")
        {
                UnityReadTo(data);
        }
        Broadcast(c.ClientName + " : " + data, clients);
        
    }

    // We will pass out information to our unity UI in this function
    private void UnityReadTo(string data)
    {
        outputtext.GetComponent<Text>().text = data;
    }

    public void InputFromUnity(string data)
    {
        Broadcast(data, clients);
    }
}
public class ServerClient
{
    public TcpClient tcp;
    public string ClientName;
    public ServerClient(TcpClient ClientSocket)
    {
        ClientName = "Guest";
        tcp = ClientSocket;
    }
}
