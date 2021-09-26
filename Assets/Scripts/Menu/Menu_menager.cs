using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu_menager : MonoBehaviour
{
    public static bool Gamepaused = false;
    public GameObject pausemenuUI; 
    public GameObject menuGAMEUI;  

    public static Menu_menager instante;

     void Awake() 
    {
        instante = this;
        FindObjectOfType<Audio_menager>().Play("Inicio");     
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {

            if (Gamepaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }

        }
        
    }



    public void Loadscene (string lvlname)
    {
        SceneManager.LoadScene(lvlname);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    public void Resume ()
    {
        //Debug.Log("1");
        pausemenuUI.SetActive(false);
        menuGAMEUI.SetActive(true);
        Time.timeScale = 1f;
        Gamepaused = false;
    }

    public void Pause ()
    {
        //Debug.Log("2");
        pausemenuUI.SetActive(true);
        menuGAMEUI.SetActive(false);
        Time.timeScale = 0f;
        Gamepaused = true;
    }
}
