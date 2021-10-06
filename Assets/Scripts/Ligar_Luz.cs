using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ligar_Luz : MonoBehaviour
{
    public GameObject luz1;
    public GameObject luz2;
    public GameObject luz3;
    private void OnTriggerEnter(Collider other) 
    {
        luz1.SetActive(true);
        luz2.SetActive(true);
        luz3.SetActive(true);
    }
}
