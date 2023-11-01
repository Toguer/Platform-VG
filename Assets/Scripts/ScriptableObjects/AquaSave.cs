using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AquaSave", order = 2)]
public class AquaSave : ScriptableObject
{
    private XMLsave _xmLsave;
    [SerializeField] private List<bool> AquaCoins = new List<bool>();
    public List<bool> AquaCoins1
    {
        get => AquaCoins;
        set => AquaCoins = value;
    }
    
    [Serializable]
    public class XMLsave
    {
        [SerializeField] private List<bool> AquaC;

        public XMLsave()
        {
        }

        public List<bool> AquaC1
        {
            get => AquaC;
            set => AquaC = value;
        }

        public XMLsave(List<bool> aquaC)
        {
            AquaC = aquaC;
        }
    }

   /* public void save()
    {
        _xmLsave = new XMLsave(AquaCoins);
        var serializer = new XmlSerializer(typeof(XMLsave));
        var stream = new FileStream("saves/saves.xml", FileMode.Create);
        serializer.Serialize(stream, _xmLsave);
    }
*/
    public void load()
    {
        var serializer = new XmlSerializer(typeof(XMLsave));
        if (File.Exists("saves/saves.xml"))
        {
            var stream = new FileStream("saves/saves.xml", FileMode.Open);
            _xmLsave = serializer.Deserialize(stream) as XMLsave;
            AquaCoins = _xmLsave.AquaC1;
        }
    }
}