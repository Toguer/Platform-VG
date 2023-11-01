using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BBDD/DataSql", order = 1)]
public class DataSql : CurrencySerialize
{
    public override void serialize(string userSelected)
    {
        Debug.Log("Serializing...");
    }

    protected override void SaveCoins(string file, XmlDocument xmlDoc, string userSelected)
    {
        Debug.Log("Coins saved.");
        Debug.Log("Serialized!");
    }

    public override int deserialize(string userSelected)
    {
        return coins;
    }
}
