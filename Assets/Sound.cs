using UnityEngine.Audio;
using UnityEngine;
using System;

[Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0, 1)]
    public float volume = 1f;
    [Range(0.1f, 3)]
    public float pitch = 1f;
    public bool loop = false;

    [HideInInspector]
    public AudioSource source;
}
