using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.Win32;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class ChangingPlatform : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private Transform _pos1;
    [SerializeField] private Transform _pos2;

    playerMovement _pm;

    bool _jumped;

    public bool Jumped => _jumped;


    void Start()
    {
        _jumped = false;
        GameEvents.Instance.movePlat += ChangePos;
    }

    #region changePosSys

    void ChangePos()
    {
        if (_jumped)
        {
            StopAllCoroutines();
            StartCoroutine(ChangePos2());
            _jumped = false;
        }
        else if (!_jumped)
        {
            StopAllCoroutines();
            StartCoroutine(ChangePos1());
            _jumped = true;
        }
    }

    IEnumerator ChangePos1()
    {
        float time = 0;

        Vector2 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector2.Lerp(startPosition, _pos1.position, time / duration);
            time += Time.deltaTime;

            yield return null;
        }

        transform.position = _pos1.position;
    }
    
    IEnumerator ChangePos2()
    {
        float time = 0;

        Vector2 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector2.Lerp(startPosition, _pos2.position, time / duration);
            time += Time.deltaTime;

            yield return null;
        }

        transform.position = _pos2.position;
    }

    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(_pos1.position, _pos2.position);
    }
}
