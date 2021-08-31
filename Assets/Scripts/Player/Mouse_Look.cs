using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Look : MonoBehaviour
{

    public float mouse_X;
    public float mouse_Y;
    public float mouse_sensitivy = 100f;


    public Transform player;

    private float Rotation_X = 0f;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        float mouse_X = Input.GetAxis("Mouse X") * mouse_sensitivy * Time.deltaTime;
        float mouse_Y = Input.GetAxis("Mouse Y") * mouse_sensitivy * Time.deltaTime;

        Rotation_X -= mouse_Y;
        Rotation_X = Mathf.Clamp(Rotation_X, -90f, 90f);
        
         
        transform.localRotation = Quaternion.Euler(Rotation_X, 0f, 0f);
        player.Rotate(Vector3.up,mouse_X);

    }
}
