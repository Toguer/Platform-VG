using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AudioData : MonoBehaviour
{
    //NO LO USAMOS
    //List<Sound> audios = new List<Sound>();
    
    public string name;
    public AudioClip clip;


    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;


    public bool loop;
    public bool mute;
    public AudioSource source;
}
