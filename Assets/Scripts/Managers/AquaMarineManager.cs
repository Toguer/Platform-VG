using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AquaMarineManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Aquas;
    //[SerializeField] private int lvl;

    [SerializeField] private hardCurrencyBBDD hardCurrency;
    [SerializeField] private Text aquaText;
    private int aquaNum;

    void Start()
    {
        aquaNum = 0;
        aquaText.text = aquaNum.ToString();
        for (int i = 0; i < 3; i++)
        {
            if (hardCurrency.Coins[i] == true)
            {
                Aquas[i].gameObject.SetActive(false); //Si teniamos las monedas de otra vez no las tenemos que volver a recoger.
            }
            else
            {
                Aquas[i].gameObject.SetActive(true);
            }
        }
    }

    void aquaTake() //Metodo para que el jugador tenga feedback visual.
    {
        aquaNum++;
        aquaText.text = aquaNum.ToString(); 
    }

    void checkAqua() //Cuando se acaba el nivel se ejecuta este metodo. 
    {
        Debug.Log("Event called correctly");
        for (int i = 0; i < 3; i++)
        {
            if (Aquas[i].gameObject == null)
            {
                Debug.Log("Moneda numero:" + i + " cogida");
                hardCurrency.Coins[i] = true;
            }
        }

        hardCurrency.saveLvl(); // Con este metodo guardamos los cambios en un xml.
    }



    private void OnEnable()
    {
        collisionsNoPhysics.onEnd += checkAqua;
        collisionsNoPhysics.onAqua += aquaTake;
    }

    private void OnDisable()
    {
        collisionsNoPhysics.onEnd -= checkAqua;
    }
}