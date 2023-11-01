using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSkin : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerSkinActual _skinActual;


    void Start()
    {
        LoadSkin();
    }

    public void LoadSkin()
    {
        _spriteRenderer.sprite = _skinActual.skin.Image;
        _animator.runtimeAnimatorController = _skinActual.skin.Animator;
    }
}
