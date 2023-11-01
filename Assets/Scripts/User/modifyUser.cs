﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class modifyUser : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private userList _userList;
    
    public void ModifyUser()
    {
        _userList.Modify(_inputField.text);
    }

    public void ModifyWorld(string world)
    {
        _userList.ModifyWorld(world);
    }
}
