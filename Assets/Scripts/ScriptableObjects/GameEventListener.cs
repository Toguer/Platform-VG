using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour, IGameEventListener
{
    [SerializeField] private GameEvent _enemyEvent;

    [SerializeField] private UnityEvent _effectEvent;

    public void InvokeEffect()
    {
        _effectEvent.Invoke();
    }

    private void OnEnable()
    {
        _enemyEvent.Subscribe(this);
    }

    private void OnDisable()
    {
        _enemyEvent.Unsubscribe(this);
    }
}
