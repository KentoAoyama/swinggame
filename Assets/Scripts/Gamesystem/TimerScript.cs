using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerScript : MonoBehaviour
{

    [SerializeField] Text _timerText = default;
    [SerializeField] float _timer;
    GameObject _player;
    GameObject _gameoverText;
    Vector3 _initialPos;
    float _countdown = 3;


    void Start()
    {
        _player = GameObject.Find("Player");
        _gameoverText = GameObject.Find("Gameover");
        _initialPos = _player.transform.position;
        _timerText.text = $"{_timer:f2}";
    }


    void FixedUpdate()
    {
        _countdown -= Time.deltaTime;

        if (_player != null && _player.transform.position != _initialPos && _countdown <= 0)
        {
            if (_timer != 0)
            {
                _timer -= Time.deltaTime;
                _timerText.text = $"{_timer:f2}";
            }
        }
        else if (_timer <= 0.02)
        {
            _timerText.text = $"0.00";
        }


        if (_player == null || _timer <= 0.02)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Text gameoverText = _gameoverText.GetComponent<Text>();
        gameoverText.text = ("GameOver");
        Destroy(_player);
    }
}
