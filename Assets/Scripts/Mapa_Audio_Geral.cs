using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa_Audio_Geral : MonoBehaviour
{
    public AudioSource play_Audio;
    public float Esperar_prox = 10f;
    public bool gatilho_delete = false;

    private void OnTriggerEnter(Collider other)
    {
        play_Audio.Play();
        gatilho_delete = true;
    }

    private void Update()
    {
        if (gatilho_delete == true)
        {
            Esperar_prox -= Time.deltaTime;
            if (Esperar_prox <= 0)
            {
                Destroy(gameObject);
            }

        }
    }
}
