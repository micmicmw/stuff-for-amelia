using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputSender : MonoBehaviour
{
    // inport the code as objects so we are able to access the correct code to send to each connection as well as be able to know the current button selected in the UI so that we can figure out where the message needs to be sent to.
    

    public ClientRemoteDashboard dashboard;
    public ClientMain main;
    public Server RTDE;

    public GameObject textbox;


    private string liveInput = "Not Selected";
    
    public void dashboardClicked()
    {
        // Change the color of all buttons to default
        
        liveInput = "dashboard";
        Debug.Log("dashboard");
    }
    public void mainClicked()
    {
        // change the colors again
        liveInput = "main";
        Debug.Log("main");
    }
    public void RTDEClicked()
    {
        // change the colors again
        liveInput = "RTDE";
        Debug.Log("RTDE");
    }
    public void inputSender()
    {
        
        string input = textbox.GetComponent<InputField>().text;
        //string input = "placeholder";
        if (liveInput == "dashboard")
        {
            dashboard.Send(input);
            
        }
        if(liveInput == "main")
        {
            main.Send(input);
        }
        if(liveInput == "RTDE")
        {
            RTDE.InputFromUnity(input);
        }
    }
}
