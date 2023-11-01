using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public abstract class BBDD : ScriptableObject
{
    [SerializeField] protected gameTemplate _gameTemplate;
    [SerializeField] protected userList _userList;
    [SerializeField] protected SelectedUser _selectedUser;
    [SerializeField] protected TMP_InputField _inputField;

    protected string filename;
    public abstract void Create();
    protected abstract void createAllUsers(XmlNode rootNode, XmlDocument xmlDoc, int i);
    protected abstract void createWorlds(XmlNode userNode, XmlDocument xmlDoc, int i);
    public abstract void createUser();
    public abstract void RemoveUser();
    
    public abstract void ModifyUser(string newname);

    public abstract void ModifyWorld(string world);

    public abstract void ModifyCoins(int numCoins);
    public abstract void ModifyKey(string world, string level, string key);

}
