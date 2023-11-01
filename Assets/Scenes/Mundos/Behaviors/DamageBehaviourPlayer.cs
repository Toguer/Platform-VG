using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageBehaviourPlayer : DamageBehaviour

{
    protected playerMovement _player;
    protected MoveBehaviour _moveBehaviour;
    protected PlayerDmgIllu _playerDmgIllu;


    protected void Start()
    {
        _moveBehaviour = GetComponentInParent<MoveBehaviour>();
        _player = GetComponentInParent<playerMovement>();
        _playerDmgIllu = GetComponent<PlayerDmgIllu>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision jugador con algo");
        ApplyEffect(other);
    }

    protected void ApplyEffect(Collision2D other)
    {
        if(other.gameObject.TryGetComponent(out DamageBehaviourEnemy enemy))
        {
            _player.Jump();
            enemy.Apply();
        }   
    }
}