using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance;
    private AudioSource source;

    public AudioClip title;
    public AudioClip gameplay;

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    public static void Title()
    {
        instance.source.clip = instance.title;
        instance.source.loop = true;
        instance.source.Play();

    }

    public static void Stop()
    {
        instance.source.Stop();
    }

    public static void Gameplay()
    {
        instance.source.loop = false;
        instance.source.clip = instance.gameplay;
        instance.source.Play();
    }

}
