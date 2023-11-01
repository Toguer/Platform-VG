using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BBDD/UserPrintSQL", order = 1)]
public class PrintAndReadSql : UserPrint
{
    public override void AddToList()
    {
        Debug.Log("Users added to List");
    }

    public override void PrintList(GameObject content)
    {
        Debug.Log("Sql not implemented");
    }
/*
    public override void UserDelete()
    {
        throw new System.NotImplementedException();
    }*/
}