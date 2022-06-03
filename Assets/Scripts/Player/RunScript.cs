using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunScript : MonoBehaviour
{

    [SerializeField] float _movePower = 0;
    [SerializeField] float _jumpPower = 15f;
    [SerializeField] Vector2 resetPosition;
    Rigidbody2D _rb = default;
    Vector3 _initialPosition;
    private bool jump = false;
    private int jumpCount = 0;
    [SerializeField] float _startTimer;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _initialPosition = this.transform.position;
    }

    
    void Update()
    {
        _startTimer += Time.deltaTime;
        
        if (this.transform.position.x > resetPosition.x || this.transform.position.y < resetPosition.y)
        {
            this.transform.position = _initialPosition;
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
        if (_startTimer > 3)
        {
            var moveVect = Vector2.right * _movePower;
            _rb.velocity = new Vector2(moveVect.x, _rb.velocity.y);
        }

        if (jump)
        {
            _rb.AddForce(transform.up * _jumpPower, ForceMode2D.Impulse);

            jump = false;
            jumpCount++;
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpCount = 0;
        }
    }
}
