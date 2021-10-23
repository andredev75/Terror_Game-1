using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_checkerr : MonoBehaviour
{
    public Player_Controller player;

    private Camera cam;
    public float ray_distance = 3f;

    public Collider other1;
    public Collider other2;
    public Collider other3;
    private int num = 0;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 ray_center = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));
        if (Physics.Raycast(ray_center, cam.transform.forward, out hit, ray_distance))
        {
            if (hit.collider.GetComponent<teste>())
            {
                UI_Menager.instance.cursor(true);
                if (Input.GetMouseButtonDown(0))
                {
                    Check_Interec_Puzzle_Azul();
                }

            }


        }


    }

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


    }


    void Check_Interec_Puzzle_Azul()
    {
        Debug.Log("passou" + other1.GetComponent<Checkpoints>().checknumber);
        player.Checkpoint_Check_Azul(other1.GetComponent<Checkpoints>().checknumber);

    }


}
