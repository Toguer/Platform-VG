using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class hardCurrencyBBDD : ScriptableObject
{
    [SerializeField] protected string world;
    [SerializeField] protected List<bool> coins;
    [SerializeField] protected SelectedUser selectedUser;
    [SerializeField] protected int lvl;


    public List<bool> Coins
    {
        get => coins;
        set => coins = value;
    }

    public abstract void SearchLvl();
    public abstract void saveLvl();
}