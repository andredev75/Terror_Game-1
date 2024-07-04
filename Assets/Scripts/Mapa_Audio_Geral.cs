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

    string OrcLegenda1 = "[ORC] \n  Este lugar não me parece muito amigável, Elfo. Fique aqui. Vou investigar o  lugar. Acharei uma saída e alguma erva que possa ajudar na tua cura..... Hmmm… Isto aqui deve abrir pelo outro lado. ";
    string LegendaNarrador1 = "[Voz suave] \n Cansaço… Sede… Mas resista…";
    string LegendaNarrador2 = "[Voz suave] \n  Pela direita… É tranquilo pela direita… ";
    string LegendaNarrador3 = "[Voz suave]\n Por aqui. Siga adiante. ";
    string OrcLegendaNarrador5 = "[ORC] \n Divindades… Definitivamente estou em um santuário. Por sorte, vazio, suponho. Eu matei todos estes malditos.Este caminho está selado por magia… Preciso descobrir uma maneira para quebrar este selo.";
    string OrcLegendaSalaFogo = "[ORC] \n Ah! Gullnastulku! A menina nascida no fogo… A visão da deusa… Preciso desta magia neste lugar… Esse enigma pode me conceder tal benção… ";
    string OrcLegendaSalaAgua = "[ORC] \n Um santuário de Vatnsfriga, Senhora das Aguas…  Um enigma kaltz… Deve liberar algum dos segredos deste lugar… ";
    string OrcLegendaSalaVerde1 = "[ORC] \n Estas árvores com certeza já vi antes são Gamall e cequim, as árvores sagradas de Reilomodir a Mãe de Todas as Mães Todas estas palavras nas paredes… Deve haver um segredo por detrás delas.";
    string OrcLegendaSalaVerde2 = "[Voz suave] \n Todas estas palavras nas paredes… Deve haver um segredo por detrás delas… ]";
    string OrcLegendaSalaSantuario = "[Voz suave] \n Velkominn, Kaeri Herra, Bertio Gare!";
    
    
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

            if(this.gameObject.name == "Tag_sonora_narrador_1")
            {
                UI_Menager.instance.Set_Legend(LegendaNarrador1);
            }

            if(this.gameObject.name == "Tag_sonora_narrador_2")
            {
                UI_Menager.instance.Set_Legend(LegendaNarrador2);
            }

            if(this.gameObject.name == "Tag_sonora_narrador_3 (1)")
            {
                UI_Menager.instance.Set_Legend(LegendaNarrador3);
            }

            if(this.gameObject.name == "Tag_sonora_narrador_5")
            {
                UI_Menager.instance.Set_Legend(OrcLegendaNarrador5);
            }

            if(this.gameObject.name == "Tag_sonora_gameplay_fogo_1")
            {
                UI_Menager.instance.Set_Legend(OrcLegendaSalaFogo);
            }

            if(this.gameObject.name == "Tag_sonora_gameplay_agua_1")
            {
                UI_Menager.instance.Set_Legend(OrcLegendaSalaAgua);
            }

            if(this.gameObject.name == "Gatilho_Esmeralda (2)")
            {
                UI_Menager.instance.Set_Legend(OrcLegendaSalaVerde1);
            }

            if(this.gameObject.name == "Gatilho_Esmeralda (3)")
            {
                UI_Menager.instance.Set_Legend(OrcLegendaSalaVerde2);
            }

            if(this.gameObject.name == "Gatilho_Narrador_Santuario (1)")
            {
                UI_Menager.instance.Set_Legend(OrcLegendaSalaSantuario);
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
