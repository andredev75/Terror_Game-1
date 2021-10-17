using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_checkerr : MonoBehaviour
{
    public Player_Controller player;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Checkpoint_Verde")
        {

            //Debug.Log("passou" + other.GetComponent<Checkpoints>().checknumber);
            player.Checkpoint_Check_Verde(other.GetComponent<Checkpoints>().checknumber);
        }

        if (other.tag == "Checkpoint_Vermelho")
        {

            //Debug.Log("passou" + other.GetComponent<Checkpoints>().checknumber);
            player.Checkpoint_Check_Vermelho(other.GetComponent<Checkpoints>().checknumber);
        }

        if (other.tag == "Checkpoint_Azul")
        {

            Debug.Log("passou" + other.GetComponent<Checkpoints>().checknumber);
            player.Checkpoint_Check_Azul(other.GetComponent<Checkpoints>().checknumber);
        }
    }
}
