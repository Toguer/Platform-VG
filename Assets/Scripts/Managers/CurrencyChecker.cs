using UnityEngine;

public class CurrencyChecker : MonoBehaviour
{
    public static CurrencyChecker cc;
    [SerializeField] private hardCurrencyBBDD _hardCurrencySave;

    public hardCurrencyBBDD HardCurrencySave
    {
        get => _hardCurrencySave;
        set => _hardCurrencySave = value;
    }


    [SerializeField] private softCurrency _softCurrency;


    public softCurrency SoftCurrency
    {
        get => _softCurrency;
        set => _softCurrency = value;
    }
    
    void Awake()
    {
        _hardCurrencySave.SearchLvl();
        if (cc == null)
        {
            cc = this;
            DontDestroyOnLoad(cc);
        }
        else
        {
            Destroy(this);
        }
    }
}