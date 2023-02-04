using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;
    [SerializeField] private float waterLevel;
    [SerializeField] private int health;
    [SerializeField] private int waterDecreasePerSecond;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Access the transform
        var currentTransform = this.transform;
        
        // Access the position
        Vector2 currentPosition = currentTransform.position;
        
        // Constantly move to the right, and move up and down
        currentTransform.position = new Vector2(currentPosition.x + Time.deltaTime * horizontalSpeed, 
            currentPosition.y + Time.deltaTime * verticalSpeed * Input.GetAxis("Vertical"));
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If we collide with an enemy...
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
        }
        // If we collide with a "friendly" (water, etc)
        else if (collision.gameObject.CompareTag("Friendly"))
        {
            
        }
    }

    private void decreaseWaterLevel()
    {
        waterLevel -= waterDecreasePerSecond * Time.deltaTime;
    }

    private void OnGUI()
    {
        // Draw your water level and HP
    }
}
