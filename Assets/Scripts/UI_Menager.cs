using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Menager : MonoBehaviour
{
    public static UI_Menager instance;

    public GameObject mao_cursor;
    public GameObject back_interactable;


    public TMP_Text legend;
    public Image Img_Interactable;


    public GameObject Morte_UI;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void cursor(bool state)
    {
        mao_cursor.SetActive(state);
    }

    public void Set_back_interactable(bool state)
    {
        back_interactable.SetActive(state);

        if (!state)
        {
            Img_Interactable.enabled = false;
        }
    }

    public void Set_Legend(string text)
    {
        legend.text = text;
    }




    public void Set_Image(Sprite sprite)
    {
        Img_Interactable.sprite = sprite;
        Img_Interactable.enabled = true;
    }
}
