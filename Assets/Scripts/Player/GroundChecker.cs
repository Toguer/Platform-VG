using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private PrincessMovement _playerMovement;
    private MoveBehaviour _mb;
    private float initialJumpVelocity;
    
    public float InitialJumpVelocity { get => initialJumpVelocity; set => initialJumpVelocity = value; }

    private void Start()
    {
        _playerMovement = GetComponent<PrincessMovement>();
        _mb = GetComponent<MoveBehaviour>();
        InitialJumpVelocity = _playerMovement.JumpVelocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            _playerMovement.IsGrounded = true;
            _mb.Velocity = 3.5f;
            _playerMovement.JumpVelocity = InitialJumpVelocity;
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            _playerMovement.IsWalled = true;
            _mb.Velocity = 3.5f;
            _playerMovement.JumpVelocity = InitialJumpVelocity;
        }
        else if (other.gameObject.CompareTag("Slow"))
        {
            _playerMovement.IsGrounded = true;
            _mb.Velocity = 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            _playerMovement.IsGrounded = false;
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            _playerMovement.IsWalled = false;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            _playerMovement.IsGrounded = true;
        }
    }
}