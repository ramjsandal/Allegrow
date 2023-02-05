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
        spawnPosition = this.gameObject.transform;
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            startingRoot = false;
            Invoke(nameof(CreateNextBigRoot), spawnDelay);
        }
    }

    void CreateNextBigRoot()
    {
        lastSpawnedBigRoot = null;
        if (startingRoot == false)
        {
            lastSpawnedBigRoot = Instantiate(bigRootPrefab, spawnPosition.position + new Vector3(.75f, 0, 0), spawnPosition.rotation);

        }
        else if (startingRoot == true)
        {
            lastSpawnedBigRoot = Instantiate(bigRootPrefab, spawnPosition.position, spawnPosition.rotation);
        }
        tileSpriteRenderer = lastSpawnedBigRoot.GetComponent<SpriteRenderer>();
        SetSpriteSize();
    }

    void SetSpriteSize()
    {
        if (startingRoot == false) {
            tileSpriteRenderer.size = new Vector2(.25f, 1.125f);
            
        }
        else if (startingRoot == true) { 
            tileSpriteRenderer.size = new Vector2(1, 1.125f);
        }
    }
}
