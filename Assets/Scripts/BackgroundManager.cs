using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    //Assign the backgrounds that should be used in this scene in the unity editor
    //Element zero will be the background visible by default when first loading in
    [SerializeField]
    GameObject[] backgrounds;

    //Used to point to the current background
    int pointer;

    void Start()
    {
        //backgrounds = new GameObject[3];
        foreach(GameObject sr in backgrounds)
        {
            sr.SetActive(false);
        }
        backgrounds[0].SetActive(true);
        pointer = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //swaps backgrounds (no transitions supported atm)
    //int bg : the background to swap to
    public void changeBackground(int bg)
    {
        Debug.Log("changeBackground called");
        if(bg != pointer)
        {
            backgrounds[bg].SetActive(true);
            backgrounds[pointer].SetActive(false);
            pointer = bg;
        }
        
    }
}
