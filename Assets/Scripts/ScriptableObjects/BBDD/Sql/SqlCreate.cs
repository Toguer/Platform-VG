using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BBDD/SqlLiteCreate")]
public class SqlCreate : BBDD
{
    public override void Create()
    {
        /*for (int i = 0; i < _userList.UserList.Count; i++)
        {
            createAllUsers();
        }*/
        Debug.Log("Base de dades SqlLite Creada");
    }

    protected override void createAllUsers(XmlNode rootNode, XmlDocument xmlDoc, int i)
    {
        Debug.Log("Users created in SQL.");
    }

    protected override void createWorlds(XmlNode userNode, XmlDocument xmlDoc, int i)
    {
        Debug.Log("Worlds created.");
    }

    public override void createUser()
    {
        Debug.Log("User Created in SQL");
    }

    public override void RemoveUser()
    {
        Debug.Log("User Removed in SQL");
    }

    public override void ModifyUser(string newname)
    {
        Debug.Log("User name modify");
    }

    public override void ModifyWorld(string world)
    {
        Debug.Log("World keys modified");
    }

    public override void ModifyCoins(int numCoins)
    {
        Debug.Log("World keys modified");
    }

    public override void ModifyKey(string world, string level, string key)
    {
        throw new System.NotImplementedException();
    }
}
