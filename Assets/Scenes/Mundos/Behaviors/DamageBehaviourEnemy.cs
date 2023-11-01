using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageBehaviourEnemy : DamageBehaviour
{
    protected MoveSys1 _enemy;
    [SerializeField] private bool _detectFalseWalls = true;
    protected SpriteRenderer _spriteRenderer;

    [SerializeField] protected Sprite _idleSprite;
    [SerializeField] protected Sprite _hitSprite;
    protected HitIllum _hit;

    public bool DetectFalseWalls
    {
        get => _detectFalseWalls;
        set
        {
            stunCounter = stunTime;
            _detectFalseWalls = value;
        }
    }

    private void Start()
    {
        _enemy = GetComponent<MoveSys1>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _idleSprite;
        _hit = GetComponent<HitIllum>();
    }

    private void Update()
    {
        if (!DetectFalseWalls && stunCounter > 0)
        {
            stunCounter -= Time.deltaTime;
        }

        if (stunCounter < 0 && !DetectFalseWalls)
        {
            DetectFalseWalls = true;
            _spriteRenderer.sprite = _idleSprite;
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enemy entra en trigger");
        ApplyEffect(other);
    }

    /*  private void OnTriggerStay2D(Collider2D other)
      {
          ApplyEffect(other);
      }
  */
    public override void Apply()
    {
        DetectFalseWalls = false;
        _enemy.Flip();
        _spriteRenderer.sprite = _hitSprite;
        GameEvents.Instance.WinCoins();
        _hit.IllumEffect();
        
//        CamShake.CamShakeCall.Shake(3f, 0.1f);
    }
    protected abstract void ApplyEffect(Collider2D other);
}