using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{

    [SerializeField] GameObject _activeObject;
    Animator _anime;
    CircleCollider2D _cc;

    void Start()
    {
        _anime =  GetComponent<Animator>();
        _cc = GetComponent<CircleCollider2D>();
        _anime.SetBool("Death", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            if (_activeObject.activeSelf == (false))
            {
                _anime.SetBool("Death", true);
                _activeObject.SetActive(true);
                Destroy(this.gameObject, 1f);
            }
            else if (_activeObject.activeSelf == (true))
            {
                _anime.SetBool("Death", true);
                _activeObject.SetActive(false);
                Destroy(this.gameObject, 1f);
            }
        }
    }

    private void Dead()
    {
        _cc.enabled = false;
    }
}
