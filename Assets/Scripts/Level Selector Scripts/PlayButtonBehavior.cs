using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonBehavior : MonoBehaviour
{
    [SerializeField]
    BackgroundManager bgman;
    [SerializeField]
    string[] levels;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click()
    {
        Debug.Log("play button clicked");
        /*if (!string.IsNullOrEmpty(levels[bgman.pointer]))
        {
            SceneManager.LoadScene(levels[bgman.pointer]);
        }*/
    }
}
