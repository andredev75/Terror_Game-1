using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Footsteps : MonoBehaviour
{
    private AudioSource fooststep_sound;

    [SerializeField]
    private AudioClip[] footstep_clip;
    private CharacterController controller;

    [HideInInspector]
    public float volume_min, volume_max;

    private float accumulated_distance;
    [HideInInspector]
    public float step_distance;


    void Awake()
    {

        fooststep_sound = GetComponent<AudioSource>();
        controller = GetComponentInParent<CharacterController>();


    }

    void Update()
    {
        checktoplayfootstepsound();
    }


    void checktoplayfootstepsound()
    {
        if (!controller.isGrounded)
        {
            return;
        }

        if (controller.velocity.magnitude > 2)
        {
            Debug.Log(controller.velocity.magnitude);

            accumulated_distance += Time.deltaTime;

            if (accumulated_distance > step_distance)
            {
                fooststep_sound.volume = Random.Range(volume_min, volume_max);
                fooststep_sound.clip = footstep_clip[Random.Range(0, footstep_clip.Length)];
                fooststep_sound.Play();

                accumulated_distance = 0f;
            }
        }

        else
        {
            accumulated_distance = 0f;
        }
    }
}
