using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class collisionsNoPhysics : MonoBehaviour
{
    public static event Action onEnd = delegate { };
    public static event Action onAqua = delegate { };
    //have "AquaMarineManager" subscribed

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out GridManager grid))
        {
            grid.mapChange();
        }
        else if (other.gameObject.CompareTag("softCurrency"))
        {
            CurrencyChecker.cc.SoftCurrency.INTValue++;
            Debug.Log("Coin take");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("hardCurrency"))
        {
            Destroy(other.gameObject);
            onAqua.Invoke();
        }else if (other.gameObject.CompareTag("End"))
        {
            Debug.Log("END");
            onEnd.Invoke();
        }
    }
}