using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Boosts : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
    }
}