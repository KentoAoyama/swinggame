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
    [SerializeField] GameObject _MainUI;
    [SerializeField] GameObject _gameover;
    GameObject _player;
    
    Vector3 _initialPos;
    float _countdown = 3;
    public static bool _goalin;


    void Start()
    {
        GoalLineScript._goal = false;
        
        _player = GameObject.FindWithTag("Player");
        _initialPos = _player.transform.position;
        _timerText.text = $"{_timer:f2}";
        _MainUI.SetActive(true);

        _gameover.SetActive(false);

    }


    void FixedUpdate()
    {
        _countdown -= Time.deltaTime;

        if (_player != null && _player.transform.position != _initialPos && _countdown <= 0 && GoalLineScript._goal == false)
        {
            if (_timer > 0.1)
            {
                _timer -= Time.deltaTime;
                _timerText.text = $"{_timer:f2}";
                _currentTime += Time.deltaTime;
                _resultTime.text = $"{_currentTime:f2}";
            }
        }
        else
        {
            _timerText.text = $"0.00";
        }


        if (_timer <= 0.1)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        _gameover.SetActive(true);
        Text gameoverText = _gameover.GetComponent<Text>();
        gameoverText.text = ("GameOver");
        Destroy(_player);
        Cursor.visible = true;
    }
}
