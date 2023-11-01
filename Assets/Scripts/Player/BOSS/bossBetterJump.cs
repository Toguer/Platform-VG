using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBetterJump : betterJump
{
    private bossMovement BossMovement;
    void Start()
    {
        BossMovement = GetComponent<bossMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rb.velocity.y < 0 && BossMovement.IsWalled)
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
        else if (_rb.velocity.y <= 0 && BossMovement.JumpTime >= 0)
        {
            _rb.velocity += Vector2.up * (Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime);
            _animator.SetTrigger("Fall");
            _animator.SetBool("Jump", false);
        }
    }
}
