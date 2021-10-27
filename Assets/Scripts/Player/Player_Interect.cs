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
    private Quaternion origin_rotation;
    public float rotate_speed;
    private bool isviewer;

    public Transform object_viewer;
    private bool cam_finishi;

    public UnityEvent Onview;
    public UnityEvent On_finishi_viwer;
    public UnityEvent Onview_control;
    public UnityEvent On_finishi_contrl;


    private Audio_P audioplayer;


    // Start is called before the first frame update
    void Start()
    {
        audioplayer = GetComponent<Audio_P>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Check_Interec();
    }

    void Check_Interec()
    {

        if (isviewer)
        {
            if (current_interactable.item.isinteractable && Input.GetMouseButton(0))
            {
                Rotateobject();
            }

            if (cam_finishi && Input.GetMouseButtonDown(1))
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

            if (interactables != null)
            {
                UI_Menager.instance.cursor(true);
                if (Input.GetMouseButtonDown(0))
                {
                    if (interactables.ismoving)
                    {
                        return;
                    }
                    UI_Menager.instance.cursor(false);
                    Onview.Invoke();
                    Onview_control.Invoke();

                    current_interactable = interactables;

                    isviewer = true;
                    Interacao(current_interactable.item);



                    if (current_interactable.item.isinteractable)
                    {
                        origin_position = current_interactable.transform.position;
                        origin_rotation = current_interactable.transform.rotation;
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
        UI_Menager.instance.Set_Legend("");
    }

    void finishi_viewer()
    {
        cam_finishi = false;
        isviewer = false;
        UI_Menager.instance.Set_back_interactable(false);

        if (current_interactable.item.isinteractable)
        {
            current_interactable.transform.rotation = origin_rotation;
            StartCoroutine(Moving_Object(current_interactable, origin_position));

        }

        On_finishi_viwer.Invoke();
        On_finishi_contrl.Invoke();
    }


    IEnumerator Moving_Object(Interactables obj, Vector3 position)
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

    void Rotateobject()
    {
        float eixo_x = Input.GetAxis("Mouse X");
        float eixo_y = Input.GetAxis("Mouse Y");
        current_interactable.transform.Rotate(cam.transform.right, -Mathf.Deg2Rad * eixo_y * rotate_speed, Space.World);
        current_interactable.transform.Rotate(cam.transform.up, -Mathf.Deg2Rad * eixo_x * rotate_speed, Space.World);
    }


    void Interacao(Item item)
    {
        if (item.image != null)
        {
            UI_Menager.instance.Set_Image(item.image);
        }
        audioplayer.PlayAudio(item.audioClip);
        UI_Menager.instance.Set_Legend(item.text);
        Invoke("Cam_finishi", item.audioClip.length + 1f);
    }


}
