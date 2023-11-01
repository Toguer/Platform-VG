using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BBDD/SqlSelect")]
public class SqlSelect : BBDDSelect
{

    public override bool CheckFullWorld(int worldNum)
    {
        return true;
    }

    public override bool CheckLvl(int world, int lvl)
    {
        return true;
    }
}
