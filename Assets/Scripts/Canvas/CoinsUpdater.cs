using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class CoinsUpdater : MonoBehaviour
{
    private Text _text;
    private Random rndNum = new Random();
    private int newCoinsValue, totalCoinsValue;
    
    [SerializeField] private softCurrency _softCurrency;

    void Start()
    {
        _text = GetComponent<Text>();
        GameEvents.Instance.moreCoins += CoinsUpdate;
    }

    void CoinsUpdate()
    {
        newCoinsValue = rndNum.Next(1, 6);
        totalCoinsValue += newCoinsValue;
        _text.text = totalCoinsValue.ToString();
    }

    void CoinsSave()
    {
        _softCurrency.INTValue = totalCoinsValue;
    }

    private void OnEnable()
    {
        collisionsNoPhysics.onEnd += CoinsSave;
    }

    private void OnDisable()
    {
        collisionsNoPhysics.onEnd -= CoinsSave;
    }
}
