using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interect : MonoBehaviour
{
    private Camera cam;
    public float ray_distance = 3f;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Check_Interec();
    }

    void Check_Interec ()
    {
        RaycastHit hit;
        Vector3 ray_center = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));

        if (Physics.Raycast(ray_center, cam.transform.forward, out hit, ray_distance))
        {
            Interactables interactables = hit.collider.GetComponent<Interactables>();

            if(interactables != null)
            {
                UI_Menager.instance.cursor(true);
            }
            else
            {
                UI_Menager.instance.cursor(false);
            }

        }
        else
        {
            UI_Menager.instance.cursor(false);
        }
    }
}
