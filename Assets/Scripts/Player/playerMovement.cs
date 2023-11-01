using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class playerMovement : PrincessMovement
{
    #region Properties & var

    private float hangCounter;
    [SerializeField] private float hangTime;

    private PlayerStunned _stunned;
    public float jumpBufferLenght;

    private float jumpBufferCount;

    CommmandManager.Command c;

    //private bool stunned = false;
    private InputManager _inputManager;
    private AudioManager _audioManager;

    #endregion

    void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        base.Start();
        _stunned = GetComponentInChildren<PlayerStunned>();
        _inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Each frame player moves right or left.
        base.Update();
        //Debug.Log("Player " + _rb.velocity.y);
        if (isGrounded || isWalled)
        {
            hangCounter = hangTime;
        }
        else
        {
            hangCounter -= Time.deltaTime;
        }

        if (_stunned.StunCounter > 0)
        {
            _stunned.StunCounter -= Time.deltaTime;
        }

        #region PreviousJump

        // Cuando pulsamos a saltar añadimos un tiempo durante el cual el personaje al tocar el suelo saltara.
        // De esta manera el salto sera más comodo.
        /* if (Input.GetButtonDown("Jump"))
         {
             jumpBufferCount = jumpBufferLenght;
         }
         else
         {
             jumpBufferCount -= Time.deltaTime;
         }*/

        #endregion

        #region JumpStuff

        if (_inputManager.JumpPress)
        {
            jumpBufferCount = jumpBufferLenght;
            _inputManager.JumpPress = false;
        }
        else
        {
            jumpBufferCount -= jumpBufferLenght;
        }

        if (chaseStarted)
        {
            if (c.started)
            {
                if (_inputManager.JumpHold && _rb.velocity.y > 0)
                {
                    //c._timeSpanPress += Time.deltaTime;
                    c._timeSpanRelease += Time.deltaTime;
                }
                else
                {
                   // c._timeSpanRelease = chaseTime;
                    c.started = false;
                    CommmandManager.AddCommand(c);
                }
            }
        }


        if (jumpBufferCount >= 0 && hangCounter > 0 && _stunned.StunCounter <= 0)
        {
            if (chaseStarted)
            {
                c = new CommmandManager.Command();
                c._timeSpanPress = chaseTime;
                c._timeSpanRelease = chaseTime;
                c.started = true;
                Debug.Log(c._timeSpanPress + "Player salta");
            }

            if (isWalled)
            {
                Flip();
            }

            _animator.SetBool("Jump", true);

            isGrounded = false;
            Jump();

            jumpBufferCount = 0;
            hangCounter = 0;
        }

        // Con esto hacemos que el personaje pueda saltar menos. al levantar el boton de saltar caera.
        if (!_inputManager.JumpHold && _rb.velocity.y > 0)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * .5f);
        }

        #endregion
    }


    public void Jump()
    {
        base.Jump();
        GameEvents.Instance.PlatMove();
        FindObjectOfType<AudioManager>().Play("Jump");
    }
}