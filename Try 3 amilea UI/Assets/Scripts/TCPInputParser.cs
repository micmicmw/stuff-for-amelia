using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class TCPInputParser : MonoBehaviour
{
    public GameObject tempOne;
    public GameObject tempTwo;
    public GameObject tempThree;
    public GameObject tempFour;
    public GameObject tempFive;
    public GameObject tempSix;
    public GameObject saveText;
    private List<double> CurrentPosition = new List<double>();
    private List<double> SavedPosition = new List<double>();
    public ClientMain main;
    
    public void streamParser(string input)
    {
        
        // for some reason I can't seem to remove the first null index being consistently index 0 I will work around this but I wanted to leave this comment for future coders.
        string[] stats = input.Split(new[] { ',', ' ' ,'[',']'});
        stats = stats.Except(new string[] { null }).ToArray();
        //Debug.Log(stats.Length);
        
        if(stats.Length == 13)
        {
            
            tempOne.GetComponent<TextMeshProUGUI>().text = stats[1];
            tempTwo.GetComponent<TextMeshProUGUI>().text = stats[2];
            tempThree.GetComponent<TextMeshProUGUI>().text = stats[3];
            tempFour.GetComponent<TextMeshProUGUI>().text = stats[4];
            tempFive.GetComponent<TextMeshProUGUI>().text = stats[5];
            tempSix.GetComponent<TextMeshProUGUI>().text = stats[6];
            CurrentPosition.Clear();
            //Debug.Log("stats length: " + stats[7]);
            for (int i = 7; i <= 12; i++)
            {
                CurrentPosition.Add(double.Parse(stats[i]));
            }
        }
        //Debug.Log(CurrentPosition[0]);
        if(SavedPosition.Count > 0)
        {
            //Debug.Log(SavedPosition[0]);
        }
        
    }
    public List<double> returnPosition()
    {
        return SavedPosition;
    }
    public void goToLocation()
    {
        if(SavedPosition.Count != 0)
        {
            //movej([-0.5405182705025187, -2.350330184112267, -1.316631037266588, -2.2775736604458237, 3.3528323423665642, -1.2291967454894914], a = 1.3962634015954636, v = 1.0471975511965976)
            main.Send("movej([" + SavedPosition[0] + ", " + SavedPosition[1] + ", " + SavedPosition[2] + ", " + SavedPosition[3] + ", " + SavedPosition[4] + ", " + SavedPosition[5] + "], a = 1.3962634015954636, v = 1.0471975511965976)");
        }
        else
        {
            Debug.Log("No Saved position");
        }
        
    }
    public void savePosition()
    {
        if(SavedPosition.Count > 0)
        {
            SavedPosition.Clear();
        }
        
        for(int i=0; i<CurrentPosition.Count; i++)
        {
            SavedPosition.Add(CurrentPosition[i]);
        }
        //SavedPosition.Add(CurrentPosition.Clone());
        //SavedPosition = CurrentPosition;
        saveText.GetComponent<TextMeshProUGUI>().text = "Location Saved - Yes";
    }
    
}
