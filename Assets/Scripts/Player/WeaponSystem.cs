using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    GameObject _player = default;

    void Start()
    {
        _player = GameObject.Find("playerLeftHand");
    }

    void Update()
    {
        this.transform.position = _player.transform.position;
        Destroy(this.gameObject, 0.2f);
    }
}
