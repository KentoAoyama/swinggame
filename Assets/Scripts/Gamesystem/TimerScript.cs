using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerScript : MonoBehaviour
{

    [SerializeField] Text _timerText = default;
    [SerializeField] public float _timer;
    [SerializeField] public static float _currentTime;
    [SerializeField] Text _resultTime;
    GameObject _player;
    GameObject _gameoverText;
    Vector3 _initialPos;
    float _countdown = 3;
    public static bool _goalin;


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

        if (_player != null && _player.transform.position != _initialPos && _countdown <= 0 && GoalLineScript._goal == false)
        {
            if (_timer >= 0.1)
            {
                _timer -= Time.deltaTime;
                _timerText.text = $"{_timer:f2}";
                _currentTime += Time.deltaTime;
                _resultTime.text = $"{_currentTime:f2}";
            }
        }
        else if (_timer <= 0.1)
        {
            _timerText.text = $"0.00";
        }


        if (_player == null || _timer <= 0.1)
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
