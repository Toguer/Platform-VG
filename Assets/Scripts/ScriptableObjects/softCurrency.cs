using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/IntVariable/softCurrency", order = 1)]
public class softCurrency : IntVariable
{
    [SerializeField]private CurrencySerialize info;

    public void Deserialize()
    {
        intValue = info.deserialize(_selectedUser.UserName);
    }
    public void OnValidate()
    {
        info.Coins = intValue;
        info.serialize(_selectedUser.UserName);
        base.OnValidate();
    }
}
