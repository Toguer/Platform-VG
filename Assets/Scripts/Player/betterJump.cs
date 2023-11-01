using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class betterJump : MonoBehaviour
{
    protected Rigidbody2D _rb;
    [SerializeField][Range (0, 2.5f)]protected float fallMultiplier;
    public float lowJumpMultiplier;
    protected Animator _animator;
    private InputManager _inputManager;
    private playerMovement pj;

    void Start()
    {
        pj = GetComponent<playerMovement>();
        _inputManager = GetComponent<InputManager>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rb.velocity.y < 0 && pj.IsWalled)
        {
            _rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 3) * Time.deltaTime;
            _animator.SetTrigger("Fall");
            _animator.SetBool("Jump", false);
        }
        else if (_rb.velocity.y < 0)
        {
            _rb.velocity += new Vector2(0, Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime);
            _animator.SetTrigger("Fall");
            _animator.SetBool("Jump", false);
        }
        else if (_rb.velocity.y > 0 && !_inputManager.JumpHold)
        {
            _rb.velocity += Vector2.up * (Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime);
            _animator.SetTrigger("Fall");
            _animator.SetBool("Jump", false);
        }
    }
}