using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestCoin : MonoBehaviour
{
    public TextMeshProUGUI canvas;
    [SerializeField]private softCurrency coin;
    

    private void Start()
    {
        coin.Deserialize();
        canvas.text= coin.INTValue.ToString();
    }

    private void change()
    {
        canvas.text = coin.INTValue.ToString();
    }

    private void OnEnable()
    {
        coin.ONINTUpdate += change;
    }
    private void OnDisable()
    {
        coin.ONINTUpdate -= change;
    }

}
