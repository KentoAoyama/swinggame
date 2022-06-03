using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOverScript : MonoBehaviour
{
    GameObject _player;
    GameObject _gameoverText;
    [SerializeField] float _timer;
    Vector3 _initialPos;



    void Start()
    {
        _player = GameObject.Find("Player");
        _gameoverText = GameObject.Find("Gameover");
        _initialPos = _player.transform.position;
    }


    void FixedUpdate()
    {
        if (_player.transform.position != _initialPos)
        {
            _timer -= Time.deltaTime;
        }

        if (_player == null)
        {
            GameOver();
        }
        
        if (_timer <= 0)
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
