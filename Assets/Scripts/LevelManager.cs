using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool levelWon = false;
    [SerializeField] private string nextScene;
    public bool levelLost = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (levelWon)
        {
            loadNextLevel();
        }

        if (levelLost)
        {
            reloadLevel();
        }
    }

    void loadNextLevel()
    {
        SceneManager.LoadScene(nextScene);
    }

    void reloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
