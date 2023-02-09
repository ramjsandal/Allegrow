using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnMouseDown : MonoBehaviour
{
    [SerializeField] private string scene;

    private void OnMouseDown()
    {
        SceneManager.LoadScene(scene);
    }


}