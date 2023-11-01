using System.Collections.Generic;
using System.Text;
using System.Xml;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BBDD/XmlHardCurrency")]
public class XmlHardCurrency : hardCurrencyBBDD
{
    public override void SearchLvl()
    {
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

        XmlNodeList itemNodes = xmlDoc.SelectNodes("//User[@name='" + selectedUser.UserName + "']/World[@name='" +
                                                   world + "']/Level[@number='" + lvl + "']");

        for (int i = 0; i < 3; i++)
        {
            if (itemNodes[0].ChildNodes[i].InnerText == "true")
            {
                coins[i] = true;
            }
            else
            {
                coins[i] = false;
            }
        }

        //  return false; // provisional
    }

    public override void saveLvl()
    {
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

        XmlNodeList itemNodes = xmlDoc.SelectNodes("//User[@name='" + selectedUser.UserName + "']/World[@name='" +
                                                   world + "']/Level[@number='" + lvl + "']");
        for (int i = 0; i < 3; i++)
        {
            if (coins[i] == true)
            {
                itemNodes[0].ChildNodes[i].InnerText = "true";
            }
            else
            {
                itemNodes[0].ChildNodes[i].InnerText = "false";
            }
        }

        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Encoding = new UTF8Encoding(false); // Falso = no escribir BOM
        settings.Indent = true;
        XmlWriter writer = XmlTextWriter.Create(filename, settings);
        xmlDoc.Save(writer);
        writer.Close();
    }

    /* private void OnEnable()
     {
         collisionsNoPhysics.onEnd += saveLvl;
     }
 
     private void OnDisable()
     {
         collisionsNoPhysics.onEnd -= saveLvl;
     }*/
}