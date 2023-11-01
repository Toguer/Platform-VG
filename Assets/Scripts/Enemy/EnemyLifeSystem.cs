using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public abstract class EnemyLifeSystem : IDamageable
{
    protected MoveSys1 _enemy;
    [SerializeField] private bool _detectFalseWalls = true;
    
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
        base.Start();
        _enemy = GetComponent<MoveSys1>();
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
            Debug.Log("Exit Stun");
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out playerLifeSystem pj))
        {
            pj.getDMG();
        }
    }

    public override void getDMG()
    {
        DetectFalseWalls = false;
        _enemy.Flip();
    }
}