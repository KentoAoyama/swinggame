using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    [SerializeField] GameObject _prefab = default;
    [SerializeField] float _interval = 1f;
    [SerializeField] bool _generateOnStart = true;
    float _timer;


    void Start()
    {
        if (_generateOnStart)
        {
            _timer = _interval;
        }
    }

    
    void Update()
    {
        _timer += Time.deltaTime;


        if (Input.GetButtonDown("Fire2"))
        {
            if (_timer > _interval)
            {
                _timer = 0;
                Instantiate(_prefab, transform.position, transform.rotation);
            }
        }
    }
}
