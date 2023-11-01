using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingPlatformAnim : MonoBehaviour
{
    [SerializeField] Sprite _blueSprite;
    [SerializeField] Sprite _redSprite;
    SpriteRenderer _sr;
    ChangingPlatform _cp;
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _cp = GetComponent<ChangingPlatform>();
        GameEvents.Instance.movePlat += ChangePlatSprite;
    }

    void ChangePlatSprite()
    {
        if (_cp.Jumped)
        {
            SpriteBlue();
        }
        else if (!_cp.Jumped)
        {
            
            SpriteRed();
        }
    }
    
    void SpriteBlue()
    {
        _sr.sprite = _blueSprite;
    }

    void SpriteRed()
    {
        _sr.sprite = _redSprite;
    }
    
}
