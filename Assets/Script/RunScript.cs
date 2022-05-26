using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunScript : MonoBehaviour
{

    [SerializeField] float m_movePower = 5f;
    [SerializeField] float m_jumpPower = 15f;
    [SerializeField] float resetPosition;
    Rigidbody2D m_rb = default;
    float m_h;
    Vector3 m_initialPosition;
    private bool jump = false;
    private int jumpCount = 0;
    private bool OnGround = false;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_initialPosition = this.transform.position;
    }

    
    void Update()
    {
        if (this.transform.position.x > resetPosition)
        {
            this.transform.position = m_initialPosition;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (jumpCount < 1)
            {
                jump = true;
            }
        }
    }

    private void FixedUpdate()
    {
        //m_rd.AddForce(Vector2.right * m_movePower, ForceMode2D.Force);
        
        var moveVect = Vector2.right * m_movePower;
        m_rb.velocity = new Vector2(moveVect.x, m_rb.velocity.y);

        if (jump)
        {
            m_rb.AddForce(transform.up * m_jumpPower, ForceMode2D.Impulse);

            jump = false;
            jumpCount++;
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            OnGround = true;
            jumpCount = 0;
        }
    }
}
