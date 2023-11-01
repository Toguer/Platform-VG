using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessMovement : MonoBehaviour
{
    [SerializeField] [Range(1, 10)] protected float jumpVelocity;
    [SerializeField] protected bool facingRight = true;
    protected MoveBehaviour _moveBehaviour;
    protected Rigidbody2D _rb;
    [SerializeField]protected bool isGrounded;
    [SerializeField]protected bool isWalled;
    protected Animator _animator;
    public float chaseTime;
    protected bool chaseStarted=false;


    public bool IsGrounded
    {
        get => isGrounded;
        set => isGrounded = value;
    }
    
    public bool IsWalled
    {
        get => isWalled;
        set => isWalled = value;
    }
    public float JumpVelocity
    {
        get => jumpVelocity;
        set => jumpVelocity = value;
    }

    // Start is called before the first frame update
    protected void Start()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    protected void Update()
    {
        if (chaseStarted)
        {
            chaseTime += Time.deltaTime; // chaseTime se utiliza para saber cuando tiene que saltar el boss
        }
        if (facingRight)
        {
            _moveBehaviour.moveHorizontal(_moveBehaviour.Velocity);
        }
        else
        {
            _moveBehaviour.moveHorizontal(-_moveBehaviour.Velocity);
        }
    }

    #region colliders

    protected void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            if (isGrounded)
            {
                Flip();
            }
        }


        if (other.gameObject.TryGetComponent(out DamageBehaviourEnemy enemy))
        {
            enemy.Apply();
            Jump();
        }
        else if (other.gameObject.CompareTag("Floor"))
        {
            if (isWalled)
            {
                Flip();
            }
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("StartRace"))
        {
            startChase();
        }
    }

    #endregion

    public void Flip()
    {
        isWalled = false;
        facingRight = !facingRight;
        transform.Rotate(new Vector3(0, -180, 0));
    }

    public void Jump()
    {
        _rb.velocity = Vector2.up * jumpVelocity;
        Debug.Log(this.name + " "+ chaseTime);
    }

    protected void startChase()
    {
        if (this.name == "Player")
        {
            Debug.Log("Player corre");
        }
        chaseTime = 0;
        chaseStarted = true;
        _moveBehaviour.Velocity = 3.5f;
        //Debug.Log("Alguien comienza la carrera "+chaseTime);
    }
}