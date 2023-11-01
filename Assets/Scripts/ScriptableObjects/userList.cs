using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Users/User List")]
public class userList : ScriptableObject
{
    [SerializeField]private List<String> _userList;
    public event Action ONUserAdd = delegate { };
    [SerializeField] private BBDD _bbdd;
    [SerializeField] private SelectedUser _selectedUser;
    public List<string> UserList
    {
        get => _userList;
        set
        {
            _userList = value;
        }
    }


    public void addUser(String newUser)
    {


        _userList.Add(newUser);
            _bbdd.createUser();
        //ONUserAdd.Invoke();
        Debug.Log("Add user to List number: "+_userList.Count);
    }

    public void Remove()
    {
        _userList.Remove(_selectedUser.UserName);
        _bbdd.RemoveUser();
    }

    
    public void Modify(string newname)
    {
        for (int i = 0; i < _userList.Count; i++)
        {
            if (_userList[i] == _selectedUser.UserName)
            {
                _userList[i] = newname;
                _bbdd.ModifyUser(newname);
            }
        }
    }

    public void ModifyWorld(string world)
    {
        _bbdd.ModifyWorld(world);
    }

    public void ModifyCoins(string coins)
    {
        _bbdd.ModifyCoins(int.Parse(coins));
    }

    public void ModifyKey(string world, string level, string key)
    {
        _bbdd.ModifyKey(world,level,key);
    }
    
}
