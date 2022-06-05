using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLineScript : MonoBehaviour
{
    [SerializeField] GameObject _panel;
    [SerializeField] GameObject _player;


    public void OnTriggerEnter2D(Collider2D collider)
    {
        _panel.SetActive(true);
    }
}
