using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressBar : MonoBehaviour
{
    public GameObject loadingBar;
    public GameObject percentage;
    // Start is called before the first frame update
    void Start()
    {
        loadingBar.GetComponent<Image>().fillAmount = 0.5f;
        percentage.GetComponent<Text>().text = "0";
    }

    public void Updateinfo(double num)
    {
        float barNum = (float)(num / 200);
        barNum= barNum - 0.3f;
        loadingBar.GetComponent<Image>().fillAmount = barNum;

        percentage.GetComponent<Text>().text = num.ToString();
    }
}
