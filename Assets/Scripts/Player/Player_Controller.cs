using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Controller : MonoBehaviour
{
    public static Player_Controller instance;

    [Header("Movimentação Player")]
    [SerializeField]
    private CharacterController controller;

    [HideInInspector]
    public Vector3 move1;

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

    private int next_Checkpoint = 0;

    [Header("Puzzle Verde")]
    public GameObject portao1;
    public GameObject portao2;

    [Header("Puzzle Final Santuario")]
    public GameObject portao_sant1;
    public GameObject portao_sant2;
    public bool terminou_p1 = false;
    public bool terminou_p2 = false;
    public bool terminou_p3 = false;



    [Header("Som dos passos")]
    [SerializeField]
    private AudioClip jump_sound;

    private AudioSource AudioSource;

    public float speed = 12f;
    public FootstepsSystem footsteps;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        AudioSource = GetComponent<AudioSource>();
        heigh = controller.height;
        instance = this;


        speed = 12f;
        footsteps = GetComponent<FootstepsSystem>();


    }
    // Update is called once per frame
    void Update()
    {
        Ground_Check();





    }

    void FixedUpdate()
    {
        move_Player();
        Jump();
        Speed_crouched();

    }
    void move_Player()
    {
        p_X = Input.GetAxis("Horizontal");
        p_Z = Input.GetAxis("Vertical");

        move1 = transform.right * p_X + transform.forward * p_Z;

        controller.Move(move1 * speed_current * Time.deltaTime);


        //soundfootstep
        p_X = Input.GetAxis("Horizontal");
        p_Z = Input.GetAxis("Vertical");

        if (p_X != 0f || p_Z != 0f)
        {
            footsteps.PlayFootSteps();
        }
        else
        {
            footsteps.ResetFootSteps();
        }

        Vector3 move = transform.right * p_X + transform.forward * p_Z;
        controller.Move(move * speed * Time.deltaTime);

    }

    void Ground_Check()
    {

        isground = Physics.CheckSphere(ground_check.position, groud_Distance, ground_Mask);

        if (isground && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        controller.Move(move1 * speed_current * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isground)
        {
            velocity.y = Mathf.Sqrt(jump_Force * -2f * gravity);
            PlayJumpSound();
        }

    }

    void Speed_crouched()
    {
        if (Input.GetKey(KeyCode.LeftShift) && iscrouched == false)
        {
            speed_current = speed_speed;
            isspeed = true;
            //Debug.Log("correndo");

        }
        else
        {
            speed_current = speed_Walk;
            isspeed = false;

        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            iscrouched = true;
            heigh = 2.7f;
            speed_current = speed_crouched;

        }
        else if (isspeed == false)
        {
            iscrouched = false;
            heigh = 5.1f;
            speed_current = speed_Walk;

        }

        controller.height = Mathf.Lerp(controller.height, heigh, 3.5f * Time.deltaTime);
    }

    private void PlayJumpSound()
    {
        AudioSource.clip = jump_sound;
        AudioSource.Play();
        //Debug.Log("pulando");
    }

    public void Checkpoint_Check_Verde(int checknumber)
    {

        if (checknumber == next_Checkpoint)
        {
            next_Checkpoint++;
            if (next_Checkpoint == Puzzle_Verde_Menager.instance.allcheckpoint.Length)
            {

                Debug.Log("venceu o puzzle verde");
                FindObjectOfType<Audio_menager>().Play("Terminou_puzzle");
                Destroy(portao1);
                portao2.SetActive(true);
                terminou_p1 = true;
                Liberar_Portal();

            }
        }

    }


    public void Checkpoint_Check_Vermelho(int checknumber)
    {

        if (checknumber == next_Checkpoint)
        {
            next_Checkpoint++;
            //Debug.Log("acertou");
            FindObjectOfType<Audio_menager>().Play("Acertou_puzzle");
            if (next_Checkpoint == Puzzle_Vermelho_Menager.instance.allcheckpoint.Length)
            {
                Debug.Log("venceu o puzzle vermelho");
                FindObjectOfType<Audio_menager>().Play("Terminou_puzzle");
                terminou_p2 = true;
                Liberar_Portal();
            }
        }
        else
        {
            next_Checkpoint = 0;
            FindObjectOfType<Audio_menager>().Play("Errou_puzzle");
            //Debug.Log("errou");
        }


    }

    public void Checkpoint_Check_Azul()
    {
        terminou_p3 = true;
        Debug.Log("venceu o puzzle azul");

    }


    public void Liberar_Portal()
    {
        if (terminou_p1 == true && terminou_p2 == true && terminou_p3 == true)
        {
            Destroy(portao_sant1);
            portao_sant2.SetActive(true);
        }
    }


}
