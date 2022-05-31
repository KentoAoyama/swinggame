using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitPoint : MonoBehaviour
{
    Rigidbody2D m_rb = default;
    public int playerHP = 1;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (playerHP > 1)
            {
                playerHP -= 1;
            }
            else
            {
                Destroy(this.gameObject);
            }
            
            Destroy(collision.gameObject);
        }

    }
}
