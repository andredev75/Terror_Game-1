using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seila : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Audio_menager>().Play("Fogueira");
        //FindObjectOfType<Audio_menager>().Play("chuva");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
