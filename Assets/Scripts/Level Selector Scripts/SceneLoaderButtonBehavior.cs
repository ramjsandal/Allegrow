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
    string[] levels = new string[3];
    [SerializeField]
    string sceneToBack;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click()
    {
        Debug.Log(sceneToBack);
        Debug.Log("play button clicked");
        Debug.Log("Attempted to load scene:" + "pointer:" + bgman.pointer + "Level:" + levels[bgman.pointer]);
        SceneManager.LoadScene(levels[bgman.pointer]);
        /*if (!string.IsNullOrEmpty(levels[bgman.pointer]))
        {
            Debug.Log("Attempted to load scene");
            SceneManager.LoadScene(levels[bgman.pointer]);
            Debug.Log("Succeeded to load scene");
        }*/
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
