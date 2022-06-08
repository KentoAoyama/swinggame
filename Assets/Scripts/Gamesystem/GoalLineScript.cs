using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLineScript : MonoBehaviour
{
    [SerializeField] GameObject _panel;
    [SerializeField] GameObject _player;

    void Start()
    {
        _panel.SetActive(false);
    }


    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject == _player)
        {
            _panel.SetActive(true);
        }
    }
}
