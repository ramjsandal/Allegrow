using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRootSpawner : MonoBehaviour
{
    [Header("Lanes")]
    [SerializeField] private GameObject laneParent;
    [SerializeField] private GameObject[] lanes;

    [Header("Player")]
    [SerializeField] private GameObject player;

    [Header("Big Root")]
    public bool startingRoot = true;
    [SerializeField] private GameObject bigRootPrefab;
    public GameObject lastSpawnedBigRoot;

    [Header("First Vertical Root")]
    [SerializeField] private GameObject firstVerticalPrefabUp;
    [SerializeField] private GameObject firstVerticalPrefabDown;
    public GameObject lastSpawnedFirstRoot;

    [Header("Second Vertical Root")]
    [SerializeField] private GameObject secondVerticalPrefabThinUp;
    [SerializeField] private GameObject secondVerticalPrefabThinDown;
    public GameObject lastSpawnedSecondRoot;
    [SerializeField] private float xoff;
    //public int rotationAngle;
    private Quaternion rotation;

    [Header("Spawn Calculations")]
    [SerializeField] private Vector3 laneDistance;
    [SerializeField] private float spawnDelay;


    private Transform spawnPosition;
    private Transform currentPosition;
    private Vector3 spawnPositionSecondVertical;
    private int laneCount;
    private bool canSpawn;
    SpriteRenderer tileSpriteRenderer;
    private enum RootType { BigRoot, FirstVerticalRoot, SecondVerticalRoot};
    [SerializeField]private RootType rootType;

    private void Start()
    {
        canSpawn = true;
        player = GameObject.FindGameObjectWithTag("Player");
        laneParent = GameObject.FindGameObjectWithTag("Lane");
        laneCount = laneParent.transform.childCount;
        lanes = new GameObject[laneCount];
        for (int i = 0; i < laneCount; i++)
        {
            lanes[i] = laneParent.transform.GetChild(i).gameObject;
        }
        rotation = Quaternion.Euler(0, 0, 180);
        spawnPosition = this.gameObject.transform;
        CreateNextBigRoot();
    }
    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y == lanes[0].transform.position.y)
        {
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
                Invoke(nameof(SpawnEnabler), 0.01f);
            }
        }
        else if(player.transform.position.y == lanes[4].transform.position.y)
        {
            if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                Invoke(nameof(SpawnEnabler), 0.01f);
            }
        }
        else
        {
            canSpawn = true;
        }

        spawnPosition = this.gameObject.transform;

        if (canSpawn)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
            {
                if (rootType == RootType.BigRoot)
                {
                    Invoke(nameof(CreateNextBigRoot), spawnDelay);
                    startingRoot = false;
                }
                else if (rootType == RootType.FirstVerticalRoot)
                {
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        spawnPositionSecondVertical = spawnPosition.position + laneDistance;
                        CreateNextFirstVerticalRoot();
                    }
                    else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        spawnPositionSecondVertical = spawnPosition.position - laneDistance;
                        CreateNextFirstVerticalRoot();
                    }
                }
                else if (rootType == RootType.SecondVerticalRoot)
                {
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        spawnPositionSecondVertical = spawnPosition.position + laneDistance;
                        CreateNextSecondVerticalRoot();
                    }
                    else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        spawnPositionSecondVertical = spawnPosition.position - laneDistance;
                        CreateNextSecondVerticalRoot();
                    }
                }
            }
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
            lastSpawnedBigRoot = Instantiate(bigRootPrefab, spawnPosition.position + new Vector3(0 , 0, 1), spawnPosition.rotation);
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

    void CreateNextFirstVerticalRoot()
    {
        if (startingRoot == false)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                lastSpawnedFirstRoot = Instantiate(firstVerticalPrefabUp, spawnPositionSecondVertical, spawnPosition.rotation);
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                lastSpawnedFirstRoot = Instantiate(firstVerticalPrefabDown, spawnPositionSecondVertical, spawnPosition.rotation);
        }
        else if (startingRoot == true)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                lastSpawnedFirstRoot = Instantiate(firstVerticalPrefabUp, spawnPositionSecondVertical + new Vector3(.75f, 0, 0), spawnPosition.rotation);
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                lastSpawnedFirstRoot = Instantiate(firstVerticalPrefabDown, spawnPositionSecondVertical + new Vector3(.75f, 0, 0), spawnPosition.rotation);
        }
    }

    void CreateNextSecondVerticalRoot()
    {
        if (startingRoot == false)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                lastSpawnedFirstRoot = Instantiate(secondVerticalPrefabThinUp, spawnPositionSecondVertical, rotation);
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                lastSpawnedFirstRoot = Instantiate(secondVerticalPrefabThinDown, spawnPositionSecondVertical + new Vector3(xoff, 0, 0), rotation);
        }
        else if (startingRoot == true)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                lastSpawnedFirstRoot = Instantiate(secondVerticalPrefabThinUp, spawnPositionSecondVertical + new Vector3(.75f, 0, 0), rotation);
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                lastSpawnedFirstRoot = Instantiate(secondVerticalPrefabThinDown, spawnPositionSecondVertical + new Vector3(.75f, 0, 0) + new Vector3(xoff, 0, 0), rotation);
        }
    }

    void SpawnEnabler()
    {
        canSpawn = false;
    }
    //void ChangeFirstVerticalRoot()
    //{
    //    lastSpawnedFirstRoot.GetComponent<SpriteRenderer>().sprite = firstVerticalRootThick;
    //}
}
