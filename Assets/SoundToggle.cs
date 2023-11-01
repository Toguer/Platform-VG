using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;

    public void MuteAll()
    {
        if (_toggle.isOn)
        {
            FindObjectOfType<AudioManager>().Mute();
            Debug.Log("MUTE");
        }
        else
        {
            FindObjectOfType<AudioManager>().OffMute();
            Debug.Log("MUTE OFF");
        }
    }
}
