using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Audio_menager>().Play("Fogueira");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
