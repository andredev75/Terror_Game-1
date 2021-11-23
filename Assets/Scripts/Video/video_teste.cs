using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class video_teste : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private double video;

    public GameObject skip;
    // Start is called before the first frame update
    void Start()
    {
        video = videoPlayer.length;
        videoPlayer = GetComponent<VideoPlayer>();
        skip.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(coroutine());

        if (Input.GetKey(KeyCode.Space))
        {

            SceneManager.LoadScene("Load_AssyncCCC");

        }

        if (video == videoPlayer.length)
        {
            SceneManager.LoadScene("LLoad_AssyncCCC");
        }
    }

    IEnumerator coroutine()
    {
        Debug.Log("entrei");
        yield return new WaitForSeconds(10);
        skip.SetActive(true);
    }
}
