using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    //[Header("Player Controller")]
    private PlayerController playerController;
    private GameObject tileSprite;
    private SpriteRenderer tileSpriteRenderer;
    private Vector3 startingPosition, currentPosition;
    [SerializeField] private Vector2 tileIncrement;

    // Start is called before the first frame update
    void Awake()
    {
        //playerController = this.GetComponent<PlayerController>();
        //tileSprite = this.gameObject.transform.GetChild(3).gameObject;
        //tileSpriteRenderer = tileSprite.GetComponent<SpriteRenderer>();
        tileSprite = this.gameObject;
        tileSpriteRenderer = tileSprite.GetComponent<SpriteRenderer>();
        startingPosition = this.transform.position;
        currentPosition = startingPosition;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tileSpriteRenderer.size += tileIncrement * Time.deltaTime;
        this.transform.position = startingPosition;
        this.transform.position += new Vector3((tileSpriteRenderer.size.x - 1) * 0.5f, startingPosition.y, startingPosition.z);
        
        
    }
}
