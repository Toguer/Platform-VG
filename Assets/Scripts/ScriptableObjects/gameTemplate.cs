using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/gameTemplate")]
public class gameTemplate : ScriptableObject
{
    [SerializeField]private int lvl;
    [SerializeField]private List<String> worlds;

    public List<string> Worlds
    {
        get => worlds;
        set => worlds = value;
    }

    public int Lvl
    {
        get => lvl;
        set => lvl = value;
    }

    
}
