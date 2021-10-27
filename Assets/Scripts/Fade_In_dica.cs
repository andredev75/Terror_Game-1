using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fade_In_dica : MonoBehaviour
{
    public GameObject Fade;
    public float Esperar_prox = 10f;
    public bool gatilho_delete = false;

    void Update()
    {
        if (gatilho_delete == true)
        {
            Esperar_prox -= Time.deltaTime;
            if (Esperar_prox <= 0)
            {
                Fade.SetActive(false);
                Destroy(gameObject);
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        Fade.SetActive(true);
        gatilho_delete = true;
    }
}
