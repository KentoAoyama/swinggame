using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    GameObject _player;
    [SerializeField] Color _color;
    Color _dafaultcolor;
    SpriteRenderer _sj;
    bool _check;
    
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _sj = GetComponent<SpriteRenderer>();
        _dafaultcolor = _sj.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _player && _check == false)
        {
            _check = true;
            StartCoroutine(CheckPoint());
        }
    }

    IEnumerator CheckPoint()
    {
        RunScript._initialPosition = this.transform.position;
        _sj.color = _color;
        yield return new WaitForSeconds(3);
        _sj.color = _dafaultcolor;
        _check = false;
    }
}
