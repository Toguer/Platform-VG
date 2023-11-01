using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BBDD/CreacionXML")]
public class CreacionXML : BBDD
{
    private List<bool> coins;
    //[SerializeField] private gameTemplate _gameTemplate;
    //[SerializeField] private userList _userList;
    //string filename;
    //string file = "./saves/saves.xml";


    public override void Create()
    {
        XmlDocument xmlDoc = new XmlDocument();
        XmlNode rootNode = null;
        if (Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.WindowsEditor)
        {

            filename = "./saves/saves.xml";
            Debug.Log(filename);
        }
        else
        {
            filename = Application.persistentDataPath + "/saves/saves.xml";
        }


        if (System.IO.File.Exists(filename))
        {
            xmlDoc.Load(filename);
            rootNode = xmlDoc.SelectSingleNode("root");
        }
        else
        {
            rootNode = xmlDoc.CreateElement("root");
            xmlDoc.AppendChild(rootNode);
        }

        for (int i = 0; i < _userList.UserList.Count; i++)
        {
            createAllUsers(rootNode, xmlDoc, i);
        }
        /* for (int i = 0; i < _gameTemplate.Worlds.Count; i++)
         {
             createWorlds(rootNode, xmlDoc, i);
         }*/

        /*XmlNode worldNode = xmlDoc.CreateElement("World");
        //userNode.InnerText = "";
        XmlAttribute attribute = xmlDoc.CreateAttribute("name");
        attribute.Value = "Pradera";
        worldNode.Attributes.Append(attribute);
        rootNode.AppendChild(worldNode);
        */


        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Encoding = new UTF8Encoding(false); // Falso = no escribir BOM
        settings.Indent = true;
        XmlWriter writer = XmlTextWriter.Create(filename, settings);
        xmlDoc.Save(writer);
        writer.Close();
    }


    /* public bool Search(string world, int level, int coin)
     {
         bool resultado = false;
         XmlDocument xmlDoc = new XmlDocument();
         xmlDoc.Load("saves\\saves.xml");
         XmlNodeList itemNodes = xmlDoc.SelectNodes("//World[@name='" + world + "']/Level[@number='" + level + "']/Coin[@number='" + coin + "']");
         foreach (XmlNode itemNode in itemNodes)
         {
             resultado = itemNode.InnerText == "true";
         }
         return resultado;
     }*/

    protected override void createAllUsers(XmlNode rootNode, XmlDocument xmlDoc, int i)
    {
        XmlNode userNode = xmlDoc.CreateElement("User");
        XmlAttribute attribute = xmlDoc.CreateAttribute("name");
        attribute.Value = _userList.UserList[i];
        userNode.Attributes.Append(attribute);
        rootNode.AppendChild(userNode);
        for (int j = 0; j < _gameTemplate.Worlds.Count; j++)
        {
            createWorlds(userNode, xmlDoc, j);
        }
    }

    protected override void createWorlds(XmlNode userNode, XmlDocument xmlDoc, int i)
    {
        XmlNode worldNode = xmlDoc.CreateElement("World");
        //userNode.InnerText = ""; 
        XmlAttribute attribute = xmlDoc.CreateAttribute("name");
        attribute.Value = _gameTemplate.Worlds[i];
        worldNode.Attributes.Append(attribute);
        userNode.AppendChild(worldNode);
        for (int j = 1; j < _gameTemplate.Lvl + 1; j++)
        {
            XmlNode levelNode = xmlDoc.CreateElement("Level");
            attribute = xmlDoc.CreateAttribute("number");
            attribute.Value = "" + j + "";
            levelNode.Attributes.Append(attribute);
            worldNode.AppendChild(levelNode);

            for (int k = 1; k < 4; k++) // Always 1 and 4 coz always we have 3 coins.
            {
                XmlNode coinNode = xmlDoc.CreateElement("Key");
                attribute = xmlDoc.CreateAttribute("number");
                attribute.Value = k.ToString();
                coinNode.Attributes.Append(attribute);
                coinNode.InnerText = "false";
                levelNode.AppendChild(coinNode);
            }
        }
    }

    public override void createUser()
    {
        Debug.Log("Creating user in XML");
        XmlDocument xmlDoc = new XmlDocument();
        if (Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.WindowsEditor)
        {
            filename = "./saves/saves.xml";
        }
        else
        {
            filename = Application.persistentDataPath + "/saves/saves.xml";
        }

        xmlDoc.Load(filename);
        XmlNode rootNode = xmlDoc.SelectSingleNode("root");
        XmlNode userNode = xmlDoc.CreateElement("User");
        XmlAttribute attribute = xmlDoc.CreateAttribute("name");
        attribute.Value = _userList.UserList[_userList.UserList.Count - 1];
        userNode.Attributes.Append(attribute);
        rootNode.AppendChild(userNode);
        XmlNode coinNode = xmlDoc.CreateElement("coins");
        coinNode.InnerText = "" + 0;
        userNode.AppendChild(coinNode);
        for (int j = 0; j < _gameTemplate.Worlds.Count; j++)
        {
            createWorlds(userNode, xmlDoc, j);
        }

        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Encoding = new UTF8Encoding(false); // Falso = no escribir BOM
        settings.Indent = true;
        XmlWriter writer = XmlTextWriter.Create(filename, settings);
        xmlDoc.Save(writer);
        writer.Close();
    }

    /*  private void OnEnable()
      {
          _userList.ONUserAdd += createUser;
      }

      private void OnDisable()
      {
          _userList.ONUserAdd -= createUser;
      }
      */
    public override void RemoveUser()
    {
        XmlDocument xmlDoc = new XmlDocument();
        XmlNode rootNode = null;
        if (Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.WindowsEditor)
        {
            filename = "./saves/saves.xml";
            Debug.Log(filename);
        }
        else
        {
            filename = Application.persistentDataPath + "/saves/saves.xml";
        }
        xmlDoc.Load(filename);
        rootNode = xmlDoc.SelectSingleNode("root");
        XmlNodeList userNodes = xmlDoc.SelectNodes("//User[@name='" + _selectedUser.UserName + "']");
        XmlNode userNode = userNodes[0];
        rootNode.RemoveChild(userNode);

        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Encoding = new UTF8Encoding(false); // Falso = no escribir BOM
        settings.Indent = true;
        XmlWriter writer = XmlTextWriter.Create(filename, settings);
        xmlDoc.Save(writer);
        writer.Close();
    }

    public override void ModifyUser(string newname)
    {
        XmlDocument xmlDoc = new XmlDocument();
        XmlNode rootNode = null;
        if (Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.WindowsEditor)
        {
            filename = "./saves/saves.xml";
            Debug.Log(filename);
        }
        else
        {
            filename = Application.persistentDataPath + "/saves/saves.xml";
        }
        xmlDoc.Load(filename);
        rootNode = xmlDoc.SelectSingleNode("root");
        XmlNodeList userNodes = xmlDoc.SelectNodes("//User[@name='" + _selectedUser.UserName + "']");
        XmlNode userNode = userNodes[0];
        XmlAttribute attribute = userNode.Attributes[0];
        attribute.Value = newname;



        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Encoding = new UTF8Encoding(false); // Falso = no escribir BOM
        settings.Indent = true;
        XmlWriter writer = XmlTextWriter.Create(filename, settings);
        xmlDoc.Save(writer);
        writer.Close();

    }

    public override void ModifyWorld(string world)
    {
        XmlDocument xmlDoc = new XmlDocument();
        XmlNode rootNode = null;
        if (Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.WindowsEditor)
        {
            filename = "./saves/saves.xml";
            Debug.Log(filename);
        }
        else
        {
            filename = Application.persistentDataPath + "/saves/saves.xml";
        }
        xmlDoc.Load(filename);
        rootNode = xmlDoc.SelectSingleNode("root");
        XmlNodeList itemNodes = xmlDoc.SelectNodes("//User[@name='" + _selectedUser.UserName + "']/World[@name='" +
                                                   world + "']");
        if (itemNodes != null)
        {
            foreach (XmlNode worldNode in itemNodes)
            {
                XmlNodeList allWorldKeys = worldNode.SelectNodes(".//Key");
                if (allWorldKeys != null)
                {
                    foreach (XmlNode keyNode in allWorldKeys)
                    {
                        keyNode.InnerText = "true";
                    }
                }
            }
        }

        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Encoding = new UTF8Encoding(false); // Falso = no escribir BOM
        settings.Indent = true;
        XmlWriter writer = XmlTextWriter.Create(filename, settings);
        xmlDoc.Save(writer);
        writer.Close();
    }
    public override void ModifyKey(string world, string level, string key)
    {
        XmlDocument xmlDoc = new XmlDocument();
        XmlNode rootNode = null;
        if (Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.WindowsEditor)
        {
            filename = "./saves/saves.xml";
            Debug.Log(filename);
        }
        else
        {
            filename = Application.persistentDataPath + "/saves/saves.xml";
        }
        xmlDoc.Load(filename);
        rootNode = xmlDoc.SelectSingleNode("root");
        XmlNodeList itemNodes = xmlDoc.SelectNodes($"//User[@name='{_selectedUser.UserName}']/World[@name='{world}']/Level[@number='{level}']/Key[@number='{key}']");

        if (itemNodes != null)
        {
            foreach (XmlNode keyNode in itemNodes)
            {
                keyNode.InnerText = "true";
            }
        }

        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Encoding = new UTF8Encoding(false); // Falso = no escribir BOM
        settings.Indent = true;
        XmlWriter writer = XmlTextWriter.Create(filename, settings);
        xmlDoc.Save(writer);
        writer.Close();
    }

    public override void ModifyCoins(int numCoins)
    {
        XmlDocument xmlDoc = new XmlDocument();
        XmlNode rootNode = null;
        if (Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.WindowsEditor)
        {
            filename = "./saves/saves.xml";
            Debug.Log(filename);
        }
        else
        {
            filename = Application.persistentDataPath + "/saves/saves.xml";
        }
        xmlDoc.Load(filename);
        rootNode = xmlDoc.SelectSingleNode("root");
        XmlNodeList itemNodes = xmlDoc.SelectNodes($"//User[@name='{_selectedUser.UserName}']/coins");

        if (itemNodes != null)
        {
            foreach (XmlNode coinNode in itemNodes)
            {
                coinNode.InnerText = numCoins.ToString();
            }
        }

        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Encoding = new UTF8Encoding(false); // Falso = no escribir BOM
        settings.Indent = true;
        XmlWriter writer = XmlTextWriter.Create(filename, settings);
        xmlDoc.Save(writer);
        writer.Close();
    }

}