using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    private static AudioManager music;
    public AudioSource BackMusic;
    public AudioSource sound;
    public AudioClip[] soundEffects;
    public AudioClip[] songs;

    public static AudioManager Instance
    {
        get
        {
            if (music == null)
            {
                music = GameObject.FindObjectOfType<AudioManager>();
            }
            return music;
        }
    }

    void Awake()
    {
        //if this doesn't exist yet...
        if (music == null)
            //set instance to this
            music = this;
        //If instance already exists and it's not this:
        else if (music != null && music != this)
            //Then destroy. Only ever be one instance of a GameManager.
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void StopMusic(int i)
    {
       BackMusic.Stop();
    }
    //make sure i is in range of songs (SONG BIBLE)
    public void PlaySong(int i)
    {
        BackMusic.Stop();
        BackMusic.clip = songs[i];
        BackMusic.Play();
        
    }
    //make sure i is in range
    public void PlaySoundEffect(int i)
    {
        sound.PlayOneShot(soundEffects[i]);
    }
/*
    public void PlayLoop(int i)
    {
        if (i==1)
        BackMusic.clip = songs[i];
        BackMusic.loop = true;
        BackMusic.Play();

    }*/
}