using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string scene;
    
    public void click()
    {
        SceneManager.LoadScene(scene);
    }
    /*private void OnMouseDown()
    {
        SceneManager.LoadScene(scene);
    }*/
}
