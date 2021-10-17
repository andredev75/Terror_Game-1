using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Azul_Menager : MonoBehaviour
{

    public static Puzzle_Azul_Menager instance;
    public Checkpoints[] allcheckpoint;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < allcheckpoint.Length; i++)
        {
            allcheckpoint[i].checknumber = i;
        }

    }

    void Update()
    {




    }

}
