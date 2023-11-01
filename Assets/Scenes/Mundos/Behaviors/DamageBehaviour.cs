using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageBehaviour : MonoBehaviour, IDMG
{
    [SerializeField] protected float stunTime;
    public float StunTime => stunTime;

    [SerializeField] protected float stunCounter;

    public float StunCounter
    {
        get => stunCounter;
        set => stunCounter = value;
    }


    public abstract void Apply();
}
