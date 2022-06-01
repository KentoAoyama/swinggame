using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerScript : MonoBehaviour
{

    [SerializeField] Text _timerText = default;
    [SerializeField] float _timer;
    GameObject _player;


    void Start()
    {
        _player = GameObject.Find("Player");
    }


    void Update()
    {
        if (_player != null)
        {
            if (_timer >= 0)
            {
                _timer -= Time.deltaTime;
                _timerText.text = $"{_timer.ToString("f2")}";
            }
        }
    }
}
