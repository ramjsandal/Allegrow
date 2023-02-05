using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    [Header("Lanes")]
    [SerializeField] private GameObject laneParent;
    [SerializeField] private GameObject[] lanes;

    [Header("Player")]
    [SerializeField] private GameObject player;

    //[Header("Player Controller")]
    private PlayerController playerController;
    private GameObject tileSprite;
    private SpriteRenderer tileSpriteRenderer;
    private Vector3 startingPosition;
    [SerializeField] private Vector2 tileIncrement;
    private bool canGrow;
    private int laneCount;
    private int inputCount;
    private bool inputDisabler;
    private Transform playerPosition;
    //private bool canSpawn;

    // Start is called before the first frame update
    void Awake()
    {
        inputDisabler = true;
        inputCount = 0;
        tileSprite = this.gameObject;
        tileSpriteRenderer = tileSprite.GetComponent<SpriteRenderer>();
        startingPosition = this.transform.position;
        canGrow = true;
        //canSpawn = true;
        player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = player.transform;
        laneParent = GameObject.FindGameObjectWithTag("Lane");
        laneCount = laneParent.transform.childCount;
        lanes = new GameObject[laneCount];
        for (int i = 0; i < laneCount; i++)
        {
            lanes[i] = laneParent.transform.GetChild(i).gameObject;
        }
        //if (startingRoot == false)
        //    tileSpriteRenderer.size = new Vector2(1, 1.125f);
        //else if(startingRoot == true)
        //    tileSpriteRenderer.size = new Vector2(1, 1.125f);
    }

    // Update is called once per frame
    void Update()
    {
        InputCheck();
    }

    private void LateUpdate()
    {
        playerPosition = player.transform;
    }
    void RootTrail()
    {
        tileSpriteRenderer.size += tileIncrement * Time.deltaTime;
        this.transform.position = startingPosition;
        this.transform.position += new Vector3((tileSpriteRenderer.size.x - 1) * 0.5f, 0, 0);
    }

    //void MoveSprite()
    //{
    //    canGrow = false;
    //}

    void InputCheck()
    {
        //if (player.transform.position.y == lanes[0].transform.position.y && canGrow)
        //{
        //    //canGrow = true;
        //    //if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        //    //{
        //    //    //Invoke(nameof(SpawnEnabler), 0.01f);
        //    //    canGrow = true;
        //    //}
        //    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        //    {
        //        canGrow = false;
        //    }
        //    else
        //    {
        //        if (canGrow)
        //            RootTrail();
        //    }
        //    Debug.Log("Can Grow " + canGrow);
        //}
        //else if (player.transform.position.y == lanes[4].transform.position.y && canGrow)
        //{
        //    //if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        //    //{
        //    //    //Invoke(nameof(SpawnEnabler), 0.01f);
        //    //    canGrow = true;
        //    //}
        //    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        //    {
        //        canGrow = false;
        //    }
        //    else
        //    {
        //        if (canGrow)
        //            RootTrail();
        //    }
        //}
        //else
        //{
        //    canSpawn = true;
        //}
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && canGrow)
        {
            if (playerPosition.position.y == lanes[0].transform.position.y)
            {

                //if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                //{
                //    //Invoke(nameof(SpawnEnabler), 0.01f);
                //    canGrow = true;
                //}
                //if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && inputCount)
                //{
                //    canGrow = false;
                //    inputCount = false;
                //}
                //if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                //{
                //    canGrow = true;
                //}
                //if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                //{
                //    canGrow = true;
                //}
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    canGrow = false;
                }
                else if ( 1.96f > this.transform.position.y  || this.transform.position.y >= 0.96f)
                {
                    canGrow = false;
                }
                else if (1.96f <= this.transform.position.y)
                {
                    canGrow = true;
                }
                if (canGrow)
                {
                    RootTrail();
                }
                Debug.Log("Can Grow " + canGrow);
            }
            else if (playerPosition.position.y == lanes[4].transform.position.y && canGrow)
            {
                //if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                //{
                //    //Invoke(nameof(SpawnEnabler), 0.01f);
                //    canGrow = true;
                //}
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    canGrow = false;
                }
                else if (-1.04f >= this.transform.position.y || this.transform.position.y > -2.04f)
                {
                    canGrow = false;
                }
                else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    canGrow = true;
                }
                else
                {
                    if (canGrow)
                        RootTrail();
                }
            }
            else
            {
                canGrow = false;
            }
            
            //MoveSprite();
        }
        if (canGrow)
        {
            RootTrail();
        }
    }

    void SpawnEnabler()
    {
        canGrow = true;
    }
}