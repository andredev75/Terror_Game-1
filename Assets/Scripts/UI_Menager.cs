using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Menager : MonoBehaviour
{
    public static UI_Menager instance;

    public GameObject mao_cursor;

    public GameObject back_interactable;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cursor (bool state)
    {
        mao_cursor.SetActive(state);
    }

    public void Set_back_interactable (bool state)
    {
        back_interactable.SetActive(state);
    }
}
