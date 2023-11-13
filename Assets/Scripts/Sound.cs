
using UnityEngine;
[System.Serializable]
public class Sound
{
    public string nameSound;
    public AudioClip clip;
    [Range(0f, 1f)] 
    public float volume;
    public bool loop;
    [HideInInspector]
    public AudioSource audioSource;




}
