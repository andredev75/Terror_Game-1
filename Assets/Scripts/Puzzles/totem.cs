using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class totem : MonoBehaviour
{
    public Quaternion star;
    void Update()
    {
        star = transform.rotation;

        if(Input.GetKey(KeyCode.F))
        {
            rotate();
        }
        //contador = 0f,90f,0f;
    }

    public void rotate ()
    {
       //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(contador), Time.deltaTime);
        transform.rotation = star;

       
        
    }
}
