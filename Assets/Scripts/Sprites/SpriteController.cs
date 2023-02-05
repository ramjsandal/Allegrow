using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    //[Header("Player Controller")]
    private PlayerController playerController;
    private GameObject tileSprite;
    private SpriteRenderer tileSpriteRenderer;
    private Vector3 startingPosition;
    [SerializeField] private Vector2 tileIncrement;
    private bool canGrow;

    // Start is called before the first frame update
    void Awake()
    {
        tileSprite = this.gameObject;
        tileSpriteRenderer = tileSprite.GetComponent<SpriteRenderer>();
        startingPosition = this.transform.position;
        canGrow = true;
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
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && canGrow)
        {
            canGrow = false;
            //MoveSprite();
        }
        else
        {
            if (canGrow)
                RootTrail();
        }
    }
}