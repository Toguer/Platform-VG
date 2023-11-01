using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/IntVariable", order = 1)]
public class IntVariable : ScriptableObject
{
    [SerializeField] protected int intValue;
    [SerializeField] protected SelectedUser _selectedUser;

    

    public int INTValue
    {
        get => intValue;
        set
        {
            intValue = value;
            OnValidate();
            // info.Coins = intValue;
            // info.serialize(_selectedUser.UserName);
        }
    }

    public event Action ONINTUpdate = delegate { };

    

    public void OnValidate()
    {
        ONINTUpdate.Invoke();
    }
}