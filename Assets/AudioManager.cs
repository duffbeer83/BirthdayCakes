using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);  // still necessary?

        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("theme");    
    }

    public void Play(string name)
    {
        FindSound(name)?.source.Play();
    }

    public void ScalePitch(string name, float scale)
    {
        var s = FindSound(name);
        if (s == null)
            return;

        s.source.pitch = s.pitch * scale;
    }

    private Sound FindSound(string name)
    {
        var sound = Array.Find(sounds, s => s.name == name);
        if (sound == null)
            Debug.LogWarning($"Sound '{name}' not found");

        return sound;
    }
}
