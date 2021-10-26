using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu_menager : MonoBehaviour
{
    public static Menu_menager instante;
    public static bool game_paused = false;

    public GameObject pausemenuUI;

    void Awake()
    {
        instante = this;

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (game_paused)
            {
                Resume();
            }

            else
            {
                Pause();
            }

        }

    }



    public void Loadscene(string lvlname)
    {
        StartCoroutine(tocarsom());
        SceneManager.LoadScene(lvlname);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        pausemenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        game_paused = false;
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        pausemenuUI.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0f;
        game_paused = true;
    }

    IEnumerator tocarsom()
    {
        FindObjectOfType<Audio_menager>().Play("Confirmação");
        yield return new WaitForSeconds(10f);

    }
}
