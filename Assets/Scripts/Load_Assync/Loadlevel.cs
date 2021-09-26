using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Loadlevel : MonoBehaviour
{
    public int Loadscene;
    
   
    
    void Start() {

        StartCoroutine(LoadAsyn());
    }

    IEnumerator LoadAsyn () {

       yield return new WaitForSeconds(2f);

       AsyncOperation operation = SceneManager.LoadSceneAsync(Loadscene);
       System.GC.Collect();

       while(!operation.isDone)
       {
           float progress = (operation.progress / .9f);
           Time.timeScale = 1f;
            yield return null;
            Debug.Log("0");
       }

    }
}
