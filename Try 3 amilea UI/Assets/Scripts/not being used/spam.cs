using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class spam : MonoBehaviour
{
    public GameObject graph;
    public GameObject arrow;
    public GameObject BarNumber;
    private double lastNum = 0;

    private double currentNumber = 50.0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spamDouble", .1f, 0.5f);
    }

    private void spamDouble()
    {
        double newNum = 0.0;
        newNum = GetRandomNumber(currentNumber - 10.00, currentNumber + 10.00);
        
        currentNumber = newNum;
        Debug.Log(newNum);
        arrow.GetComponent<arrowRotation>().updateRotation(newNum);
        BarNumber.GetComponent<progressBar>().Updateinfo(newNum);
        graph.GetComponent<windowGraph>().updateList(newNum);
    }
    public double GetRandomNumber(double minimum, double maximum)
    {
        Random random = new Random();
        return random.NextDouble() * (maximum - minimum) + minimum;
    }

}
