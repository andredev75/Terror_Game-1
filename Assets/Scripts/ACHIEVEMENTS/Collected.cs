using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collected : MonoBehaviour
{
    private Camera cam;
    public float ray_distance = 3f;

    public AudioSource collecsound;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {


        RaycastHit hit;
        Vector3 ray_center = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));
        if (Physics.Raycast(ray_center, cam.transform.forward, out hit, ray_distance))
        {
            if (hit.collider.GetComponent<teste1>())
            {
                UI_Menager.instance.cursor(true);
                if (Input.GetMouseButtonDown(0))
                {

                    ACHIEVEMENTS.ach01count += 1;
                    collecsound.Play();
                    Destroy(gameObject);


                }

            }


        }


    }
}
