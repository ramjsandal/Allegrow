using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject waterCollectionPoint;
    private Vector3 waterCollectionPointOriginalScale;

    [Header("Movement")]
    [SerializeField] private float horizontalSpeed;

    public bool pipeEnter = false;
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider2D;
    private float _endY;

    [Header("Water")]
    [SerializeField] private int waterDecreasePerSecond;
    [SerializeField] private float waterIncrease;
    [SerializeField] private float waterDecrease;
    [SerializeField] private Image waterBarImage;
    [SerializeField] private float maxWater;
    [SerializeField] private float contamWaterDecrease;
    [SerializeField] private float bugWaterDecrease;
    [SerializeField] private float maxDistanceToCollect; 
    
    private float _waterLevel;

    [Header("Lanes")]
    [SerializeField] private GameObject lane0;
    [SerializeField] private GameObject lane1;
    [SerializeField] private GameObject lane2;
    [SerializeField] private GameObject lane3;
    [SerializeField] private GameObject lane4;

    [SerializeField] private LevelManager levelManager;
    
    private int _currentLane;
    private GameObject[] _lanes;

    private readonly GUIStyle _guiStyle = new();
    // Start is called before the first frame update
    private void Start()
    {
        waterCollectionPointOriginalScale = new Vector3(waterCollectionPoint.transform.localScale.x, waterCollectionPoint.transform.localScale.y, waterCollectionPoint.transform.localScale.z);

        _lanes = new GameObject[5];
        _lanes[0] = lane0;
        _lanes[1] = lane1;
        _lanes[2] = lane2;
        _lanes[3] = lane3;
        _lanes[4] = lane4;
        _guiStyle.fontSize = 100;
        _waterLevel = maxWater;
        Transform t = this.transform;
        t.position = new Vector2(t.position.x, lane2.transform.position.y);
        _currentLane = 2;
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
        _collider2D = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Access the transform
        Transform currentTransform = this.transform;
        
        // Access the position
        Vector2 currentPosition = currentTransform.position;
        
        // If we press up, and we arent in a pipe, go up by one lane
        if (!pipeEnter)
        {
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && _currentLane > 0)
            {
                _currentLane -= 1;
            } else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && _currentLane < 4)
            {
                _currentLane += 1;
            }    
        }

        // Move the player to the new lane
        if (!pipeEnter)
        {
            currentTransform.position =
                new Vector2(currentPosition.x + Time.deltaTime * horizontalSpeed, _lanes[_currentLane].transform.position.y);    
        }
        else
        {
            this.transform.position = new Vector2(currentPosition.x + Time.deltaTime * horizontalSpeed, _endY);
        }
        
        DecreaseWaterLevel();
        
        // Check if the player has run out of water
        if (_waterLevel < .2f)
        {
            levelManager.loadMainMenu();
        }
        waterBarImage.type = Image.Type.Filled;
        waterBarImage.fillAmount = Mathf.Clamp(_waterLevel / maxWater, 0, 1f);
    }

    private void OnTriggerStay2D(Collider2D collision) 
    {
        switch (collision.gameObject.tag)
        {
            case "Plastic":
                _waterLevel -= waterDecrease;
                Destroy(collision.gameObject);
                break;
            case "Water":
                float distanceToCenter =
                    Math.Abs(collision.gameObject.transform.position.x - this.transform.position.x);

                if (distanceToCenter < maxDistanceToCollect)
                {
                    waterCollectionPoint.transform.localScale = waterCollectionPointOriginalScale * 2f;
                }


                if (!Input.GetKey(KeyCode.Space)) return;
                // Calculates how far player is in to water 
                float gap = (maxDistanceToCollect - distanceToCenter) / maxDistanceToCollect;
                
                // If the player is within range
                if (distanceToCenter < maxDistanceToCollect)
                {
                    _waterLevel += waterIncrease * (gap);
                    Debug.Log(waterIncrease * gap);
                    collision.gameObject.GetComponent<Collider2D>().enabled = false;
                    waterCollectionPoint.transform.localScale = waterCollectionPointOriginalScale;
                }

                break;
            
            case "ContamWater":
                if (!Input.GetKey(KeyCode.Space)) return;
                _waterLevel -= contamWaterDecrease;
                Destroy(collision.gameObject);
                break;
            case "Bug":
                _waterLevel -= bugWaterDecrease;
                Destroy(collision.gameObject);
                break;
            case "PipeStart":
                pipeEnter = true;
                break;
            case "LevelEnd":
                levelManager.levelWon = true;
                break;
            default: Debug.Log("This is for you Jane");
                break;
        }
    }
    
    private void DecreaseWaterLevel()
    {
        _waterLevel -= waterDecreasePerSecond * Time.deltaTime;
        _waterLevel = Mathf.Clamp(_waterLevel, 0, 100f);
    }

    public void EnterPipe(GameObject end, int endLane)
    {
        // Remove Controls
        pipeEnter = true;
        
        // Move to background
        this._spriteRenderer.sortingLayerName = "Hidden";
        
        // Deactivate Collider
        this._collider2D.enabled = false;
        
        // Set y position to y position of end
        _endY = end.transform.position.y;

        _currentLane = endLane;

    }

    public void ExitPipe()
    {
        // Turn on collider
        this._collider2D.enabled = true;
        
        // Move to foreground
        this._spriteRenderer.sortingLayerName = "Player";
        
        // Return controls
        pipeEnter = false;
    }
}
