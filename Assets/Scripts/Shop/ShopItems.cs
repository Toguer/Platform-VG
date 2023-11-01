using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ShopItems", menuName = "ScriptableObject/ShopItems")]
public class ShopItems : ScriptableObject
{
    public static event Action<Sprite> ONBOOLUpdate = delegate { };
    public Sprite Image;
    public RuntimeAnimatorController Animator;
    public int Price;
    [SerializeField]private bool isBuy;
    public string _name;

    public bool IsBuy
    {
        get => isBuy;
        set
        {
            isBuy = value;
            updateBuy();
            Debug.Log("Set");
        }
    }
    
    void updateBuy()
    {
        ONBOOLUpdate.Invoke(Image);
    }

}
