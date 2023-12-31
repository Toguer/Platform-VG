﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _velocity;

    public float Velocity
    {
        get => _velocity;
        set => _velocity = value;
    }

    private Rigidbody2D _rb;

    public Vector2 Direction
    {
        get => _direction;
        set => _direction = value;
    }

  
    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void moveHorizontal(float num)
    {
        _rb.velocity = new Vector2(num, _rb.velocity.y);
    }

    public void Jump(float num)
    {
        _rb.velocity = new Vector2(_rb.velocity.x, num);
    }

    public void move()
    {
        _rb.MovePosition(new Vector2(transform.position.x + Velocity * _direction.x * Time.deltaTime,
            transform.position.y + Velocity * _direction.y * Time.deltaTime));
    }

    public void move(Vector2 newdir)
    {
        _rb.MovePosition(new Vector2(transform.position.x + Velocity * newdir.x * Time.deltaTime,
            transform.position.y + Velocity * newdir.y * Time.deltaTime));
    }

    public void move(Vector3 newdir)
    {
        _rb.MovePosition(new Vector3(transform.position.x + Velocity * newdir.x * Time.deltaTime,
            transform.position.y + Velocity * newdir.y * Time.deltaTime, 0));
    }
}