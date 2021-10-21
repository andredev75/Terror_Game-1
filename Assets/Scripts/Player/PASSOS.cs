using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))] // SCRIPT CRIADO POR Marcos Schultz
[RequireComponent(typeof(CharacterController))] // VISITE WWW.SCHULTZGAMES.COM e WEMAKEAGAME.COM.BR
public class PASSOS : MonoBehaviour
{
    public AudioClip SomDePassos;
    private CharacterController controller;
    private bool Esperando;
    private float TempoDeEspera;
    public float TempoDoPasso = 0.6f;

    //variaveis de movimento da camera
    public GameObject CameraDoPlayer;
    public float intensidadeDoMovimento;
    private Vector3 PosicaoInicialDaCamera;
    public float movimentoDaCamera;
    public bool comecarContagem;
    void Start()
    {
        comecarContagem = false;
        PosicaoInicialDaCamera = CameraDoPlayer.transform.localPosition;
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        CameraDoPlayer.transform.localPosition = Vector3.Lerp(CameraDoPlayer.transform.localPosition, PosicaoInicialDaCamera + PosicaoInicialDaCamera * movimentoDaCamera * intensidadeDoMovimento, 10 * Time.deltaTime);
        if (controller.isGrounded && controller.velocity.magnitude > 0.2f)
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                TocarSons();
                if (comecarContagem == false)
                {
                    movimentoDaCamera += Time.deltaTime;
                }
                if (comecarContagem == true)
                {
                    movimentoDaCamera -= Time.deltaTime;
                }
            }
        }
        if (!controller.isGrounded || controller.velocity.magnitude <= 0.29f)
        {
            GetComponent<AudioSource>().Stop();
            CameraDoPlayer.transform.localPosition = Vector3.Lerp(CameraDoPlayer.transform.localPosition, PosicaoInicialDaCamera + PosicaoInicialDaCamera * 0.25f * intensidadeDoMovimento, 10 * Time.deltaTime);
        }
        if (movimentoDaCamera >= TempoDeEspera)
        {
            comecarContagem = true;
        }
        if (movimentoDaCamera <= 0)
        {
            comecarContagem = false;
        }
        if (Esperando == true)
        {
            TempoDeEspera -= Time.deltaTime;
        }
        if (TempoDeEspera <= 0)
        {
            Esperando = false;
        }
    }
    void TocarSons()
    {
        if (Esperando == false)
        {
            GetComponent<AudioSource>().Stop();
            TempoDeEspera = TempoDoPasso;
            Esperando = true;
            GetComponent<AudioSource>().PlayOneShot(SomDePassos);
        }
    }
}