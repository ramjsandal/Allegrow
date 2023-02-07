using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadLevelScene : MonoBehaviour
{

    [SerializeField] private string scene;

    private void OnMouseDown()
    {
        SceneManager.LoadScene(scene);
        Debug.Log("Why isnt his working");
    }

}
