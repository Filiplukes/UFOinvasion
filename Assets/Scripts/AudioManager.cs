using System;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public static AudioManager instance;

    private void Awake()
    {
        var activeS = PlayerPrefs.GetString("SoundActive");
        var activeM = PlayerPrefs.GetString("MusicActive");

        if (instance == null)
        {

            instance = this;

        }
        else {        

            Destroy(gameObject);
            return;
        
        }

        DontDestroyOnLoad(this);
        foreach (Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            if (activeM == "1" && s.nameSound == "BackGround")
            {
                s.audioSource.volume = 0;
            }
            else if (activeS == "1" && s.nameSound != "BackGround")
            {
                s.audioSource.volume = 0;
            }
            else
            {
                s.audioSource.volume = s.volume;
            }

            
            s.audioSource.clip = s.clip;
            s.audioSource.loop = s.loop;
           
        }
    }

    private void Start()
    {
        Play("BackGround");
    }
    public void Play(String name) {



        Sound s = Array.Find(sounds ,sound => sound.nameSound == name);
        if(s == null)
        {
            Debug.Log("Nenaslo Hudbu");
            return;
        }
    
        s.audioSource.Play();
    }


    public void Stop(String name)
    {
      
        Sound s = Array.Find(sounds, sound => sound.nameSound == name);
        if (s == null)
        {
            return;
        }

        s.audioSource.Stop();
    }

    public void setVolume() {


        foreach (Sound s in sounds)
        {
            var activeS = PlayerPrefs.GetString("SoundActive");
            var activeM = PlayerPrefs.GetString("MusicActive");
            if (activeM == "1" && s.nameSound == "BackGround")
            {
                s.audioSource.volume = 0;
            }
            else if (activeS == "1" && s.nameSound != "BackGround")
            {
                s.audioSource.volume = 0;
            }
            else {
                s.audioSource.volume = s.volume;
            }

            
            

        }


    }


}
