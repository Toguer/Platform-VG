using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class playerLifeSystem : IDamageable
{

    private playerMovement _player;
    private Animator _animator;
    public override void getDMG()
    {
        _player.Flip();
        stunCounter = stunTime;
    }

    private void Start()
    {
        base.Start();
        _moveBehaviour = GetComponentInParent<MoveBehaviour>();
        _player = GetComponentInParent<playerMovement>();
        _animator = GetComponentInParent<Animator>();
    }

    protected void Update()
    {
        if (StunCounter > 0)
        {
            stunCounter -= Time.deltaTime;
        }
        
    }

    public void getFrozen()
    {
        _moveBehaviour.Velocity = 0f;
        _player.JumpVelocity = 0f;
        _animator.SetBool("Frozen", true);
      Coroutine frozen = StartCoroutine(FrozenCorutine());
    }
    private IEnumerator FrozenCorutine()
    {
        yield return new WaitForSeconds(stunTime);
        _player.JumpVelocity = 5.5f;
        _moveBehaviour.Velocity = 3.5f;
        _animator.SetBool("Frozen", false);
    }
}
