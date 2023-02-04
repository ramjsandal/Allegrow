using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantBehavior : MonoBehaviour
{
    private MeshRenderer _renderer;
    [SerializeField] private string plantScene;

    // Start is called before the first frame update
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
        changeScene();
    }

    private void changeScene()
    {
        SceneManager.LoadScene(plantScene);
    }


}
