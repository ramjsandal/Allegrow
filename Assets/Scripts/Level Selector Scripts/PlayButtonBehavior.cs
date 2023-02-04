using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonBehavior : MonoBehaviour
{
    [SerializeField]
    BackgroundManager bgman;
    string[] levels;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("play button clicked");
        if (!string.IsNullOrEmpty(levels[bgman.pointer]))
        {
            SceneManager.LoadScene(levels[bgman.pointer]);
        }
    }
}
