using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTempAnim : MonoBehaviour
{
    Animator _animator;
    SpriteRenderer _sprite;
    private static readonly int PlatState = Animator.StringToHash("PlatState");

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void IdleAnim()
    {
        _animator.SetInteger(PlatState, 0);
    }
    public void BreakingAnim()
    {
        _animator.SetInteger(PlatState, 1);
    }
    public void DestroyAnim()
    {
        _animator.SetInteger(PlatState, 2);
    }
    public void EntryAnim()
    {
        _animator.SetInteger(PlatState, 3);
        Invoke(nameof(IdleAnim), 0.1f);
    }
}
