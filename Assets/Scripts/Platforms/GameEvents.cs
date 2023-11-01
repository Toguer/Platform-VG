using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;
    
    void Awake()
    {
        Instance = this;
    }
    
    //Evento cambiar posicion 1
    public event Action movePlat = delegate {  };
    public void PlatMove()
    {
       movePlat.Invoke();
    }
    //Evento añadir monedas al Canvas
    public event Action moreCoins = delegate {  };
    public void WinCoins()
    {
       moreCoins.Invoke();
    }
}
