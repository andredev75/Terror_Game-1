using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armadilha_temp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
         Destroy(gameObject,1f);   
    }
}
