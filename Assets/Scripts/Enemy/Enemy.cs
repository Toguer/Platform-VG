using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int hp;
    
    public void getHit()
    {
        hp--;

        if (hp == 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.getHit();
        }
    }

}
