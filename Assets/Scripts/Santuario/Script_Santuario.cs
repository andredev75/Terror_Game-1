using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Script_Santuario : MonoBehaviour
{
    public AudioClip play_audio;
    public float volume;
    public string text;
    AudioSource audio;
    public bool playing = false;

    public int time;


    public GameObject script_player;
    public UnityEvent Onview_control;
    public UnityEvent Onview_control_head;
    public UnityEvent On_finishi_viwer;

    public CanvasGroup canvas;
    private bool fadein;

    public void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (fadein)
        {
            if (canvas.alpha < 1)
            {
                canvas.alpha += Time.deltaTime;

                if (canvas.alpha >= 1)
                {
                    fadein = false;
                }
            }
        }


        if (Input.GetKey(KeyCode.Space))
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Menu");

        }
    }

    void OnTriggerEnter()
    {
        if (!playing)
        {
            audio.PlayOneShot(play_audio, volume);
            playing = true;
            //script_player.SetActive(false);
            Onview_control.Invoke();
            Onview_control_head.Invoke();

            UI_Menager.instance.Set_Legend(text);
            StartCoroutine(Aguardar_sair_legend());
        }
    }


    private IEnumerator Aguardar_sair_legend()
    {
        //Debug.Log("entrou");
        yield return new WaitForSeconds(time);
        UI_Menager.instance.Set_Legend("");
        fadein = true;
    }
}
