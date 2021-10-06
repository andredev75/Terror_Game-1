using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resp_temp : MonoBehaviour
{
    
    public Transform tp;
    public GameObject player;

    public void OnTriggerEnter(Collider other) 
    {
        //player.transform.position = tp.transform.position;  

     if(other.gameObject.tag=="Teleport")
      {
            this.transform.position = tp.position;
           
            
      }

    }


     


}
