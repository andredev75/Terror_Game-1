using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_passos : MonoBehaviour
{

    CharacterController controller;


    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    void Update()
    {
        if (controller.isGrounded == true && controller.velocity.magnitude > 1f && GetComponent<AudioSource>().isPlaying == false)
        {

            GetComponent<AudioSource>().Play();
        }

    }
}
