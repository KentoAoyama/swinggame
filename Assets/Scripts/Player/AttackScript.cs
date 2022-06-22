using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    [SerializeField] GameObject _weapon;
    [SerializeField] float _interval = 1f;
    [SerializeField] float _attackTime = 1f;
    [SerializeField] AudioClip _attackSound;
    AudioSource _as;
    float _timer;
    bool _generateOnStart = true;

    void Start()
    {
        if (_generateOnStart)
        {
            _timer = _interval;
        }

        _weapon.SetActive(false);

        _as = GetComponent<AudioSource>();
    }


    void Update()
    {
        _timer += Time.deltaTime;

        if (Input.GetButtonDown("Fire2"))
        {
            if (_timer > _interval)
            {
                _timer = 0;
                _as.PlayOneShot(_attackSound);
                _weapon.SetActive(true);
                Invoke(nameof(Weaponoff), _attackTime);
            }
        }
    }

    void Weaponoff()
    {
        _weapon.SetActive(false);
    }
}
