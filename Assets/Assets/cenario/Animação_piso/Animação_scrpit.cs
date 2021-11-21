using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animação_scrpit : MonoBehaviour
{
    public Animator controle;

    // Start is called before the first frame update
    void Start()
    {
        controle = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("tocou");
            controle.SetInteger("acao", 1);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("saindo");
            controle.SetInteger("acao", 2);

        }

    }
}
