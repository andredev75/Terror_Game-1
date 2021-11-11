using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa_Audio_Geral : MonoBehaviour
{
    public AudioClip play_audio;
    public float volume;
    AudioSource audio;
    public bool playing = false;

    public void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter()
    {
        if (!playing)
        {
            audio.PlayOneShot(play_audio, volume);
            playing = true;
        }
    }


}
