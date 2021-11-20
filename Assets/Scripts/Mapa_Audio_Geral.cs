using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa_Audio_Geral : MonoBehaviour
{
    public AudioClip play_audio;
    public float volume;
    public string text;
    AudioSource audio;
    public bool playing = false;

    public int time;

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

            UI_Menager.instance.Set_Legend(text);
            StartCoroutine(Aguardar_sair_legend());
        }
    }


    private IEnumerator Aguardar_sair_legend()
    {
        //Debug.Log("entrou");
        yield return new WaitForSeconds(time);
        UI_Menager.instance.Set_Legend("");
    }


}
