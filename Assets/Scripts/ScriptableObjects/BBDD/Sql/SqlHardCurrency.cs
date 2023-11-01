using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BBDD/SqlHardCurrency")]
public class SqlHardCurrency : hardCurrencyBBDD
{
    public override void SearchLvl()
    {
        Debug.Log("Searching Lvl on SQL");
    }

    public override void saveLvl()
    {
        Debug.Log("Saving Lvl on SQL");
    }
}
