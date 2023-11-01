using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyUnlocker : MonoBehaviour
{
    public keyAdd script;

    [SerializeField] private string _world;
    [SerializeField] private string _level;
    [SerializeField] private string _key;

    public void Unlock()
    {
        script.ModifyLevelKey(_world,_level,_key);
    }
}
