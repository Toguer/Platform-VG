using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class userAdd : MonoBehaviour
{

    [SerializeField] private userList _userList;
    [SerializeField] private TMP_InputField _userField;


    public void addUser()
    {
        _userList.addUser(_userField.text);
    }
}
