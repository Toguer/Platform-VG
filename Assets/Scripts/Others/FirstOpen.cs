using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class FirstOpen : MonoBehaviour
{
    private string filePath = "./saves";
    [SerializeField] private Text _Run;

    [SerializeField] private BBDD bbddAccess;
    void Awake()
    {
        Debug.Log(SystemInfo.operatingSystemFamily);
        var CreateFoldaPath = Application.persistentDataPath + "/saves";
        string file = "./saves";
        _Run.text = Application.platform.ToString();
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            filePath = "./saves/saves.xml";
            Debug.Log("Usando Windows");
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(file);
                bbddAccess.Create();
            }
            else
            {
                filePath = Application.persistentDataPath + "/saves/saves.xml";
                if (!File.Exists(filePath))
                {
                    bbddAccess.Create();
                }
            }
        }
        else
        {
            Directory.CreateDirectory(CreateFoldaPath);
            bbddAccess.Create();
        }

    }

}
