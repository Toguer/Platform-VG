using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyAdd : MonoBehaviour
{
    [SerializeField] private userList _userList;

    public void ModifyLevelKey(string world, string level, string key)
    {
        _userList.ModifyKey(world, level, key);
    }
}
