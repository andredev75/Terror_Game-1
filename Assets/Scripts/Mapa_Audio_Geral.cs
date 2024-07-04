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

    public string OrcLegenda1 = "[ORC] \n  Este lugar não me parece muito amigável, Elfo. Fique aqui. Vou investigar o  lugar. Acharei uma saída e alguma erva que possa ajudar na tua cura..... Hmmm… Isto aqui deve abrir pelo outro lado. ";

    public void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!playing)
        {
            audio.PlayOneShot(play_audio, volume);
            playing = true;
            if(this.gameObject.name == "Tag_sonora_narrador_5 (1)")
            {
                UI_Menager.instance.Set_Legend(OrcLegenda1);
            }

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
