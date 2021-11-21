using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class susto : MonoBehaviour
{
    public AudioClip som_Susto;
    AudioSource audio;
    public float volume;
    public float velocida_movimento = 20;
    public float cronometro;
    public float tempo_destruir;
    public GameObject monstro;
    private BoxCollider[] colisore;
    private bool ativar;
    public bool contar;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        colisore = gameObject.GetComponents<BoxCollider>();
    }

    void Update()
    {
        if (ativar == true)
        {
            monstro.SetActive(true);
            transform.Translate(Vector3.forward * Time.deltaTime * velocida_movimento);
            cronometro += Time.deltaTime;
            Debug.Log("entrou");
        }

        if (cronometro >= tempo_destruir)
        {
            Debug.Log("entrou2");
            ativar = false;
            monstro.SetActive(false);
        }
    }

    void OnTriggerEnter()
    {
        foreach (BoxCollider colisore in colisore)
        {
            colisore.enabled = false;
        }

        audio.PlayOneShot(som_Susto, volume);
        Destroy(gameObject, audio.clip.length);
        ativar = true;
    }


}
