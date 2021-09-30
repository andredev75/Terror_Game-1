using UnityEngine.Audio;
using System;
using UnityEngine;

public class Audio_menager : MonoBehaviour
{

    public Sound[] sounds;

    public static Audio_menager instance;
    // Start is called before the first frame update
    void Awake()
    {

        //if (instance == null)
            //instance = this;
        //else 
        //{
            //Destroy(gameObject);
            //return;
        //}
        //DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
           s.source.clip = s.clip;
           s.source.outputAudioMixerGroup = s.group;

           s.source.volume = s.volume;
           s.source.pitch = s.pitch;
           s.source.loop  = s.loop;
        }  
    }

    public void Start() 
    {
        //Play("Ambiente");

       
            Play("Theme");
        

    }

  
    public void Play (string name)
    {
        
        Sound s = Array.Find(sounds,sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + "Não encontrado");
            return;
        }
            
        s.source.Play();
    }




















}
