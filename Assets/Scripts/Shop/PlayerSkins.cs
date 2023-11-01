using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkins : MonoBehaviour
{
    #region Singlton:Shop
    public static PlayerSkins Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    #endregion
 
    public List<ShopItems> _shopItems;

    GameObject ItemTemplate;
    GameObject g;
    Button selectbutton;
    [SerializeField] Transform ShopScroll;
    [SerializeField] SkinManagment sm;
    public void Start()
    {
        ItemTemplate = ShopScroll.GetChild(0).gameObject;
        int len = _shopItems.Count;
        

        for (int i = 0; i < len; i++)
        {
            if (_shopItems[i].IsBuy)
            {
                Debug.Log(_shopItems[i]._name);
                g = Instantiate(ItemTemplate, ShopScroll);
                g.transform.GetChild(0).GetComponent<Image>().sprite = _shopItems[i].Image;
                selectbutton = g.transform.GetComponent<Button>();
                selectbutton.name = i.ToString();
            }
        }
        ItemTemplate.SetActive(false);
        //Destroy(ItemTemplate);
        //UdpateShop();
    }
    public Image selected;


    public void select(GameObject button)
    {
        selected.sprite = _shopItems[Int32.Parse(button.name)].Image;
        sm.SkinSelected();
    }
    public void UdpateShop(Sprite sp)
    {
        Debug.Log("Añadido alguien");
        g = Instantiate(ItemTemplate, ShopScroll);
        g.transform.GetChild(0).GetComponent<Image>().sprite = sp;
    }

    private void OnEnable()
    {
        ShopItems.ONBOOLUpdate += UdpateShop;
    }



    private void OnDestroy()
    {
        ShopItems.ONBOOLUpdate -= UdpateShop;
    }

}
