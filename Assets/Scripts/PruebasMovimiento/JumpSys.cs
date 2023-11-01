using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSys : MonoBehaviour
{
    private bool _isOnAir;
    private Rigidbody2D _r;
    public float jmpForce;
    void Start()
    {
        _isOnAir = false;
        _r = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _r.AddForce(Vector2.up * jmpForce);
            _isOnAir = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            _isOnAir = false;
        }
    }
}
