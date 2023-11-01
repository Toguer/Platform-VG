using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSys : MonoBehaviour
{
    private Rigidbody2D _rb;
    private bool _rightDir;
    private SpriteRenderer _sprite;
    
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float AngularSpeed;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _rightDir = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector2.up);
        }
    }

    void FixedUpdate()
    {
        Speed = _rb.velocity.magnitude;
        AngularSpeed = _rb.angularVelocity;

        if (_rightDir)
        {
            RightDirectional();
        }
        else if (!_rightDir)
        {
            LeftDirectional();
        }
    }

    void RightDirectional()
    {
        _rb.AddForce(Vector2.right);
        _sprite.flipX = true;
    }

    void LeftDirectional()
    {
        _rb.AddForce(Vector2.left);
        _sprite.flipX = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            if (_rightDir)
            {
                _rightDir = false;
            }
            else
            {
                _rightDir = true;
                _sprite.flipX = false;
            }
        }
    }

    
}
