using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartScript : MonoBehaviour
{
    GameObject _startText;
    float _countdown = 3;


    void Start()
    {
        _startText = GameObject.Find("Starttext");
    }


    void Update()
    {
        _countdown -= Time.deltaTime;    

        if (_countdown >= 2)
        {
            Text countdownText = _startText.GetComponent<Text>();
            countdownText.text = ("3");
        }
        else if (_countdown >= 1)
        {
            Text countdownText = _startText.GetComponent<Text>();
            countdownText.text = ("2");
        }
        else if (_countdown >= 0)
        {
            Text countdownText = _startText.GetComponent<Text>();
            countdownText.text = ("1");
        }
        else if (_countdown >= -1)
        {
            Text countdownText = _startText.GetComponent<Text>();
            countdownText.text = ("RUN");
            countdownText.fontSize = (160);
        }
        else
        {
            Text countdownText = _startText.GetComponent<Text>();
            countdownText.text = (" ");
        }
    }
}
