using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRootSpawner : MonoBehaviour
{

    private Transform spawnPosition;
    public bool startingRoot = true;
    SpriteRenderer tileSpriteRenderer;
    [SerializeField] private GameObject bigRootPrefab;
    [SerializeField] private float spawnDelay;
    public GameObject lastSpawnedBigRoot;

    // Update is called once per frame
    void Update()
    {
        spawnPosition = GameObject.FindGameObjectWithTag("SpawnPointBigRoot").transform;
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            startingRoot = false;
            Invoke(nameof(CreateNextBigRoot), spawnDelay);
        }
    }

    void CreateNextBigRoot()
    {
        lastSpawnedBigRoot = Instantiate(bigRootPrefab, spawnPosition.position, spawnPosition.rotation);
        SetSpriteSize();
    }

    void SetSpriteSize()
    {
        if (startingRoot == false)
            tileSpriteRenderer.size = new Vector2(.25f, 1.125f);
        else if (startingRoot == true)
            tileSpriteRenderer.size = new Vector2(1, 1.125f);
    }
}
