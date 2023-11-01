using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BBDD/UserPrintXML", order = 1)]
public class UserPrintAndReadXml : UserPrint
{

    public override void AddToList()
    {
        string filename;
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            filename = "/saves/saves.xml";
        }
        else
        {
            filename = Application.persistentDataPath + "/saves/saves.xml";
        }
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(filename);
        XmlNodeList userNodes = xmlDoc.SelectNodes("//User");
        //  Debug.Log(userNodes.Count);
        for (int i = 1; i <= userNodes.Count; i++)
        {
            //  Debug.Log(userNodes[i - 1].Attributes[0].Value);
            //Debug.Log(userNodes[i-1].Value);
            Debug.Log(i - 1 + "valor");
            //  _userList.UserList[i-1] = userNodes[i-1].Value;
            _userList.addUser(userNodes[i - 1].Attributes[0].Value);
        }
    }

    public override void PrintList(GameObject content)
    {

        for (int i = 0; i < content.transform.childCount; i++)
        {
            Destroy(content.transform.GetChild(i).gameObject);
        }
        if (_userList.UserList.Count <= 0)
        {
            Debug.Log("No hay usuarios en la lista");
        }
        else
        {
            for (int i = 0; i < _userList.UserList.Count; i++)
            {
                Debug.Log("Instantiate user");
                GameObject b = Instantiate(button, content.transform);
                b.GetComponent<userSelection>().UserIndex = i;
                b.GetComponentInChildren<TextMeshProUGUI>().text = _userList.UserList[i];
            }
        }
        
    }

}