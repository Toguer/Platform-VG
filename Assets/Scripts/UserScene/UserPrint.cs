using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UserPrint : ScriptableObject
{
    [SerializeField] protected userList _userList;
    [SerializeField] protected GameObject button;
    //[SerializeField] protected GameObject content;

    public abstract void AddToList();
    public abstract void PrintList(GameObject content);

    //public abstract void UserDelete();
}