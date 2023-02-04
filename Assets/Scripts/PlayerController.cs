using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;
    [SerializeField] public float waterLevel;
    [SerializeField] private int waterDecreasePerSecond;
    [SerializeField] private float waterIncrease;
    [SerializeField] private float waterDecrease;
    [SerializeField] private GameObject lane1;
    [SerializeField] private GameObject lane2;
    [SerializeField] private GameObject lane3;
    [SerializeField] private GameObject lane4;
    [SerializeField] private GameObject lane5;
    private GameObject currentLane;
    

    private GUIStyle _guiStyle = new GUIStyle();
    // Start is called before the first frame update
    void Start()
    {
        _guiStyle.fontSize = 100;
        Transform t = this.transform;
        t.position = new Vector2(t.position.x, lane3.transform.position.y);
        currentLane = lane3;
    }

    // Update is called once per frame
    void Update()
    {
        // Access the transform
        var currentTransform = this.transform;
        
        // Access the position
        Vector2 currentPosition = currentTransform.position;

        // Constantly move to the right, and move up and down
        /*
         * currentTransform.position = new Vector2(currentPosition.x + Time.deltaTime * horizontalSpeed, 
            currentPosition.y + Time.deltaTime * verticalSpeed * Input.GetAxis("Vertical"));
         */

        currentTransform.position =
            new Vector2(currentPosition.x + Time.deltaTime * horizontalSpeed, currentPosition.y);
        
        // If we press up, go up by one lane
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            
        }

        decreaseWaterLevel();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        // If we collide with an enemy...
        if (collision.gameObject.CompareTag("Enemy"))
        {
            waterLevel -= waterDecrease;
        }
        // If we collide with a "friendly" (water, etc)
        else if (collision.gameObject.CompareTag("Friendly"))
        {
            waterLevel += waterIncrease;
        }
    }
    
    

    private void decreaseWaterLevel()
    {
        waterLevel -= waterDecreasePerSecond * Time.deltaTime;
    }

    private void OnGUI()
    {
        // Draw your water level 
        GUI.Button(new Rect(100, 100, 200, 200), "Water: " + waterLevel.ToString("F0"), _guiStyle);

    }
}
