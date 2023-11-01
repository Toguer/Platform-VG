using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Info : MonoBehaviour
{
    public float Speed;
    public float AngularSpeed;
    protected Rigidbody2D r;
    protected bool RightDir;
    void Start()
    {
        r = GetComponent<Rigidbody2D>();
        RightDir = true;
    }
    
    void FixedUpdate()
    {
        Speed = r.velocity.magnitude;
        AngularSpeed = r.angularVelocity;

        if (RightDir)
        {
            RightDirectional();
        }
        else if (!RightDir)
        {
            LeftDirection();
        }
    }
    
    //Direcionts
    void RightDirectional()
    {
        r.AddForce(Vector2.right);
    }
    void LeftDirection()
    {
        r.AddForce(Vector2.left);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            if (RightDir)
            {
                RightDir = false;
            }
            else
            {
                RightDir = true;
            }
        }
    }
}
