using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Respawn : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        UI_Menager.instance.Morte_UI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
