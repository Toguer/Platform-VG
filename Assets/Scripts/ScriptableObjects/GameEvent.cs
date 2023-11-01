using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/GameEvent")]
public class GameEvent : ScriptableObject
{
    [SerializeField] private List<IGameEventListener> _listeners = new List<IGameEventListener>();
    
    /*private event Action _onInvoke = delegate {  };

    public event Action OnInvoke
    {
        add => value += _onInvoke;
        remove => value -= _onInvoke;
    }*/

    public void Invoke()
    {
        foreach (var listener in _listeners)
        {
            listener.InvokeEffect();
        }
    }

    public void Subscribe(GameEventListener listener)
    {
        if (!_listeners.Contains(listener))
            _listeners.Add(listener);
    }
    
    public void Unsubscribe(GameEventListener listener)
    {
        if (_listeners.Contains(listener))
            _listeners.Remove(listener);
    }
}
