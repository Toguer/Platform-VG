using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManagment : MonoBehaviour
{
    [SerializeField] private List<ShopItems> _playerSkinsList;
    [SerializeField] private Image _img;
    [SerializeField] private PlayerSkinActual _skinActual;
    Player _playerSearcher;
    private int _selected;
    
    public void SkinSelected()
    {
        for (int i = 0; i < _playerSkinsList.Count; i++)
        {
            if (_img.sprite == _playerSkinsList[i].Image)
            {
                _skinActual.skin = _playerSkinsList[i];
                _selected = i;
            }
        }
        Debug.Log("La skin seleccionada es: " + _playerSkinsList[_selected]._name);
    }
}