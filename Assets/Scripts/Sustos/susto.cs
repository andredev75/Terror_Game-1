using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class susto : MonoBehaviour
{
    public AudioClip som_Susto;
    AudioSource audio;
    public float volume;
    public float velocida_movimento = 20;
    public float cronometro = 5;
    public float tempo_destruir;
    public GameObject monstro;
    private BoxCollider[] colisore;
    private bool ativar = false;
    public bool contar;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        monstro.SetActive(false);
    }

    void Update()
    {
        if (ativar == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * velocida_movimento);
            cronometro -= Time.deltaTime;
        }

        if (cronometro < 0)
        {
            Destroy(monstro);
            Destroy(gameObject, audio.clip.length);
        }

    }

    void OnTriggerEnter()
    {
        monstro.SetActive(true);
        FindObjectOfType<Audio_menager>().Play("Susto1");
        audio.PlayOneShot(som_Susto, volume);
        UI_Menager.instance.Set_Legend("[GRITO DESCONHECIDO]");
        StartCoroutine(ZerarLegenda(1));


        //Destroy(gameObject, audio.clip.length);
        ativar = true;
    }

    IEnumerator ZerarLegenda(int tempoLegenda)
    {
        yield return new WaitForSeconds(tempoLegenda);
        UI_Menager.instance.Set_Legend("");
    }


}
