using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Net.Sockets;
using UnityEngine.UI;
using System;
using System.Diagnostics;


public class python_wakeup : MonoBehaviour
{
    // made a boolean so i can check the program on and off below with the test function
    private bool tracker = false;
    private Process proc = new Process();
    public void test()
    {
        proc.StartInfo.FileName = @"record.py";
        if (tracker == false)
        {
            proc.Start();
            tracker = true;
        }
        else
        {
            proc.Kill();
            tracker = false;
        }
    }
}