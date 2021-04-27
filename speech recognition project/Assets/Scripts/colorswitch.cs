using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class colorswitch : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    public Material black;
    public Material white;
    public Material blue;
    public Material green;
    public Material maroon;
    public Material purple;


    // Start is called before the first frame update
    void Start()
    {
        actions.Add("purple", Purple);
        actions.Add("green", Green);
        actions.Add("blue", Blue);
        actions.Add("white", White);
        actions.Add("black", Black);
        actions.Add("maroon", Maroon);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Black()
    {
        Debug.Log("black");
        this.GetComponent<MeshRenderer>().material = black;

    }
    private void Blue()
    {
        Debug.Log("blue");
        this.GetComponent<MeshRenderer>().material = blue;
    }
    private void White()
    {
        Debug.Log("white");
        this.GetComponent<MeshRenderer>().material = white;
    }
    private void Purple()
    {
        Debug.Log("purple");
        this.GetComponent<MeshRenderer>().material = purple;

    }
    private void Green()
    {
        Debug.Log("green");
        this.GetComponent<MeshRenderer>().material = green;
    }
    private void Maroon()
    {
        Debug.Log("maroon");
        this.GetComponent<MeshRenderer>().material = maroon;
    }



}
