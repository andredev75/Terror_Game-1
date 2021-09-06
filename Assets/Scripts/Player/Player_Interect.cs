using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player_Interect : MonoBehaviour
{
    private Camera cam;
    public float ray_distance = 3f;
    private Interactables current_interactable;
    private Vector3 origin_position;
    private bool isviewer;

    public Transform object_viewer;
    private bool cam_finishi;

    public UnityEvent Onview;
    public UnityEvent On_finishi_viwer;

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

        if(isviewer)
        {
            if(cam_finishi && Input.GetMouseButtonDown(1))
            {
                finishi_viewer();
            }

            return;
        }



        RaycastHit hit;
        Vector3 ray_center = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));

        if (Physics.Raycast(ray_center, cam.transform.forward, out hit, ray_distance))
        {
            Interactables interactables = hit.collider.GetComponent<Interactables>();

            if(interactables != null)
            {
                UI_Menager.instance.cursor(true);
                if(Input.GetMouseButtonDown(0))
                {
                    if(interactables.ismoving)
                    {
                        return;
                    }

                    Onview.Invoke();

                    current_interactable = interactables;

                    isviewer = true;

                    Invoke("Cam_finishi", 1f);

                    if(current_interactable.item.isinteractable)
                    {
                        origin_position = current_interactable.transform.position;
                        StartCoroutine(Moving_Object(current_interactable, object_viewer.position));
                    }

                    
                }
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

    void Cam_finishi()
    {
        cam_finishi = true;
        UI_Menager.instance.Set_back_interactable(true);
    }

    void finishi_viewer ()
    {
        cam_finishi = false;
        isviewer = false;
        UI_Menager.instance.Set_back_interactable(false);

        if(current_interactable.item.isinteractable)
        {
            StartCoroutine(Moving_Object(current_interactable, origin_position));
        
        }

        On_finishi_viwer.Invoke();
    }


    IEnumerator Moving_Object (Interactables obj, Vector3 position)
    {
        obj.ismoving = true;
        float timer = 0f;
        while (timer < 1)
        {
            obj.transform.position = Vector3.Lerp(obj.transform.position, position, Time.deltaTime * 5);
            timer += Time.deltaTime;
            
            yield return null;
        }


        obj.transform.position = position;
        obj.ismoving = false;
    }


}
