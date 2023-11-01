using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFrozen : DamageBehaviourPlayer
{
    private Animator _animator;

    public override void Apply()
    {
        _moveBehaviour.Velocity = 0f;
        _player.JumpVelocity = 0f;
        _animator.SetBool("Frozen", true);
        _player.Flip();
        
        Coroutine frozen = StartCoroutine(FrozenCorutine());
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        _animator = GetComponentInParent<Animator>();
    }


    private IEnumerator FrozenCorutine()
    {
        
        yield return new WaitForSeconds(stunTime);
        _player.JumpVelocity = 5.5f;
        _moveBehaviour.Velocity = 3.5f;
        _animator.SetBool("Frozen", false);
    }
}