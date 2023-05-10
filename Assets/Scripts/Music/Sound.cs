using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public AudioClip clip;
    [HideInInspector]
    public AudioSource source;
    public string name;
    public bool loop;
    public float volume=100;

}
