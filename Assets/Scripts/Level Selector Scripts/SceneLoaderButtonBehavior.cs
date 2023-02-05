using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderButtonBehavior : MonoBehaviour
{
    [SerializeField]
    BackgroundManager bgman;
    [SerializeField]
    string[] levels;
    [SerializeField]
    string sceneToBack;

    void Start()
    {
        levels = new string[3];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click()
    {
        Debug.Log("play button clicked");
        if (!string.IsNullOrEmpty(levels[bgman.pointer]))
        {
            SceneManager.LoadScene(levels[bgman.pointer]);
        }
    }
    public void goBack()
    {
        Debug.Log("Back Button Clicked");
        if (!string.IsNullOrEmpty(sceneToBack))
        {
            SceneManager.LoadScene(sceneToBack);
        }
    }
}