using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOlaf : DamageBehaviourEnemy
{
    protected override void ApplyEffect(Collider2D other)
    {
        if(other.gameObject.TryGetComponent(out PlayerFrozen pj))
        {
            Debug.Log("Frozen");
            pj.Apply();
            _enemy.Flip();
        }
    }

    /* public override void Apply()
     {
         DetectFalseWalls = false;
         _enemy.Flip();
         _spriteRenderer.sprite = _hitSprite;
         _enemyDamaged.Invoke();
         CamShake.CamShakeCall.Shake(3f, 0.1f);
     }
     */
}