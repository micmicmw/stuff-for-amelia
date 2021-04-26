using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowRotation : MonoBehaviour
{
    public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        arrow.transform.Rotate(0, 0, 90);
            //cube1.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
    }
    public void updateRotation(double num)
    {
        double newNum = num / 100;
        newNum = newNum * 180;

        newNum -= 180;
        newNum = newNum / 2;
        
        arrow.transform.localEulerAngles = new Vector3(0, 180, (float)newNum);
        
        
    }


}
