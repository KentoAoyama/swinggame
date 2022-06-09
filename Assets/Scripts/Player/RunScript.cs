using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunScript : MonoBehaviour
{

    [SerializeField] float _movePower = 0;
    [SerializeField] float _jumpPower = 0;
    [SerializeField] float _swingPower = 0;
    [SerializeField] public static float _startTimer;
    [SerializeField] float _speedLimit;
    float _h;
    Rigidbody2D _rb = default;
    SpringJoint2D _sj;
    public static Vector3 _initialPosition;
    Vector3 _mousePos;
    Vector2 _playerPos;
    bool _jump = false;
    int _jumpCount = 0;



    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sj = GetComponent<SpringJoint2D>();
        _initialPosition = this.transform.position;
    }

    
    void Update()
    {
        _startTimer += Time.deltaTime;
        
        if (Input.GetButtonDown("Jump"))
        {
            if (_jumpCount < 1)
            {
                _jump = true;
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            _mousePos = Input.mousePosition;
            _mousePos = Camera.main.ScreenToWorldPoint(_mousePos);
            _mousePos.z = 0;

            _playerPos = this.transform.position;
        }

    }

    private void FixedUpdate()
    {
        if (_startTimer > 3)
        {
            Move();
        }

        if (_jump)
        {
            _rb.AddForce(transform.up * _jumpPower, ForceMode2D.Impulse);

            _jump = false;
            _jumpCount++;
        }
    }


    void Move()
    {
        _h = Input.GetAxisRaw("Horizontal");

        if (_sj.enabled == false)
        {
            var moveVect = Vector2.right * _movePower * _h;
            _rb.velocity = new Vector2(moveVect.x, _rb.velocity.y);
            
            if (_rb.velocity.x >= _speedLimit)
            {
                _rb.velocity = new Vector2(_speedLimit, _rb.velocity.y);
            }
            else if (_rb.velocity.x <= -_speedLimit)
            {
                _rb.velocity = new Vector2(-_speedLimit, _rb.velocity.y);
            }
        }
        else
        {
            if (_playerPos.x < _mousePos.x)
            {
                _rb.AddForce(transform.right * _swingPower, ForceMode2D.Force);
            }
            else
            {
                _rb.AddForce(transform.right * -_swingPower, ForceMode2D.Force);
            }
        }
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _jumpCount = 0;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            this.transform.position = _initialPosition;
        }
    }
}
