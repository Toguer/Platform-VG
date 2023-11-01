using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class ShopManager : MonoBehaviour
{
    #region Singlton:Shop
    public static ShopManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
    #endregion

    [SerializeField] softCurrency coins;
 
    public List<ShopItems> ShopItems;

    GameObject ItemTemplate;
    GameObject g;
    [SerializeField] Transform ShopScroll;
    Button buybutton;

    private void Start()
    {
        ItemTemplate = ShopScroll.GetChild(0).gameObject;
        int len = ShopItems.Count;

        for (int i = 0; i < len; i++)
        {
            g = Instantiate(ItemTemplate, ShopScroll);
            
            g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItems[i].Image;
            if(!ShopItems[i].IsBuy)
            {
                g.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = ShopItems[i].Price.ToString();
            }
            else
            {
                g.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Bought";
            }
            g.name = i.ToString();
            buybutton = g.transform.GetComponent<Button>();
            buybutton.interactable = !ShopItems[i].IsBuy;
            
        }
        Destroy(ItemTemplate);
    }

    public void OnShopClicked(GameObject button)
    {
        if(HasEnoughCoins(ShopItems[Int32.Parse(button.name)].Price))
        {
            UseCoins(ShopItems[Int32.Parse(button.name)].Price);
            ShopItems[Int32.Parse(button.name)].IsBuy = true;


            buybutton = ShopScroll.GetChild(Int32.Parse(button.name)).GetComponent<Button>();
            buybutton.interactable = false;
            buybutton.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Bought";
        }
        else
        {
            Debug.Log("NO TIENES DINERO");
        }
    }

    public void UseCoins(int amount)
    {
        coins.INTValue -= amount;
    }
    public bool HasEnoughCoins(int amount)
    {
        return (coins.INTValue >= amount);
    }
}
