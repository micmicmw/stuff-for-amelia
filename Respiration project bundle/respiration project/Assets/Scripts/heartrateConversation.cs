using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class heartrateConversation : MonoBehaviour
{
    public ClientRemoteDashboard dashboard;
    public GameObject heartrate;

    // Update is called once per frame
    void Update()
    {
        string rate = heartrate.GetComponent<Text>().text;
        if (int.Parse(rate) > 13)
        {
            //Debug.Log("We made it into the if statement");
            dashboard.Send("stop");
        }
        


    }
}
