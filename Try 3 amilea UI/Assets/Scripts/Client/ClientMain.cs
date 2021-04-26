using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.IO;
using UnityEngine.UI;
using System;
using TMPro;

public class ClientMain : MonoBehaviour
{
    public GameObject chatContainer;
    public GameObject messagePrefab;
    public GameObject outputText;
    public GameObject inputText;



    public GameObject graph;
    public GameObject arrow;
    public GameObject BarNumber;

    private bool socketReady;
    private TcpClient socket;
    private NetworkStream stream;
    private StreamWriter writer;
    private StreamReader reader;






    public string ClientName;
    private string deviceName = "unity client";
    

    public void ConnectToServer()
    {
        if (socketReady)
            return;
        string host = "192.168.56.2";
        int port = 30001;

        //string host = "127.0.0.1";
        //int port = 21;

        // create the socket
        try
        {
            socket = new TcpClient(host,port);
            stream = socket.GetStream();
            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);
            socketReady = true;
            Debug.Log(" We connected on port " + port);
            //Send("device_connect " + deviceName);
            //Send("device_subscribe gsr ON");
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
        //Debug.Log(data);
        try
        {
            string[] ssize = data.Split(new char[0]);
            outputText.GetComponentInChildren<TextMeshProUGUI>().text = data;

            double newNum = Convert.ToDouble(ssize[2]);
            Debug.Log(data);
            if(newNum > 2.0)
            {
                arrow.GetComponent<arrowRotation>().updateRotation(newNum);

                // I am the progress bar
                BarNumber.GetComponent<progressBar>().Updateinfo(newNum);


                graph.GetComponent<windowGraph>().updateList(newNum);
            }
            

        }
        catch
        {
            outputText.GetComponentInChildren<TextMeshProUGUI>().text = data;
        }
        
    }
    public void Send(string data)
    {
        Debug.Log("We made it into clientmain in send : " + data);
        if (!socketReady)
            return;
        writer.WriteLine(data);
        writer.Flush();
    }

    
    public void OnSendButton()
    {
        string message = GameObject.Find("SendInput").GetComponent<InputField>().text;
        Send(message);
        GameObject.Find("SendInput").GetComponent<InputField>().text = "";
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