using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    protected int hp;
    
    //Metodo de daño al player con el cual este se elimina despues de una serie de
    //golpes recibidos.
    public void getHit()
    {
        hp--;
        if (hp == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.getHit();
        }
    }
}
