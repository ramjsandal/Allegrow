using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBehavior : MonoBehaviour
{
    //private MeshRenderer _renderer;
    //[SerializeField] private string plantScene;
    [SerializeField]
    int bgChange = 0;

    [SerializeField]
    BackgroundManager bgman;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        // XDDDDD it checks if you click the object by the way!!!11!11!
        //changeScene();
        Debug.Log("OnMouseDown called");
        bgman.changeBackground(bgChange);
    }

    private void changeScene()
    {
        /*if (!string.IsNullOrEmpty(plantScene))
        {
            Invoke("LoadNextLevel", 2);
        }
        SceneManager.LoadScene(plantScene);*/
    }


}
