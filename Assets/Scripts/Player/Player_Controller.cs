using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [Header("Movimentação Player")]
    [SerializeField]
    private CharacterController controller;
    private Vector3 move;

    public float p_X;
    public float p_Z;

    [SerializeField]
    private float jump_Force = 7f;


    [Header("Gravidade e checar chão Player")]

    [SerializeField]
    private float gravity = -9;
    private Vector3 velocity;
    [SerializeField]
    private Transform ground_check;
    [SerializeField]
    private float groud_Distance = 0.4f;
    [SerializeField]
    private LayerMask ground_Mask;
    private bool isground;


    [Header("Correr e agachar Player")]
    [SerializeField]
    private float speed_current;
    [SerializeField]
    private float speed_Walk = 7f;
    [SerializeField]
    private float speed_crouched = 3f;
    [SerializeField]
    private float speed_speed = 10f;
    [SerializeField]
    private float heigh;
    private bool isspeed;
    private bool iscrouched = false;

    private int next_Checkpoint;
    

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        heigh = controller.height;
    }

    // Update is called once per frame
    void Update()
    {

        Ground_Check();



    }

    void FixedUpdate() 
    {
        
        move_Player();
        Jump ();
        Speed_crouched ();

    }
    void move_Player ()
    {
        p_X = Input.GetAxis("Horizontal");
        p_Z = Input.GetAxis ("Vertical");

        move = transform.right *  p_X +  transform.forward * p_Z;

        controller.Move (move * speed_current * Time.deltaTime);

    }

    void Ground_Check ()
    {

        isground = Physics.CheckSphere(ground_check.position,groud_Distance,ground_Mask);
        controller.Move (move * speed_current * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }

    void Jump ()
    {
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt (jump_Force * -2f * gravity);
        }

    }

    void Speed_crouched ()
    {
        if(Input.GetKey(KeyCode.LeftShift) && iscrouched == false)
        {
            speed_current = speed_speed;
            isspeed = true;
            Debug.Log("correndo");
        }
        else 
        {
            speed_current = speed_Walk;
            isspeed = false;
        }

        if(Input.GetKey(KeyCode.LeftControl))
        {
            iscrouched = true;
            heigh = 2.7f;
            speed_current = speed_crouched;

        }
        else if (isspeed == false)
        {
            iscrouched = false;
            heigh = 5.5f;
            speed_current = speed_Walk;

        }

        controller.height  = Mathf.Lerp (controller.height, heigh,  3.5f * Time.deltaTime);

    }

    public void Checkpoint_Check (int checknumber)
    {

        if(checknumber == next_Checkpoint)
        {
            next_Checkpoint++;

            if(next_Checkpoint == Puzzle_Verde_Menager.instance.allcheckpoint.Length)
            {
                Debug.Log("venceu o puzzle verde");
            }
        }


    }

    
}
