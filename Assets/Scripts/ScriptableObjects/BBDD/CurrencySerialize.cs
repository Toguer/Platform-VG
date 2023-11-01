using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public abstract class CurrencySerialize : ScriptableObject
{
    protected int coins;

    public int Coins
    {
        get => coins;
        set => coins = value;
    }

    public abstract void serialize(string userSelected);
    protected abstract void SaveCoins(string file, XmlDocument xmlDoc, string userSelected);
    public abstract int deserialize(string userSelected);
}
