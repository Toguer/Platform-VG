using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Xml;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BBDD/SelectXML")]
public class XmlSelect : BBDDSelect
{
    public override bool CheckFullWorld(int worldNum)
    {
        /*bool[] coins = new bool[gameTemplate.Worlds.Count];
        ;
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("saves\\saves.xml");
        for (int i = 0; i < gameTemplate.Worlds.Count; i++)
        {
            bool[] coinsLvl = new bool[gameTemplate.Lvl];
            for (int j = 0; j < gameTemplate.Lvl; j++)
            {
                coinsLvl[j] = checkLvl(gameTemplate.Worlds[i], j);

                //XmlNodeList itemNodes = xmlDoc.SelectNodes("//World[@name='" + gameTemplate.Worlds[i] + "']/Level[@number='" + i + "']");    
            }
        }*/
        bool[] checkAllCoins = new bool[gameTemplate.Lvl];
        for (int i = 0; i < gameTemplate.Lvl; i++)
        {
            checkAllCoins[i] = CheckLvl(worldNum, i + 1);
        }

        if (checkAllCoins[0] && checkAllCoins[1])
        {
            return true;
        }

        return false;

        bool allTrue = checkAllCoins.All(coin => coin = true);
        return allTrue;
    }


    public override bool CheckLvl(int world, int lvl)
    {
        bool[] coins = new bool[3];
        ;
        XmlDocument xmlDoc = new XmlDocument();
        string filename;
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

        XmlNodeList itemNodes =
            xmlDoc.SelectNodes("//User[@name='" + _selectedUser.UserName + "']/World[@name='" +
                               gameTemplate.Worlds[world] + "']/Level[@number='" + lvl + "']");
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("FOR");
            if (itemNodes[0].ChildNodes[i].InnerText == "true")
            {
                coins[i] = true;
                Debug.Log(itemNodes[0].ChildNodes[i].InnerText);
                // Debug.Log("TRUE");
            }
            else
            {
                Debug.Log(itemNodes[0].ChildNodes[i].InnerText);
                //Debug.Log("FALSE");
                coins[i] = false;
            }
        }

        if (coins[0] && coins[1] && coins[2])
        {
            Debug.Log(coins[0]);
            return true;
        }

        return false;
    }
}