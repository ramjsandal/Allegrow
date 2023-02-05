using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float horizontalSpeed;

    public bool pipeEnter = false;
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider2D;
    private float endY;
    
    [Header("Water")]
    [SerializeField] private int waterDecreasePerSecond;
    [SerializeField] private float waterIncrease;
    [SerializeField] private float waterDecrease;
    [SerializeField] private Image waterBarImage;
    [SerializeField] private float maxWater;
    [SerializeField] private float contamWaterDecrease;
    [SerializeField] private float bugWaterDecrease;

    [Header("Lanes")]
    [SerializeField] private GameObject lane0;
    [SerializeField] private GameObject lane1;
    [SerializeField] private GameObject lane2;
    [SerializeField] private GameObject lane3;
    [SerializeField] private GameObject lane4;

    private float waterLevel;
    private int currentLane;
    private GameObject[] lanes;

    private GUIStyle _guiStyle = new GUIStyle();
    // Start is called before the first frame update
    void Start()
    {
        lanes = new GameObject[5];
        lanes[0] = lane0;
        lanes[1] = lane1;
        lanes[2] = lane2;
        lanes[3] = lane3;
        lanes[4] = lane4;
        _guiStyle.fontSize = 100;
        waterLevel = maxWater;
        Transform t = this.transform;
        t.position = new Vector2(t.position.x, lane2.transform.position.y);
        currentLane = 2;
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
        _collider2D = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Access the transform
        var currentTransform = this.transform;
        
        // Access the position
        Vector2 currentPosition = currentTransform.position;
        

        // If we press up, and we arent in a pipe, go up by one lane
        if (!pipeEnter)
        {
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && currentLane > 0)
            {
                currentLane -= 1;
            } else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && currentLane < 4)
            {
                currentLane += 1;
            }    
        }
        
        
        
        // Move the player to the new lane
        if (!pipeEnter)
        {
            currentTransform.position =
                new Vector2(currentPosition.x + Time.deltaTime * horizontalSpeed, lanes[currentLane].transform.position.y);    
        }
        else
        {
            this.transform.position = new Vector2(currentPosition.x + Time.deltaTime * horizontalSpeed, endY);
        }
        

        decreaseWaterLevel();
        waterBarImage.type = Image.Type.Filled;
        waterBarImage.fillAmount = Mathf.Clamp(waterLevel / maxWater, 0, 1f);
    }

    private void OnTriggerStay2D(Collider2D collision) 
    {
        // If we collide with an enemy...
        if (collision.gameObject.CompareTag("Plastic"))
        {
            waterLevel -= waterDecrease;
            Destroy(collision.gameObject);
        }
        // If we collide with a "friendly" (water, etc)
        else if (collision.gameObject.CompareTag("Water"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                waterLevel += waterIncrease;
                Destroy(collision.gameObject);
            }
            
        } 
        else if (collision.gameObject.CompareTag("ContamWater"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                waterLevel -= contamWaterDecrease;
                Destroy(collision.gameObject);
            }
        } 
        else if (collision.gameObject.CompareTag("Bug"))
        {
            waterLevel -= bugWaterDecrease;
            Destroy(collision.gameObject);
        } 
        else if (collision.gameObject.CompareTag("PipeStart"))
        {
            pipeEnter = true;
        } 
    }
    
    
    

    private void decreaseWaterLevel()
    {
        waterLevel -= waterDecreasePerSecond * Time.deltaTime;
        waterLevel = Mathf.Clamp(waterLevel, 0, 100f);
    }

    private void OnGUI()
    {
        // Draw your water level 
        // GUI.Button(new Rect(100, 100, 200, 200), "Water: " + waterLevel.ToString("F0"), _guiStyle);

    }

    public void enterPipe(GameObject end, int endLane)
    {
        // Remove Controls
        pipeEnter = true;
        
        // Move to background
        this._spriteRenderer.sortingLayerName = "Hidden";
        
        // Deactivate Collider
        this._collider2D.enabled = false;
        
        // Set y position to y position of end
        endY = end.transform.position.y;

        currentLane = endLane;

    }

    public void exitPipe()
    {
        // Turn on collider
        this._collider2D.enabled = true;
        
        // Move to foreground
        this._spriteRenderer.sortingLayerName = "Player";
        
        // Return controls
        pipeEnter = false;
    }
}
