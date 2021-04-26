using UnityEngine;
using UnityEngine.UI;
//using Microsoft.MixedReality.Toolkit;
//using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using System.Collections.Generic;

public class BioPacConnector : MonoBehaviour
{
    public RAAUConnector connector;
    public RAAUInputChannel inputChannel;
    public Text rr2Text;
    //public Text hr2Text;
    //public Image needleImage;
    //public double speed;

    public int AnalogChannelNumber = 3;
    public int CalculatedChannelNumber = 0;

    private double analogValue;
    private double calculatedValue;
    //private int needlePosition = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Got here: ");
        // Starting Data Acquisition
        connector.SetAcquisitionActivation(true);

        // Starting in 1 second calling UpdateValues every 3 seconds
        InvokeRepeating("UpdateValues", 1.0f, 10.0f);

        //needleImage.transform.RotateAround(hr2Text.transform.position, Vector3.back, speed * Time.deltaTime);
    }

    // UpdateValues called every 3 seconds
    void UpdateValues()
    {
        Debug.Log("Update Value: ");
        //// Use CoreServices to quickly get access to the IMixedRealitySpatialAwarenessSystem
        //var spatialAwarenessService = CoreServices.SpatialAwarenessSystem;

        //// Cast to the IMixedRealityDataProviderAccess to get access to the data providers
        //var dataProviderAccess = spatialAwarenessService as IMixedRealityDataProviderAccess;

        //var meshObserver = dataProviderAccess.GetDataProvider<IMixedRealitySpatialAwarenessMeshObserver>();

        //// Get the first Mesh Observer available, generally we have only one registered
        //var observer = CoreServices.GetSpatialAwarenessSystemDataProvider<IMixedRealitySpatialAwarenessMeshObserver>();

        //// Set to not visible
        //observer.DisplayOption = SpatialAwarenessMeshDisplayOptions.None;


        /*IMixedRealityDataProviderAccess dataProviderAccess =
        CoreServices.SpatialAwarenessSystem as IMixedRealityDataProviderAccess;

        if (dataProviderAccess != null)
        {
            IReadOnlyList<IMixedRealitySpatialAwarenessMeshObserver> observers =
                dataProviderAccess.GetDataProviders<IMixedRealitySpatialAwarenessMeshObserver>();

            foreach (IMixedRealitySpatialAwarenessMeshObserver observer in observers)
            {
                // Set the mesh to use the occlusion material
                observer.DisplayOption = SpatialAwarenessMeshDisplayOptions.None;
            }
        }*/



        //Debug.Log("This is it");
        // Reading analog value
        analogValue = -99;
        inputChannel.AnalogRawSamples.TryGetValue(AnalogChannelNumber, out analogValue);

        //Reading calc value
        calculatedValue = -99;
        inputChannel.CalcRawSamples.TryGetValue(CalculatedChannelNumber, out calculatedValue);

        // Updating UI
        //rr2Text.text = analogValue.ToString("0.0");
        rr2Text.text = calculatedValue.ToString("0");
        //hr2Text.text = calculatedValue.ToString("0.0000");


        //MoveNeedle(speed);
        //MoveNeedle(calculatedValue);
        //needleImage.transform.RotateAround(hr2Text.transform.position, Vector3.back, -360 * Time.deltaTime);
    }

    /*void MoveNeedle(double calculatedValue)
    {
        int rotatingAngle = 0;

        switch (needlePosition)
        {
            case 1:
                rotatingAngle = 4000;
                break;

            case 2:
                rotatingAngle = 1000;
                break;

            case 3:
                rotatingAngle = 0;
                break;

            case 4:
                rotatingAngle = -4100;
                break;

            case 5:
                rotatingAngle = -7000;
                break;
        }

        if (calculatedValue >= 0 && calculatedValue <= 10)
        {
            //needleImage.transform.RotateAround(hr2Text.transform.position, Vector3.back, rotatingAngle * Time.deltaTime);
            if (needlePosition != 1)
            {
                needleImage.transform.RotateAround(hr2Text.transform.position, Vector3.back, rotatingAngle * Time.deltaTime);
                needleImage.transform.RotateAround(hr2Text.transform.position, Vector3.back, -4000 * Time.deltaTime);
            }
            needlePosition = 1;
        }
        else if (calculatedValue > 10 && calculatedValue <= 20)
        {
            //needleImage.transform.RotateAround(hr2Text.transform.position, Vector3.back, (rotatingAngle + -1700) * Time.deltaTime);
            if (needlePosition != 2)
            {
                needleImage.transform.RotateAround(hr2Text.transform.position, Vector3.back, rotatingAngle * Time.deltaTime);
                needleImage.transform.RotateAround(hr2Text.transform.position, Vector3.back, -1000 * Time.deltaTime);
            }
            //needleImage.transform.RotateAround(hr2Text.transform.position, Vector3.back, 1700 * Time.deltaTime);

            needlePosition = 2;
        }
        else if (calculatedValue > 20 && calculatedValue <= 30)
        {
            if (needlePosition != 3)
            {
                needleImage.transform.RotateAround(hr2Text.transform.position, Vector3.back, rotatingAngle * Time.deltaTime);
                needleImage.transform.RotateAround(hr2Text.transform.position, Vector3.back, 0 * Time.deltaTime);
            }
            needlePosition = 3;
        }
        else if (calculatedValue > 30 && calculatedValue <= 40)
        {
            if (needlePosition != 4)
            {
                needleImage.transform.RotateAround(hr2Text.transform.position, Vector3.back, rotatingAngle * Time.deltaTime);
                needleImage.transform.RotateAround(hr2Text.transform.position, Vector3.back, 4100 * Time.deltaTime);
            }
            needlePosition = 4;
        }
        else if (calculatedValue > 40 && calculatedValue <= 50)
        {
            if (needlePosition != 5)
            {
                needleImage.transform.RotateAround(hr2Text.transform.position, Vector3.back, rotatingAngle * Time.deltaTime);
                needleImage.transform.RotateAround(hr2Text.transform.position, Vector3.back, 7000 * Time.deltaTime);
            }
            needlePosition = 5;
        }
    }*/
}
