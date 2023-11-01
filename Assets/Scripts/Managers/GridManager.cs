using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Tilemap _frontMap;


    public void mapChange()
    {
        if (_frontMap.isActiveAndEnabled)
        {
            _frontMap.gameObject.SetActive(false);
        }
        else
        {
            _frontMap.gameObject.SetActive(true);
        }
    }
}