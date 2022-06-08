using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{

    [SerializeField] GameObject _activeObject;

    void Start()
    {
        _activeObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            Destroy(this.gameObject);
            _activeObject.SetActive(true);
        }
    }
}
