using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_checkerr : MonoBehaviour
{
    public Player_Controller player;

    private void OnTriggerEnter(Collider other) 
    {
       
       if (other.tag == "Checkpoint") 
       {

            //Debug.Log("passou" + other.GetComponent<Checkpoints>().checknumber);
            player.Checkpoint_Check(other.GetComponent<Checkpoints>().checknumber);  
       }
    }
}
