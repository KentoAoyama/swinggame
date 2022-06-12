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
        _activeObject.SetActive(false);
        _anime =  GetComponent<Animator>();
        _cc = GetComponent<CircleCollider2D>();
        _anime.SetBool("Death", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            _anime.SetBool("Death", true);
            _activeObject.SetActive(true);
            Destroy(this.gameObject, 1f);
        }
    }

    private void Dead()
    {
        _cc.enabled = false;
    }
}
