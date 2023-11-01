using System;
using System.Text;
using System.Xml;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BBDD/DataXml", order = 1)]
public class DataXML : CurrencySerialize
{
    private int coins;

    public int Coins
    {
        get => coins;
        set => coins = value;
    }

    public override void serialize(string userSelected)
    {
        string file;
        XmlDocument xmlDoc = new XmlDocument();
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            file = "/saves/saves.xml";
        }
        else
        {
            file = Application.persistentDataPath + "/saves/saves.xml";
        }
        xmlDoc.Load(file);
        SaveCoins(file, xmlDoc, userSelected);
    }

    protected override void SaveCoins(string file, XmlDocument xmlDoc, string userSelected)
    {
        XmlNode userNode = xmlDoc.SelectSingleNode("//User[@name='" + userSelected + "']");
        XmlNode coinNode = xmlDoc.SelectSingleNode("//User[@name='" + userSelected + "']/coins");
        if (coinNode != null)
        {
            Debug.Log("CoinNode no encontrado");
            coinNode.InnerText = "" + Coins;
            //userNode.AppendChild(coinNode);    
        }
        else
        {
            coinNode = xmlDoc.CreateElement("coins");
            coinNode.InnerText = "" + Coins;
            //userNode.AppendChild(coinNode);
        }


        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Encoding = new UTF8Encoding(false); // Falso = no escribir BOM
        settings.Indent = true;
        XmlWriter writer = XmlTextWriter.Create(file, settings);
        xmlDoc.Save(writer);
    }

    public override int deserialize(string userSelected)
    {
        string file = "saves/saves.xml";
        if (Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.WindowsEditor)
        {
            file = "./saves/saves.xml";
        }
        else
        {
            file = Application.persistentDataPath + "/saves/saves.xml";
        }
        XmlDocument xmlDoc = new XmlDocument();
        Debug.Log("Deserialize");
        xmlDoc.Load(file);
        XmlNode userNode = xmlDoc.SelectSingleNode("//User[@name='" + userSelected + "']");
        return Int32.Parse(userNode.FirstChild.InnerText);
    }
}