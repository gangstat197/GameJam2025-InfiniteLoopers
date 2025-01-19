using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Sound
{
    public string soundName;
    public AudioClip clip;
    [Range(0f,1f)]
    public float volume = 1f;
    [Range(0.1f, 3f)]
    public float pitch;
    public bool isLoop = false;
    [HideInInspector] public AudioSource source;

}
