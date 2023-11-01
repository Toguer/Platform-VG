using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Users/Selected User")]
public class SelectedUser : ScriptableObject
{
    [SerializeField] private int userIndex;

    public int UserIndex
    {
        get => userIndex;
        set => userIndex = value;
    }

    public string UserName
    {
        get => userName;
        set => userName = value;
    }

    [SerializeField] private string userName;
}