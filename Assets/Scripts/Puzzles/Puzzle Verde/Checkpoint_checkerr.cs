using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_checkerr : MonoBehaviour
{
    public Player_Controller player;

    private Camera cam;
    public float ray_distance = 3f;



    private int num = 0;
    private int next_Check = 0;
    public Collider other1;
    public Collider other2;
    public Collider other3;

    public bool passou1 = false;
    public bool passou2;
    public bool passou3;

    private int next_Checkpoint = 0;

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

                    if (hit.transform.gameObject.GetComponent<Checkpoints>().checknumber == 0 && passou1 == false)
                    {
                        Debug.Log("acertou");
                        passou1 = true;
                        FindObjectOfType<Audio_menager>().Play("Acertou_puzzle");

                    }

                    if (hit.transform.gameObject.GetComponent<Checkpoints>().checknumber == 1 && passou1 == true)
                    {
                        Debug.Log("acertou");
                        passou2 = true;
                        FindObjectOfType<Audio_menager>().Play("Acertou_puzzle");
                    }


                    if (hit.transform.gameObject.GetComponent<Checkpoints>().checknumber == 2 && passou2 == true)
                    {
                        Debug.Log("venceu o puzzle Azul");
                        FindObjectOfType<Audio_menager>().Play("Terminou_puzzle");
                        Player_Controller.instance.Checkpoint_Check_Azul();
                    }



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




}
