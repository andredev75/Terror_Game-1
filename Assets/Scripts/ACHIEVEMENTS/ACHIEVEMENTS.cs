using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ACHIEVEMENTS : MonoBehaviour
{
    public GameObject achnote;
    public AudioSource achsound;
    public static int ach01count;
    public int ach01trigger = 1;
    public int ach01code;

    // Update is called once per frame
    void Update()
    {
        if (ach01count == ach01trigger)
        {
            Debug.Log("tocou");
            StartCoroutine(Trigger_nota());
        }

    }

    IEnumerator Trigger_nota()
    {
        achsound.Play();
        achnote.SetActive(true);

        yield return new WaitForSeconds(5);

        achnote.SetActive(false);
        Destroy(gameObject);

    }
}
